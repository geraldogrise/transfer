using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BR.Rodobens.Migration.Domain.Aggregates.Costumers.Services
{
    public interface ICostumerService : IDisposable
    {
        public Task<string> InsertCostumer(Costumer costumer);
        public Task DeleteCostumer(string userId);
        public Task UpdatePassword(string userId, string password);
        public Task<Costumer> GetById(string id);
        public Task<List<Costumer>> GetAll();
    }
}
