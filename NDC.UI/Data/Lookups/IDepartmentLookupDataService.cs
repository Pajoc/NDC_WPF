using System.Collections.Generic;
using System.Threading.Tasks;
using NDC.Model;

namespace NDC.UI.Data.Lookups
{
    public interface IDepartmentLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetDepartmentLookupAsync();
    }
}