using BR.Rodobens.Migration.Domain.Aggregates.Costumer.Helper;
using BR.Rodobens.Migration.Infra.CrossCutting.GraphSettings;
using BR.Rodobens.Migration.Infra.CrossCutting.Helper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace BR.Rodobens.Migration.Domain.Aggregates.Costumers.Services
{
    public class CostumerService : ICostumerService
    {
        private GraphOptions _graphOptions;
        private readonly IConfiguration _configuration;
        private readonly GraphServiceClient _graphClient;
        public CostumerService(IConfiguration configuration)
        {
            _configuration = configuration;
            ClientCredentialProvider authProvider = GetProvider(GetGraphOptions(_configuration));
            _graphClient = new GraphServiceClient(authProvider);
        }

        private GraphOptions GetGraphOptions(IConfiguration _configuration)
        {
            var options = new GraphOptions();
            options.AppId = _configuration.GetSection("b2cSettings:AppId").Value.ToString();
            options.TenantId = _configuration.GetSection("b2cSettings:TenantId").Value.ToString();
            options.ClientSecret = _configuration.GetSection("b2cSettings:ClientSecret").Value.ToString();
            options.B2cExtensionAppClientId = _configuration.GetSection("b2cSettings:B2cExtensionAppClientId").Value.ToString();
            _graphOptions = options;
            return options;
        }
            

        private ClientCredentialProvider GetProvider(GraphOptions config)
        {
            IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder
              .Create(config.AppId)
              .WithTenantId(config.TenantId)
              .WithClientSecret(config.ClientSecret)
              .Build();

            ClientCredentialProvider authProvider = new ClientCredentialProvider(confidentialClientApplication);
            return authProvider;
        }

        public async Task<string> InsertCostumer(Costumer costumer)
        {

            if (string.IsNullOrWhiteSpace(_graphOptions.B2cExtensionAppClientId))
            {
                throw new ArgumentException("B2C Extension App ClientId (ApplicationId) is missing in the appsettings.json. Get it from the App Registrations blade in the Azure portal. The app registration has the name 'b2c-extensions-app. Do not modify. Used by AADB2C for storing user data.'.", nameof(_graphOptions.B2cExtensionAppClientId));
            }

            try
            {
                const string cpf = "cpf";
                const string cnpj = "cnpj";
                const string tipoParceiro = "parceiroTipo";

                B2cCustomAttributeHelper helper = new B2cCustomAttributeHelper(_graphOptions.B2cExtensionAppClientId);
                string cpfAttributeName = helper.GetCompleteAttributeName(cpf);
                string cnpjAttributeName = helper.GetCompleteAttributeName(cnpj);
                string tipoParceiroAttributeName = helper.GetCompleteAttributeName(tipoParceiro);

                IDictionary<string, object> extensionInstance = new Dictionary<string, object>();
                if(!String.IsNullOrEmpty(costumer.Cpf))
                    extensionInstance.Add(cpfAttributeName, CpfCnpjHelper.FormatCpfCnpj(costumer.Cpf));
                if (!String.IsNullOrEmpty(costumer.Cnpj))
                    extensionInstance.Add(cnpjAttributeName, CpfCnpjHelper.FormatCpfCnpj(costumer.Cnpj));
                if (!String.IsNullOrEmpty(costumer.PartnerType))
                    extensionInstance.Add(tipoParceiroAttributeName, costumer.PartnerType);

                 var result = await _graphClient.Users
                .Request()
                .AddAsync(new User
                {
                    GivenName = costumer.GivenName,
                    Surname = costumer.Surname,
                    DisplayName = costumer.DisplayName,
                    Mail = costumer.Email,
                    Identities = new List<ObjectIdentity>
                    {
                            new ObjectIdentity()
                            {
                                SignInType = "emailAddress",
                                Issuer = _graphOptions.TenantId,
                                IssuerAssignedId =  costumer.Email
                            }
                    },
                    PasswordProfile = new PasswordProfile()
                    {
                        Password = "Rodobens@2021"
                    },
                    PasswordPolicies = "DisablePasswordExpiration",
                   AdditionalData = extensionInstance
                });

                return result.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
      

        public async Task DeleteCostumer(string userId)
        {
            try
            {
                await _graphClient.Users[userId]
                   .Request()
                   .DeleteAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task UpdatePassword(string userId, string password)
        {
            try
            {

                var user = new User
                {
                    PasswordPolicies = "DisablePasswordExpiration,DisableStrongPassword",
                    PasswordProfile = new PasswordProfile
                    {
                        ForceChangePasswordNextSignIn = false,
                        Password = password,
                    }
                };

                await _graphClient.Users[userId]
                 .Request()
                 .UpdateAsync(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Costumer> GetById(string userId)
        {
            string query = "id, displayName, givenName, surname, email," + GetCustomAttributes();
            var user = await _graphClient.Users[userId].Request()
                     .Select($""+ query)
                    .GetAsync();
            Costumer costumer = ConvertB2cToCostumer(user);
            return costumer;
        }

        public async Task<List<Costumer>> GetAll()
        {
            List<Costumer> costumerList = new List<Costumer>();
            string query = "id, displayName, givenName, surname, email,"+ GetCustomAttributes();
            var result = await _graphClient.Users.Request()
                               .Select($""+ query)
                              .GetAsync();
            foreach (var user in result.CurrentPage)
            {
                var costumer = ConvertB2cToCostumer(user);
                costumerList.Add(costumer);
            }

            return costumerList;
        }

        private string GetAttributeValue(User user, string field)
        {
            object value = null;
            if (user.AdditionalData != null)
            {
                user.AdditionalData.TryGetValue(GetCustomAttributeName(field), out value);
            }
            return value != null ? value.ToString() : string.Empty;
        }


        private string GetCustomAttributeName(string field)
        {
            B2cCustomAttributeHelper helper = new B2cCustomAttributeHelper(_graphOptions.B2cExtensionAppClientId);
            string attributeName = helper.GetCompleteAttributeName(field);
            return attributeName;
        }

        private string GetCustomAttributes()
        {
            const string cpfAttributeName = "cpf";
            const string cnpjAttributeName = "cnpj";
            const string tipoParceiroAttributeName = "parceiroTipo";
            B2cCustomAttributeHelper helper = new B2cCustomAttributeHelper(_graphOptions.B2cExtensionAppClientId);
            string cpfAttribute = helper.GetCompleteAttributeName(cpfAttributeName);
            string cnpjAttribute = helper.GetCompleteAttributeName(cnpjAttributeName);
            string tipoParceiroAttribute = helper.GetCompleteAttributeName(tipoParceiroAttributeName);
            return cpfAttribute + "," + cnpjAttribute + ","+ tipoParceiroAttribute;
        }

        private Costumer ConvertB2cToCostumer(User user)
        {
            Costumer costumer = new Costumer();
            costumer.Id = user.Id;
            costumer.DisplayName = user.DisplayName;
            costumer.GivenName = user.GivenName;
            costumer.Surname = user.Surname;
            costumer.Email = user.UserPrincipalName;
            costumer.Cpf = GetAttributeValue(user, "cpf");
            costumer.Cnpj = GetAttributeValue(user, "cnpj");
            costumer.PartnerType = GetAttributeValue(user, "parceiroTipo");
            return costumer;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
           
        }
    }
}
