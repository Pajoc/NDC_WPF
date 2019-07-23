using Prism.Commands;
using Prism.Events;
using Purchase.UI.Event;
using Purchase.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NDC.UI.ViewModel
{
    public abstract class DetailViewModelBase : ViewModelBase, IDetailViewModel
    {
        private bool _hasChanges;

        public int _id;
        private string _title;

        public IEventAggregator EventAggregator { get; }

        public DetailViewModelBase(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
            CloseDetailViewCommand = new DelegateCommand(OnCloseDetailViewExecute);

        }

        public abstract Task LoadAsync(int ID);
        public ICommand SaveCommand { get; private set; }
        public ICommand CloseDetailViewCommand { get; }

        public int Id
        {
            get { return _id; }
            protected set { _id = value; }
        }

        public string Title
        {
            get { return _title; }
            protected set
            {
                _title = value;
                OnpropertyChanged();
            }
        }

        public bool HasChanges
        {
            get { return _hasChanges; }
            set
            {
                if (_hasChanges != value)
                {
                    _hasChanges = value;
                    OnpropertyChanged();
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            }
        }

        private void OnCloseDetailViewExecute()
        {
            EventAggregator.GetEvent<AfterDetailClosedEvent>()
               .Publish(new AfterDetailClosedDeletedEventArgs
               {
                   Id = this.Id,
                   ViewModelName = this.GetType().Name
               });
        }
    }
}
