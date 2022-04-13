using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;

namespace U2.Logger.ViewModels
{
    internal class WindowViewModelBase : ViewModelBase
    {
        private Window _owner = default!;

        public string WindowTitle { get; set; } = default!;

        public string CancelButtonTitle { get; set; } = Resources.Cancel;
        public string OkButtonTitle { get; set; } = Resources.OK;

        public Window Owner
        {
            get => _owner; 
            set
            {
                SetOwner(value);
            }
        }

        protected virtual void SetOwner(Window owner)
        {
            _owner = owner;
        }

        public virtual void ExecuteOkAction()
        {
            throw new NotImplementedException();
        }

        public virtual void ExecuteCancelAction()
        {
            throw new NotImplementedException();
        }
    }
}
