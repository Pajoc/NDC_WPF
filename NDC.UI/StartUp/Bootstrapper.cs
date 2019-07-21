using Autofac;
using NDC.UI.ViewModel;
using Prism.Events;
using Purchase.UI.ViewModel;

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


            
            return builder.Build();
        }
    }
}
