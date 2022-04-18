using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaloniaEdit.Utils;
using U2.CommonControls;
using U2.MultiRig.Code;

namespace U2.MultiRig.ViewModels
{
    public class MultiRigWindowViewModel : WindowViewModelBase
    {
        public MultiRigWindowViewModel()
        {
            AllRigsSettings.LoadSettings();
            AllRigs = new ObservableCollection<RigSettings>(AllRigsSettings.AllRigs);
            SelectedRig = AllRigs.First();
            SelectedRigIndex = 0;
        }

        public string SelectRigTitle { get; set; } = "Select rig";

        public ObservableCollection<RigSettings> AllRigs { get; }
        public ObservableCollection<RigCommand> AllCommands { get; } = new();
        public ObservableCollection<string> AllPorts { get; } = new();
        public ObservableCollection<int> AllBaudRates { get; } = new(Data.BaudRates);

        public ObservableCollection<Data.Parity> AllParities { get; } = new(
            new[]
            {
                Data.Parity.None,
                Data.Parity.Odd,
                Data.Parity.Even,
                Data.Parity.Mark,
                Data.Parity.Space,
            });

        public ObservableCollection<int> AllDataBits { get; } = new(Data.DataBits);
        public ObservableCollection<decimal> AllStopBits { get; } = new(Data.StopBits);
        public ObservableCollection<Data.RtsMode> AllRtsModes { get; } = new(new[]
        {
            Data.RtsMode.High, Data.RtsMode.Low, Data.RtsMode.Handshake,
        });
        public ObservableCollection<Data.DtrMode> AllDtrModes { get; } = new(new[]
        {
            Data.DtrMode.High, Data.DtrMode.Low,
        });

        public int SelectedRigIndex { get; set; }
        public RigSettings? SelectedRig { get; set; }

        #region Titles

        public string RigIdTitle { get; set; } = MultiRigResources.RigIdTitle;
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
    }

    public class DesignMultiRigWindowViewModel : MultiRigWindowViewModel
    {
        public DesignMultiRigWindowViewModel()
        {
            var rig1 = new RigSettings
            {
                RigId = "RIG1", 
                RigType = 0,
                Port = 0,
            };
            AllRigs.Add(rig1);
            AllRigs.Add(new RigSettings { RigId = "RIG2", });

            AllCommands.Add(new RigCommand { Title = "Kenwood TS-2000" });
            AllCommands.Add(new RigCommand { Title = "Icom IC-705" });

            AllPorts.AddRange(new[] {"NONE", "COM1", "COM2"});

            SelectedRigIndex = 0;

            SelectedRig = rig1;
        }
    }
}
