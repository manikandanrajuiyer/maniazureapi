using Mani.Azure.Api.Models;

namespace Mani.Azure.Api.Data.Interfaces
{
    public interface IEmployeeDataLayer
    {
        Task<IEnumerable<Employee>> InsertEmployee(Employee organization);
    }
}
