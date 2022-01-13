using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.Suite
{
    public partial class ContributorsWindow : Window
    {
        public ContributorsWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            var viewModel = new ContributorsViewModel();
            FillContributors(viewModel.ContributorsCollection);
            DataContext = viewModel;
        }

        private void FillContributors(ObservableCollection<ContributorInfo> contributors)
        {
            contributors.Add(new ContributorInfo("Sergey Usmanov, UT8UU", "Idea, design, development."));
            contributors.Add(new ContributorInfo("Daria Usmanova", "Graphics, icons, UI/UX."));
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
