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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaloniaEdit.Utils;
using U2.CommonControls;
using U2.Core;
using U2.MultiRig.Code;

namespace U2.MultiRig.ViewModels;

public class MultiRigWindowViewModel : WindowViewModelBase
{
    private RigSettings _selectedRig;
    private IEnumerable<ComPortInfo> _knownComPorts;
    private ComPortInfo _selectedPort;
    private string _selectedRigType;

    public MultiRigWindowViewModel()
    {
        AllRigsSettings.LoadSettings();
        AllRigs = new ObservableCollection<RigSettings>(AllRigsSettings.AllRigs);
        AllCommands = new ObservableCollection<string>(RigCommandUtilities.EnumerateAllRigCommandNames());
        _knownComPorts = ComPortHelper.EnumerateComPorts();
        AllPorts = new ObservableCollection<ComPortInfo>(_knownComPorts);
        SelectedRig = AllRigs.First();
        SelectedRigIndex = 0;
    }

    #region Properties

    public string SelectRigTitle { get; set; } = "Select rig";

    public ObservableCollection<RigSettings> AllRigs { get; }
    public ObservableCollection<string> AllCommands { get; }
    public ObservableCollection<ComPortInfo> AllPorts { get; } = new();
    public ObservableCollection<int> AllBaudRates { get; } = new(ComPortStuff.BaudRates);

    public ObservableCollection<ComPortStuff.Parity> AllParities { get; } = new(
        new[]
        {
                ComPortStuff.Parity.None,
                ComPortStuff.Parity.Odd,
                ComPortStuff.Parity.Even,
                ComPortStuff.Parity.Mark,
                ComPortStuff.Parity.Space,
        });

    public ObservableCollection<int> AllDataBits { get; } = new(ComPortStuff.DataBits);
    public ObservableCollection<decimal> AllStopBits { get; } = new(ComPortStuff.StopBits);

    public ObservableCollection<ComPortStuff.RtsMode> AllRtsModes { get; } = new(new[]
    {
            ComPortStuff.RtsMode.High, ComPortStuff.RtsMode.Low, ComPortStuff.RtsMode.Handshake,
        });

    public ObservableCollection<ComPortStuff.DtrMode> AllDtrModes { get; } = new(new[]
    {
            ComPortStuff.DtrMode.High, ComPortStuff.DtrMode.Low,
        });

    public int SelectedRigIndex { get; set; }

    public RigSettings SelectedRig
    {
        get => _selectedRig;
        set
        {
            _selectedRig = value;
            if (_selectedRig != null)
            {
                var port = _knownComPorts.FirstOrDefault(p => p.Name == _selectedRig?.Port)
                           ?? _knownComPorts.FirstOrDefault(p => p.Name == ComPortInfo.None);

                SelectedPort = port;
                OnPropertyChanged(nameof(SelectedPort));

                _selectedRigType = RigCommandUtilities.EnumerateAllRigCommandNames()
                    .FirstOrDefault(cn => cn.Equals(_selectedRig.RigType)) ?? string.Empty;
                OnPropertyChanged(nameof(SelectedRigType));
            }
        }
    }

    public ComPortInfo SelectedPort
    {
        get => _selectedPort;
        set
        {
            _selectedPort = value;
            if (_selectedPort != null
                && _selectedRig != null
                && _selectedRig.Port != _selectedPort.Name)
            {
                _selectedRig.Port = _selectedPort.Name;
            }
        }
    }

    public string SelectedRigType
    {
        get => _selectedRigType;
        set
        {
            _selectedRigType = value;
            if (!string.IsNullOrEmpty(_selectedRigType)
                && _selectedRig != null
                && _selectedRig.RigType != _selectedRigType)
            {
                _selectedRig.RigType = _selectedRigType;
            }
        }
    }

    #endregion

    #region Titles

    public string RigIdTitle { get; set; } = MultiRigResources.RigIdTitle;
    public string EnabledTitle { get; set; } = MultiRigResources.EnabledTitle;
    public string RigTypeTitle { get; set; } = MultiRigResources.RigTypeTitle;
    public string PortTitle { get; set; } = MultiRigResources.PortTitle;
    public string BaudRateTitle { get; set; } = MultiRigResources.BaudRateTitle;
    public string DataBitsTitle { get; set; } = MultiRigResources.DataBitsTitle;
    public string ParityTitle { get; set; } = MultiRigResources.ParityTitle;
    public string StopBitsTitle { get; set; } = MultiRigResources.StopBitsTitle;
    public string RtsModeTitle { get; set; } = MultiRigResources.RtsModeTitle;
    public string DtrModeTitle { get; set; } = MultiRigResources.DtrModeTitle;
    public string PollMsTitle { get; set; } = MultiRigResources.PollMsTitle;
    public string TimeoutMsTitle { get; set; } = MultiRigResources.TimeoutMsTitle;

    #endregion

    #region Methods

    public override void ExecuteOkAction()
    {
        AllRigsSettings.SaveSettings();
        Owner.Close();
    }

    public override void ExecuteCancelAction()
    {
        Owner.Close(DialogResult.Cancel);
    }

    public void ExecuteRefreshComPortsAction()
    {
        AllPorts.Clear();
        _knownComPorts = ComPortHelper.EnumerateComPorts();
        AllPorts.AddRange(_knownComPorts);
        OnPropertyChanged(nameof(AllPorts));
    }

    #endregion
}

public class DesignMultiRigWindowViewModel : MultiRigWindowViewModel
{
    public DesignMultiRigWindowViewModel()
    {
        var rig1 = new RigSettings
        {
            RigId = "RIG1",
            RigType = "Kenwood TS-2000",
            Port = ComPortInfo.None,
        };
        AllRigs.Add(rig1);
        AllRigs.Add(new RigSettings { RigId = "RIG2", });

        AllCommands.Add("Kenwood TS-2000");
        AllCommands.Add("Icom IC-705");

        AllPorts.AddRange(new[]
        {
                new ComPortInfo
                {
                    Caption = "",
                    Description = ComPortInfo.None,
                    Name = ComPortInfo.None,
                },
                new ComPortInfo
                {
                    Caption = "(COM1)",
                    Description = "COM1",
                    Name = "COM1",
                },
            });

        SelectedRigIndex = 0;

        SelectedRig = rig1;
    }
}

