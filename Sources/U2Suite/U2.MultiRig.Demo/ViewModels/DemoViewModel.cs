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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using log4net;
using U2.CommonControls;

namespace U2.MultiRig.Demo.ViewModels
{
    public sealed class DemoViewModel : WindowViewModelBase
    {
        private Rig? _rig;
        private bool _connected = false;
        private readonly ILog _logger = LogManager.GetLogger(typeof(DemoViewModel));
        private RigSettings? _rigSettings;
        private int _sourceType = 0;

        public const string Internal = nameof(Internal);
        public const string External = nameof(External);

        public DemoViewModel()
        {
            AllRigsSettings.LoadSettings();
            _rigSettings = AllRigsSettings.AllRigs.FirstOrDefault();
            ConnectButtonEnabled = _rigSettings != null;
            OnPropertyChanged(nameof(ConnectButtonEnabled));
        }

        public string ConnectButtonTitle { get; set; } = "Connect";
        public bool ConnectButtonEnabled { get; set; } = false;
        public bool ConfigureRigButtonVisible { get; set; } = true;

        public int SourceType
        {
            get => _sourceType;
            set
            {
                _sourceType = value;
                ConfigureRigButtonVisible = value == 0; // 0 = internal
                OnPropertyChanged(nameof(ConfigureRigButtonVisible));
            }
        }

        public string FreqA { get; set; } = "0";
        public string FreqB { get; set; } = "0";

        public async Task ExecuteConfigureRigAction()
        {
            var configWindow = new MultiRigWindow();
            var dialogTask = configWindow.ShowDialog(Owner);
            await dialogTask;

            _rigSettings = AllRigsSettings.AllRigs.FirstOrDefault();
            ConnectButtonEnabled = _rigSettings != null;
            OnPropertyChanged(nameof(ConnectButtonEnabled));
        }

        public void ExecuteConnectRigAction()
        {
            if (_connected)
            {
                _connected = false;
                ConnectButtonTitle = "Connect";
                _rig?.Stop();
                _rig?.Dispose();
            }
            else
            {
                if (_rigSettings == null)
                {
                    MessageBoxHelper.ShowMessageBox("Error", "Please configure RIG first.");
                    return;
                }

                var rigCommands = AllRigCommands.GetByRigType(_rigSettings.RigType);
                if (rigCommands == null)
                {
                    MessageBoxHelper.ShowMessageBox("Error", "The desired RIG settings not found.");
                    return;
                }

                _rig = new Rig(1, _rigSettings, rigCommands);
                _rig.RigParameterChanged += RigOnRigParameterChanged;
                _rig.Start();

                _connected = true;
                ConnectButtonTitle = "Disconnect";
            }

            OnPropertyChanged(nameof(ConnectButtonTitle));
        }

        private void RigOnRigParameterChanged(object sender, int rigNumber, 
            RigParameter parameter, object value)
        {
            _logger.Debug($"Received update of the parameter {parameter}. New value: {value}");
            var stringValue = value.ToString() ?? string.Empty;

            switch (parameter)
            {
                case RigParameter.None:
                    break;
                case RigParameter.Freq:
                    break;
                case RigParameter.FreqA:
                    FreqA = stringValue;
                    OnPropertyChanged(nameof(FreqA));
                    break;
                case RigParameter.FreqB:
                    FreqB = stringValue;
                    OnPropertyChanged(nameof(FreqB));
                    break;
                case RigParameter.Pitch:
                    break;
                case RigParameter.RitOffset:
                    break;
                case RigParameter.Rit0:
                    break;
                case RigParameter.VfoAA:
                    break;
                case RigParameter.VfoAB:
                    break;
                case RigParameter.VfoBA:
                    break;
                case RigParameter.VfoBB:
                    break;
                case RigParameter.VfoA:
                    break;
                case RigParameter.VfoB:
                    break;
                case RigParameter.VfoEqual:
                    break;
                case RigParameter.VfoSwap:
                    break;
                case RigParameter.SplitOn:
                    break;
                case RigParameter.SplitOff:
                    break;
                case RigParameter.RitOn:
                    break;
                case RigParameter.RitOff:
                    break;
                case RigParameter.XitOn:
                    break;
                case RigParameter.XitOff:
                    break;
                case RigParameter.Rx:
                    break;
                case RigParameter.Tx:
                    break;
                case RigParameter.CW_U:
                    break;
                case RigParameter.CW_L:
                    break;
                case RigParameter.SSB_U:
                    break;
                case RigParameter.SSB_L:
                    break;
                case RigParameter.DIG_U:
                    break;
                case RigParameter.DIG_L:
                    break;
                case RigParameter.AM:
                    break;
                case RigParameter.FM:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(parameter), parameter, null);
            }
        }
    }
}
