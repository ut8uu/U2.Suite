using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using U2.Library.Database.Models;
using U2.Library.Models;

namespace U2.Library.ViewModels
{
    public sealed class RigDetailsViewModel : ViewModelBase
    {
        private RigDbo _rig;

        public RigDetailsViewModel()
        {
            Messenger.Default.Register<DisplayRigMessage>(this,
                AcceptDisplayRigMessage);
        }

        public RigDbo Rig
        {
            get => _rig;
            set
            {
                _rig = value; 
                OnPropertyChanged(nameof(Rig));
            }
        }

        private void AcceptDisplayRigMessage(DisplayRigMessage message)
        {
            Rig = message.Rig;
        }
    }
}
