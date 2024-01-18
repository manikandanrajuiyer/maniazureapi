using Dapper;
using Mani.Azure.Api.Data.Interfaces;
using Mani.Azure.Api.Models;
using System.Data;

namespace Mani.Azure.Api.Data
{
    public class EmployeeDataLayer : IEmployeeDataLayer
    {

        private readonly ISqlDapperDataAccess _dataAccess;
        public EmployeeDataLayer(ISqlDapperDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<Employee>> InsertEmployee(Employee employee)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@P_EMPNAME", employee.EmployeeName, DbType.String);
            parameters.Add("@P_ADDRESS", employee.Address, DbType.String);
            parameters.Add("@P_DOB", employee.DateOfBirth, DbType.Date);
            parameters.Add("@P_STATE", employee.State, DbType.String);


            return await _dataAccess.ExecuteStoredProcedure<Employee>("INSERTEMPLOYEE", parameters);
        }
    }
}