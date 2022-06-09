using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using ReactiveUI.Fody.Helpers;

namespace U2.MultiRig.Emulators.Gui;

public class FrequencyIndicatorViewModel
{
    private UserControl _owner;
    private readonly List<UpDownDigit> _digits = new();
    private int _frequency;

    public UserControl Owner
    {
        get => _owner;
        set
        {
            _owner = value;

            _digits.Clear();
            for (var i = 0; i < 10; i++)
            {
                var control = _owner.FindControl<UpDownDigit>($"Digit{i}");
                Debug.Assert(control != null, $"An UpDownDigit control Digit{i} not found.");
                control.ValueChanged += ControlOnFrequencyChanged;
                _digits.Add(control);
            }
        }
    }

    private void ControlOnFrequencyChanged(object sender, ValueChangedEventArgs eventArgs)
    {
        Frequency = eventArgs.Value;
    }

    [Reactive]
    public int Frequency
    {
        get => _frequency;
        set
        {
            _frequency = value;
            foreach (var digit in _digits)
            {
                digit.Frequency = value;
            }
        }
    }

    [Reactive] 
    public int Width { get; set; } = 450;

    public void ValueChanged(object sender, ValueChangedEventArgs eventArgs)
    {
        Frequency = eventArgs.Value;
    }
}

public class DemoFrequencyIndicatorViewModel : FrequencyIndicatorViewModel
{
    public DemoFrequencyIndicatorViewModel()
    {
        Frequency = 1234567890;
    }
}
