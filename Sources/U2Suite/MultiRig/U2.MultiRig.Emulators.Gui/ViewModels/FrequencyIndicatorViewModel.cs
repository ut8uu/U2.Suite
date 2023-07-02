using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Input;

namespace U2.MultiRig.Emulators.Gui;

public delegate void FrequencyChangedEventHandler(object sender, long frequency);

public class FrequencyIndicatorViewModel : ViewModelBase
{
    private UserControl _owner;
    private readonly List<UpDownDigit> _digits = new();
    private long _frequency;

    public event FrequencyChangedEventHandler FrequencyChanged;

    public UserControl Owner
    {
        get => _owner;
        set
        {
            _owner = value;

            _digits.Clear();
            var index = 0;
            while (true)
            {
                var control = _owner.FindControl<UpDownDigit>($"Digit{index}");
                if (control == null)
                {
                    break;
                }
                control.ValueChanged += UpDownDigit_OnFrequencyChanged;
                _digits.Add(control);
                index++;
            }

            var maxValue = (long)Math.Pow(10, _digits.Count);

            foreach (var digit in _digits)
            {
                digit.ViewModel.MaxValue = maxValue;
            }
        }
    }

    public long Frequency
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

    public int Width { get; set; } = 445;

    private void UpDownDigit_OnFrequencyChanged(object sender, ValueChangedEventArgs eventArgs)
    {
        Frequency = eventArgs.Value;
        OnFrequencyChanged(Frequency);
    }

    protected virtual void OnFrequencyChanged(long frequency)
    {
        FrequencyChanged?.Invoke(this, frequency);
    }
}

public class DemoFrequencyIndicatorViewModel : FrequencyIndicatorViewModel
{
    public DemoFrequencyIndicatorViewModel()
    {
        Frequency = 1234567890;
    }
}
