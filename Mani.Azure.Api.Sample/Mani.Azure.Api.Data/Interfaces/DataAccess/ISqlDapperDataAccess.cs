namespace Mani.Azure.Api.Data.Interfaces
{
    public interface ISqlDapperDataAccess
    {
        public Task<IEnumerable<T>> ExecuteStoredProcedure<T>(string query, object parameters);
    }
}
