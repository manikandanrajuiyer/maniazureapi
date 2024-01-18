using Mani.Azure.Api.Models;

namespace Mani.Azure.Api.Business.Interfaces
{
    public interface IEmployeeBusinessLayer
    {

        Task<Employee?> InsertEmployee(Employee empData);
    }
}
