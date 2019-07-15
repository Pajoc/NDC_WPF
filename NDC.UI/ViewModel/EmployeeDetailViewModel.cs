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
    public class EmployeeDetailViewModel : DetailViewModelBase
    {
        //private SupplierTypeWrapper _selectecSupplierType;

        public EmployeeDetailViewModel(IEventAggregator eventAggregator): base (eventAggregator)
        {
            Title = "Employees";
            Employees = new ObservableCollection<EmployeesWrapper>();
        }

        public ObservableCollection<EmployeesWrapper> Employees { get; }

        public async override Task LoadAsync(int id)
        {
            Id = id;

        }
    }
}
