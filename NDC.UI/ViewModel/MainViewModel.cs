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

namespace NDC.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            OpenSingleDetailViewCommand = new DelegateCommand<Type>(OnOpenSingleDetailViewExecute);
        }

        

        public ICommand OpenSingleDetailViewCommand { get; }
        //Para poder ter tabs
        public ObservableCollection<IDetailViewModel> DetailViewModels { get; }


        private void OnOpenSingleDetailViewExecute(Type viewModelType)
        {
            OnOpenDetailView(new OpenDtlViewEventArgs { Id = -1, ViewModelName = viewModelType.Name });
        }

        private void OnOpenDetailView(OpenDtlViewEventArgs openDtlViewEventArgs)
        {
            throw new NotImplementedException();
        }
    }

    
}
