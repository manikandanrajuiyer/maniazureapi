using Mani.Azure.Api.Business.Interfaces;
using Mani.Azure.Api.Data.Interfaces;
using Mani.Azure.Api.Models;

namespace Mani.Azure.Api.Business
{
    public class EmployeeBusinessLayer : IEmployeeBusinessLayer
    {

        private readonly IEmployeeDataLayer _empDataLayer;

        public EmployeeBusinessLayer(IEmployeeDataLayer empDataLayer)
        {
            _empDataLayer = empDataLayer;
        }

        public async Task<Employee?> InsertEmployee(Employee empData)
        {
            try
            {
                return (await _empDataLayer.InsertEmployee(empData)).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }
    }
}