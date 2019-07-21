using Purchase.UI.ViewModel;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Purchase.UI.Event;
using Autofac.Features.Indexed;

namespace NDC.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IIndex<string, IDetailViewModel> _detailViewModelCreator;
        private IDetailViewModel _selecteddetailViewModel;
        public MainViewModel(IIndex<string, IDetailViewModel> detailViewModelCreator)
        {
            _detailViewModelCreator = detailViewModelCreator;
            DetailViewModels = new ObservableCollection<IDetailViewModel>();

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
    }


}
