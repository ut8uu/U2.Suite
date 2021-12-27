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
    public class QslDesignerControlsViewModel : ViewModelBase
    {
        private List<TextFieldViewModel>? _fields = new List<TextFieldViewModel>();

        private List<QslCardDesign> _designs = Utilities.GetDesigns();

        public QslDesignerControlsViewModel()
        {
            
        }

        public List<TextFieldViewModel>? Fields { get; set; }
        
        public List<QslCardDesign>? Designs { get; set; }
    }
}
