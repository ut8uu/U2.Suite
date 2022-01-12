using System.Collections.ObjectModel;

namespace U2.Suite
{
    public sealed class ContributorsViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ContributorInfo> contributorsCollection 
            = new ObservableCollection<ContributorInfo>();

        public ObservableCollection<ContributorInfo> ContributorsCollection => contributorsCollection;
    }
}
