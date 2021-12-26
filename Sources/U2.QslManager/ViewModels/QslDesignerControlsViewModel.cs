using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace U2.QslManager
{
    public class QslDesignerControlsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private List<TextFieldViewModel>? _fields = new List<TextFieldViewModel>();

        private List<QslCardDesign> _designs = Utilities.GetDesigns();

        public QslDesignerControlsViewModel()
        {
            
        }

        public List<TextFieldViewModel>? Fields
        {
            get => _fields;
            set
            {
                _fields = value;
                OnPropertyChanged();
            }
        }

        public List<QslCardDesign>? Designs
        {
            get => _designs;
            set
            {
                _designs = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
