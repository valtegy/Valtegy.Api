using System.Collections.Generic;
using System.Threading.Tasks;

namespace Valtegy.Domain.Repositories
{
    public interface IDataRepositoryDapper
    {
        Task<IEnumerable<dynamic>> ExecuteStoredProcedure(string procedure, object parms = null);
    }
}
