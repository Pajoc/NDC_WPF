using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDC.UI.ViewModel
{
    public interface IDetailViewModel
    {
        Task LoadAsync(int ID, bool preLoad);
        bool HasChanges { get; }
        int Id { get; }//Identificador para o tab
        void OnDeleteExecute();
        void OnAddNewDetailCommand();
    }
}
