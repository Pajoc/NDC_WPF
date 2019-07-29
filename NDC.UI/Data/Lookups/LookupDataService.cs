using NDC.DataAccess;
using NDC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NDC.UI.Data.Lookups
{
    public class LookupDataService<T> : IDepartmentLookupDataService
        where T:new()
    {
        private IDataReaderAccess<T> _dataAccess;

        public LookupDataService(IDataReaderAccess<T> dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<LookupItem>> GetDepartmentLookupAsync()
        {
            var res = (List<Department>) await _dataAccess.GetAllAsync(new T());
            return res.Select(d => new LookupItem
            {
                Id = d.Id,
                DisplayMember = d.Description
            });
        }
    }

    //Nesta versão tinha um tipo 
    //public class LookupDataService : IDepartmentLookupDataService
    //{
    //    private IDataReaderAccess<Department> _dataAccess;

    //    public LookupDataService(IDataReaderAccess<Department> dataAccess)
    //    {
    //        _dataAccess = dataAccess;
    //    }

    //    public IEnumerable<LookupItem> GetDepartmentLookupAsync()
    //    {

    //        var res = _dataAccess.GetAll(new Department());

    //        return res.Select(d => new LookupItem
    //        {
    //            Id = d.Id,
    //            DisplayMember = d.Description
    //        });

    //    }
    //}
}
