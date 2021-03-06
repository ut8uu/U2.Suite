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
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading;
using Avalonia.Controls;
using U2.Contracts;

namespace U2.MultiRig.Emulators.Gui;

public class MainWindowViewModel : ViewModelBase, IDisposable
{
    public const string VfoA = "VFO A";
    public const string VfoB = "VFO B";

    private string _status;
    private string _selectedVfo = VfoA;
    private long _frequency = 438500000;

    private FrequencyIndicatorViewModel _frequencyIndicatorViewModel;
    private Window _owner;

    internal readonly GuestRig _guestRig;

    public MainWindowViewModel()
    {
        _frequency = FreqA;
        _selectedVfo = VfoA;

        if (this is MainWindowViewModel)
        {
            _guestRig = new GuestRig(1, KnownIdentifiers.U2MultiRigEmulatorGui);
            _guestRig.Enabled = true;
            _guestRig.Start();
        }
    }

    public long FreqA { get; set; } = 0;
    public long FreqB { get; set; } = 0;

    public string SelectedVfo
    {
        get => _selectedVfo;
        set
        {
            _selectedVfo = value;
            _frequency = _selectedVfo switch
            {
                VfoA => FreqA,
                VfoB => FreqB,
                _ => _frequency
            };

            if (_frequencyIndicatorViewModel != null)
            {
                _frequencyIndicatorViewModel.Frequency = _frequency;
            }

            ChangeStatus($"VFO changed to {value}");
        }
    }

    public ObservableCollection<string> VfoItems { get; } = new()
    {
        VfoA, VfoB,
    };

    public string SelectedMode { get; set; } = string.Empty;
    public ObservableCollection<string> Modes { get; } = new()
    {
        "AM", "FM", "USB", "LSB", "CW-L", "CW-U", "DIGI-L", "DIGI-R",
    };

    public long Frequency
    {
        get => _frequency;
        set
        {
            _frequency = value;
            switch (SelectedVfo)
            {
                case VfoA:
                    FreqA = value;
                    ChangeStatus($"VFO A frequency changed to {value}");
                    break;
                case VfoB:
                    FreqB = value;
                    ChangeStatus($"VFO B frequency changed to {value}");
                    break;
            }
        }
    }

    private void ChangeStatus(string message)
    {
        Status = message;
        OnPropertyChanged(nameof(Status));
    }

    public string Status
    {
        get => _status;
        set
        {
            _status = value;
        }
    }

    public Window Owner
    {
        get => _owner;
        set
        {
            _owner = value;
            _frequencyIndicatorViewModel = (FrequencyIndicatorViewModel)
                _owner.FindControl<FrequencyIndicator>("FrequencyIndicator").DataContext;
            Debug.Assert(_frequencyIndicatorViewModel != null, "A FrequencyIndicator not found.");
            _frequencyIndicatorViewModel.FrequencyChanged += FrequencyIndicator_OnFrequencyChanged;
        }
    }

    private void FrequencyIndicator_OnFrequencyChanged(object sender, long frequency)
    {
        _frequency = frequency;
        ChangeStatus($"A frequency changed to {frequency}");

        switch (SelectedVfo)
        {
            case VfoA:
                FreqA = frequency;
                break;
            case VfoB:
                FreqB = frequency;
                break;
        }
    }

    public void ExecuteExitCommand()
    {
        Owner?.Close();
    }

    public void Dispose()
    {
        if (_guestRig != null)
        {
            _guestRig.Enabled = false;
            _guestRig.Stop();
        }

        _guestRig?.Dispose();
    }
}

public class DemoMainWindowViewModel : MainWindowViewModel
{
    public DemoMainWindowViewModel()
    {
        Frequency = 1234567890;
        FreqA = 14125300;
        FreqB = 21450250;
        Status = "Connected";
    }
}
