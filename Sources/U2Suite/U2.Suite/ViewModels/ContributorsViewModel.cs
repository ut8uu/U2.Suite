using System.Collections.ObjectModel;

namespace U2.Suite
{
    public sealed class ContributorsViewModel : ViewModelBase
    {
        public ObservableCollection<ContributorInfo> ContributorsCollection { get; } 
            = new ObservableCollection<ContributorInfo>();
    }
}
