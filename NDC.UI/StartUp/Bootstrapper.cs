using Autofac;
using NDC.DataAccess;
using NDC.Model;
using NDC.UI.Data;
using NDC.UI.Data.Lookups;
using NDC.UI.ViewModel;
using Prism.Events;
//using NDC.UI.ViewModel;

namespace NDC.UI.StartUp
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();

            builder.RegisterType<EmployeeDetailViewModel>().Keyed<IDetailViewModel>(nameof(EmployeeDetailViewModel));

            builder.RegisterType<EmployeeDataService>().As<IEmployeeDataService>();
            builder.RegisterType<WebServiceDataAccess<Employee>>().As<IDataAccess<Employee>>();

            builder.RegisterType<LookupDataService<Department>>().As<IDepartmentLookupDataService>();
            builder.RegisterType<WebServiceDataAccess<Department>>().As<IDataReaderAccess<Department>>();

            return builder.Build();
        }
    }
}
