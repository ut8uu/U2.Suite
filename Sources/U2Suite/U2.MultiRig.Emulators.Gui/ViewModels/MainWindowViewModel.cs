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
using System.Text;
using Avalonia.Controls;

namespace U2.MultiRig.Emulators.Gui;

public class MainWindowViewModel : ViewModelBase
{
    private const string VfoA = "VFO A";
    private const string VfoB = "VFO B";

    private string _status;
    private string _selectedVfo = VfoA;
    private long _frequency = 438500000;

    public MainWindowViewModel()
    {
        _frequency = FreqA;
    }

    public long FreqA { get; set; } = 438500000;
    public long FreqB { get; set; } = 145500000;

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

            OnPropertyChanged(nameof(Frequency));
        }
    }

    public ObservableCollection<string> VfoItems { get; } = new()
    {
        VfoA, VfoB,
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
                    break;
                case VfoB:
                    FreqB = value;
                    break;
            }
        }
    }

    public string Status
    {
        get => _status;
        set
        {
            _status = value;
        }
    }

    public Window Owner { get; set; }

    public void ExecuteExitCommand()
    {
        Owner?.Close();
    }
}

public class DemoMainWindowViewModel : MainWindowViewModel
{
    public DemoMainWindowViewModel()
    {
        FreqA = 14125300;
        FreqB = 21450250;
        Status = "Loaded";
    }
}
