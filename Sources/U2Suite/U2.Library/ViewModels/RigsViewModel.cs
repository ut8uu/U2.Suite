/* 
 * This file is part of the U2.Suite distribution
 * (https://github.com/ut8uu/U2.Suite).
 * 
 * Copyright (c) 2022 Sergey Usmanov, UT8UU.
 * 
 * This program is free software: you can redistribute it and/or modify  
 * it under the terms of the GNU General Public License as published by  
 * the Free Software Foundation, version 3.
 *
 * This program is distributed in the hope that it will be useful, but 
 * WITHOUT ANY WARRANTY; without even the implied warranty of 
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU 
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License 
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore;
using U2.Library.Database.Models;
using U2.Library.Models;

namespace U2.Library.ViewModels
{
    public sealed class RigsViewModel : ViewModelBase
    {
        private LibraryDbContext _dbContext;
        private int _selectedVendorIndex;
        private ObservableCollection<RigDbo> _selectedRigs = default!;
        private RigDbo _selectedRig = default!;

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
            SelectedVendorIndex = 0;
        }

        public IEnumerable<RigDbo> Rigs { get; set; }
        public int SelectedVendorIndex
        {
            get => _selectedVendorIndex;
            set
            {
                _selectedVendorIndex = value;
                FilterList();
            }
        }
        public IEnumerable<VendorDbo> Vendors { get; set; }

        public ObservableCollection<RigDbo> SelectedRigs
        {
            get => _selectedRigs;
            set
            {
                _selectedRigs = value;
                OnPropertyChanged();
            }
        }

        public RigDbo SelectedRig
        {
            get => _selectedRig;
            set
            {
                _selectedRig = value;
                var message = new DisplayRigMessage
                {
                    Rig = value
                };
                Messenger.Default.Send(message);
            }
        }

        public void FilterList()
        {
            if (Vendors == null)
            {
                return;
            }

            var vendor = Vendors.ElementAt(_selectedVendorIndex);
            var rigs = Rigs.Where(r => r.VendorId == vendor.Id);
            SelectedRigs = new ObservableCollection<RigDbo>(rigs);
        }
    }
}
