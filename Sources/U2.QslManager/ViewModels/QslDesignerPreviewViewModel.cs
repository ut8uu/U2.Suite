using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;

namespace U2.QslManager
{
    public class QslDesignerPreviewViewModel : ViewModelBase
    {
        public Image? Image { get; set; }

        public void PreviewQsl()
        {
            OnPropertyChanged(nameof(Image));
        }
    }
}
