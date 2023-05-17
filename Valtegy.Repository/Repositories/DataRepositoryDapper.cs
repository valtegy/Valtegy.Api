using Valtegy.Domain.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Valtegy.Repository.Context;

namespace Valtegy.Repository.Repositories
{
    public class DataRepositoryDapper : IDataRepositoryDapper
    {
        private readonly ValtegyDbContext _context;
        public DataRepositoryDapper(ValtegyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<dynamic>> ExecuteStoredProcedure(string procedure, object parms = null)
        {
            using (IDbConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var values = parms;
                var results = await connection.QueryAsync(procedure, values, commandType: CommandType.StoredProcedure);
                return results;
            }
        }
    }
}
