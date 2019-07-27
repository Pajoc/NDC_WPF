using NDC.UI.Data;
using NDC.UI.Wrapper;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDC.UI.ViewModel
{
    public class EmployeeDetailViewModel : DetailViewModelBase, IDetailViewModel
    {
        //private SupplierTypeWrapper _selectecSupplierType;
        private IEmployeeDataService _employeeDS;

        public EmployeeDetailViewModel(IEventAggregator eventAggregator, IEmployeeDataService employeeDS) : base (eventAggregator)
        {
            Title = "Employees";
            _employeeDS = employeeDS;

            Employees = new ObservableCollection<EmployeesWrapper>();
        }


        public ObservableCollection<EmployeesWrapper> Employees { get; }

        public async override Task LoadAsync(int id)
        {
            Id = id;

            var employees = await _employeeDS.GetAllAsync();

            foreach (var item in employees)
            {
                item.IsActive = item.IsActive != null ? item.IsActive : false;
                var wemp = new EmployeesWrapper(item);
                //TODO: changed
                Employees.Add(wemp);
            }

        }
    }
}
