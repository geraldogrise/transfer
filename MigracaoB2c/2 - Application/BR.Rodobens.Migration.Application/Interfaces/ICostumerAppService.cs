using BR.Rodobens.Migration.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BR.Rodobens.Migration.Application.Interfaces
{
    public interface ICostumerAppService : IDisposable
    {
        public Task InsertCostumer(CostumerModel costumer);
        public Task UpdatePassword(CostumerPassword costumer);
        public Task DeleteCostumer(string id);
        public CostumerModel GetById(string id);
        public Task<List<CostumerModel>> GetAll();
    }
}
