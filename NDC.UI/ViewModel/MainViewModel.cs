using NDC.UI.ViewModel;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NDC.UI.Event;
using Autofac.Features.Indexed;
using Prism.Events;

namespace NDC.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IIndex<string, IDetailViewModel> _detailViewModelCreator;
        private IDetailViewModel _selecteddetailViewModel;
        public MainViewModel(IIndex<string, IDetailViewModel> detailViewModelCreator, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            _detailViewModelCreator = detailViewModelCreator;
            DetailViewModels = new ObservableCollection<IDetailViewModel>();

            _eventAggregator.GetEvent<AfterDetailClosedEvent>().Subscribe(AfterDetailClosed);

            OpenSingleDetailViewCommand = new DelegateCommand<Type>(OnOpenSingleDetailViewExecute);
        }

        public ICommand OpenSingleDetailViewCommand { get; }
        //Para poder ter tabs
        public ObservableCollection<IDetailViewModel> DetailViewModels { get; }

        //Passa a ser usado para o detailVM selecionado
        public IDetailViewModel SelectedDetailViewModel
        {
            get { return _selecteddetailViewModel; }
            set
            {
                _selecteddetailViewModel = value;
                OnpropertyChanged();
            }
        }
        private void OnOpenSingleDetailViewExecute(Type viewModelType)
        {
            OnOpenDetailView(new OpenDtlViewEventArgs { Id = -1, ViewModelName = viewModelType.Name });
        }

        private async void OnOpenDetailView(OpenDtlViewEventArgs args)
        {
            var detailViewModel = DetailViewModels.SingleOrDefault(vm => vm.Id == args.Id
            && vm.GetType().Name == args.ViewModelName);

            if (detailViewModel == null)
            {
                detailViewModel = _detailViewModelCreator[args.ViewModelName];

                try
                {

                    await detailViewModel.LoadAsync(args.Id);
                    //Adicionado à lista de tabs
                    DetailViewModels.Add(detailViewModel);

                    SelectedDetailViewModel = detailViewModel;
                }
                catch (Exception)
                {

                    throw;
                }
                
            }
        }
        private void AfterDetailClosed(AfterDetailClosedDeletedEventArgs args)
        {
            RemoveDetailViewModel(args.Id, args.ViewModelName);
        }

        private void RemoveDetailViewModel(int id, string viewModelName)
        {
            //apanhar o tab para remover
            var detailViewModel = DetailViewModels.SingleOrDefault(vm => vm.Id == id
           && vm.GetType().Name == viewModelName);

            if (detailViewModel != null)
            {
                DetailViewModels.Remove(detailViewModel);
            }
        }
    }


}
