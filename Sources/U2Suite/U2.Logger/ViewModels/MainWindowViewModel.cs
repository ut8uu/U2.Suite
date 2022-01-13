using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Controls;

namespace U2.Logger.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly Window _owner;

        public MainWindowViewModel(Window owner)
        {
            _owner = owner;
        }

        public Window Owner => _owner;
        public string StatusText { get; set; } = default!;
    }
}
