using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Avalonia.Controls;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore;
using U2.Library.Database.Models;
using U2.Library.Models;

namespace U2.Library.ViewModels
{
    public sealed class RigsViewModel : ViewModelBase
    {
        private LibraryDbContext _dbContext;
        private int selectedVendorIndex;
        private ObservableCollection<RigDbo> selectedRigs;
        private RigDbo selectedRig;

        public RigsViewModel()
        {
            _dbContext = new LibraryDbContext();
            try
            {
                _dbContext.Database.Migrate();
            }
            catch { }

            Rigs = _dbContext.Rigs;
            Vendors = _dbContext.Vendors;
        }

        public IEnumerable<RigDbo> Rigs { get; set; }
        public int SelectedVendorIndex
        {
            get => selectedVendorIndex;
            set
            {
                selectedVendorIndex = value;
                FilterList();
            }
        }
        public IEnumerable<VendorDbo> Vendors { get; set; }

        public ObservableCollection<RigDbo> SelectedRigs
        {
            get => selectedRigs;
            set
            {
                selectedRigs = value;
                OnPropertyChanged();
            }
        }

        public RigDbo SelectedRig 
        { 
            get => selectedRig;
            set
            {
                selectedRig = value;
                var message = new DisplayRigMessage
                {
                    Rig = value
                };
                Messenger.Default.Send(message);
            }
        }

        public void FilterList()
        {
            var vendor = Vendors.ElementAt(selectedVendorIndex);
            var rigs = Rigs.Where(r => r.VendorId == vendor.Id);
            SelectedRigs = new ObservableCollection<RigDbo>(rigs);
        }
    }
}
