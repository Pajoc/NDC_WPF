using NDC.UI.Data;
using NDC.UI.Wrapper;
using NDC.Model;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDC.UI.Data.Lookups;
using System.Windows.Input;
using Prism.Commands;

namespace NDC.UI.ViewModel
{
    public class EmployeeDetailViewModel : DetailViewModelBase, IDetailViewModel
    {
        //private SupplierTypeWrapper _selectecSupplierType;
        private IEmployeeDataService _employeeDS;
        private IDepartmentLookupDataService _employeeTypeLookupDataService;
        private EmployeesWrapper _selectedEmployee;
        private Employee _searchEmployee;

        public EmployeeDetailViewModel(IEventAggregator eventAggregator, IDepartmentLookupDataService employeeTypeLookupDataService, IEmployeeDataService employeeDS) : base (eventAggregator)
        {
            Title = "Employees";
            _employeeDS = employeeDS;
            _employeeTypeLookupDataService = employeeTypeLookupDataService;

            Employees = new ObservableCollection<EmployeesWrapper>();
            Departments = new ObservableCollection<LookupItem>();

            FilterCommand = new DelegateCommand(OnFilterExecuteAsync);
            _searchEmployee = new Employee();
        }

        public ObservableCollection<EmployeesWrapper> Employees { get; }
        public ObservableCollection<LookupItem> Departments { get; }

        public ICommand FilterCommand { get; private set; }
        //FilterCommand
        public async override Task LoadAsync(int id, bool preLoad)
        {
            Id = id;

            if (preLoad)
            {
                var employees = await _employeeDS.GetAllAsync(SearchEmployee);

                Employees.Clear();
                foreach (var item in employees)
                {
                    item.IsActive = item.IsActive != null ? item.IsActive : false;
                    var wemp = new EmployeesWrapper(item);
                    //TODO: changed
                    Employees.Add(wemp);
                }
                await LoadDepartmentLookupAsync();
            }
        }

        public EmployeesWrapper SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged();
            }
        }

        public Employee SearchEmployee {

            get { return _searchEmployee; }
            set
            {
                _searchEmployee = value;
                OnPropertyChanged();
            }
        }

        private async Task LoadDepartmentLookupAsync()
        {
            Departments.Clear();
            Departments.Add(new NullLookupItem { DisplayMember = " - " });
            var lookup = await _employeeTypeLookupDataService.GetDepartmentLookupAsync();
            foreach (var lookupItem in lookup)
            {
                Departments.Add(lookupItem);
            }
        }
        private async void OnFilterExecuteAsync()
        {

            await LoadAsync(Id, true);
        }


    }
}
