using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Messaging;
using U2.Core;
using U2.Library.Database.Models;
using U2.Library.Models;

namespace U2.Library.ViewModels
{
    public sealed class RigDetailsViewModel : ViewModelBase
    {
        private RigDbo _rig;
        private List<KeyValuePair<string, string>> rigCharacteristics;
        private string rigImagePath;

        public RigDetailsViewModel()
        {
            Messenger.Default.Register<DisplayRigMessage>(this,
                AcceptDisplayRigMessage);
        }

        public string RigImagePath
        {
            get => rigImagePath;
            set
            {
                rigImagePath = value;
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
                if (_rig.PowerWatts.HasValue)
                {
                    list.Add(new KeyValuePair<string, string>("Power, watts", _rig.PowerWatts.Value.ToString()));
                }

                if (_rig.ManufactureStart.HasValue)
                {
                    list.Add(new KeyValuePair<string, string>("Production start", _rig.ManufactureStart.Value.ToString()));

                    if (_rig.ManufactureEnd.HasValue)
                    {
                        list.Add(new KeyValuePair<string, string>("Production end", _rig.ManufactureEnd.Value.ToString()));
                    }
                }

                if (_rig.Width.HasValue && _rig.Height.HasValue && _rig.Depth.HasValue)
                {
                    var dimensions = $"{_rig.Width.Value} x {_rig.Height.Value} x {_rig.Depth.Value}";
                    list.Add(new KeyValuePair<string, string>("Dimensions (W x H x D), mm", dimensions));
                }

                if (_rig.WeightGrams.HasValue)
                {
                    list.Add(new KeyValuePair<string, string>("Weight, g", _rig.WeightGrams.Value.ToString()));
                }

                RigImagePath = string.Empty;
                if (!string.IsNullOrEmpty(_rig.DataDirectory))
                {
                    var dataDirectory = _rig.DataDirectory.Replace('/', Path.DirectorySeparatorChar);
                    var imagesDirectory = FileSystemHelper.GetFullPath("Database", "Rigs", dataDirectory, "Images");
                    if (Directory.Exists(imagesDirectory))
                    {
                        var firstImage = Directory.EnumerateFiles(imagesDirectory).FirstOrDefault();
                        if (!string.IsNullOrEmpty(firstImage))
                        {
                            RigImagePath = firstImage;
                        }
                    }
                }

                RigCharacteristics = list;
                OnPropertyChanged(nameof(Rig));
            }
        }

        public List<KeyValuePair<string, string>> RigCharacteristics
        {
            get => rigCharacteristics;
            set
            {
                rigCharacteristics = value;
                OnPropertyChanged();
            }
        }

        private void AcceptDisplayRigMessage(DisplayRigMessage message)
        {
            Rig = message.Rig;
        }
    }
}
