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
using System.IO;
using System.Linq;
using GalaSoft.MvvmLight.Messaging;
using U2.Core;
using U2.Library.Database.Models;
using U2.Library.Models;

namespace U2.Library.ViewModels
{
    public sealed class RigDetailsViewModel : ViewModelBase
    {
        private RigDbo _rig = default!;
        private List<KeyValuePair<string, string>> _rigCharacteristics = default!;
        private string _rigImagePath = "pack://application:,,,/Database/Rigs/ADI/ar146.jpg";//default!;

        public RigDetailsViewModel()
        {
            Messenger.Default.Register<DisplayRigMessage>(this,
                AcceptDisplayRigMessage);
        }

        public string RigImagePath
        {
            get => _rigImagePath;
            set
            {
                _rigImagePath = value;
                OnPropertyChanged();
            }
        }

        public RigDbo Rig
        {
            get => _rig;
            set
            {
                _rig = value;
                if (_rig == null)
                {
                    RigCharacteristics = new List<KeyValuePair<string, string>>();
                    RigImagePath = string.Empty;
                    return;
                }

                var list = new List<KeyValuePair<string, string>>();
                list.Add(new KeyValuePair<string, string>("Manufacturer", _rig.Vendor.Name));
                list.Add(new KeyValuePair<string, string>("Name", _rig.Name));
                if (!string.IsNullOrEmpty(_rig.RigType))
                {
                    list.Add(new KeyValuePair<string, string>("Type", _rig.RigType));
                }

                if (!string.IsNullOrEmpty(_rig.PowerWatts))
                {
                    list.Add(new KeyValuePair<string, string>("Power", _rig.PowerWatts));
                }

                if (!string.IsNullOrEmpty(_rig.Dimensions))
                {
                    list.Add(new KeyValuePair<string, string>("Dimensions (W x H x D)", _rig.Dimensions));
                }

                if (!string.IsNullOrEmpty(_rig.WeightGrams))
                {
                    list.Add(new KeyValuePair<string, string>("Weight", _rig.WeightGrams));
                }

                RigImagePath = string.Empty;
                if (!string.IsNullOrEmpty(_rig.Image))
                {
                    var image = _rig.Image.Replace('/', Path.DirectorySeparatorChar);
                    var imagePath = FileSystemHelper.GetFullPath("Database", "Rigs", image);
                    if (File.Exists(imagePath))
                    {
                        RigImagePath = imagePath;
                    }
                }

                RigCharacteristics = list;
                OnPropertyChanged(nameof(Rig));
            }
        }

        public List<KeyValuePair<string, string>> RigCharacteristics
        {
            get => _rigCharacteristics;
            set
            {
                _rigCharacteristics = value;
                OnPropertyChanged();
            }
        }

        private void AcceptDisplayRigMessage(DisplayRigMessage message)
        {
            Rig = message.Rig;
        }
    }
}
