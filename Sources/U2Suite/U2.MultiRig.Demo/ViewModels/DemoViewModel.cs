using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using U2.CommonControls;
using U2.Core;

namespace U2.MultiRig.Demo.ViewModels
{
    public sealed class DemoViewModel : WindowViewModelBase
    {
        private Rig _rig;
        private bool _connected = false;
        private readonly ILog _logger = LogManager.GetLogger(typeof(DemoViewModel));

        public string ConnectButtonTitle { get; set; } = "Connect";
        public string FreqA { get; set; } = "0";
        public string FreqB { get; set; } = "0";

        public async Task ExecuteConfigureRigAction()
        {
            var configWindow = new MultiRigWindow();
            var dialogTask = configWindow.ShowDialog(Owner);
            await dialogTask;
        }

        public void ExecuteConnectRigAction()
        {
            _connected = !_connected;
            if (!_connected)
            {
                ConnectButtonTitle = "Connect";
                _rig.Stop();
            }
            else
            {
                ConnectButtonTitle = "Disconnect";
                var ports = ComPortHelper.EnumerateComPorts();
                var port = ports.FirstOrDefault(p =>
                    p.Description.Contains("ci-v", StringComparison.InvariantCultureIgnoreCase));

                var settings = new RigSettings
                {
                    BaudRate = 57600,
                    DataBits = 8,
                    DtrMode = 0,
                    RtsMode = 0,
                    Enabled = true,
                    Port = port.Name,
                    Parity = 0,
                    StopBits = 0,
                    PollMs = 500,
                    TimeoutMs = 3000,
                    RigType = "IC-705",
                    RigId = "ic705",
                };
                var rigCommands = AllRigCommands.RigCommands
                    .FirstOrDefault(rc => rc.RigType.Equals("IC-705"));

                _rig = new Rig(1, settings, rigCommands);
                _rig.RigParameterChanged += RigOnRigParameterChanged;
                _rig.Start();
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
