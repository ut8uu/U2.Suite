namespace U2.Suite.Brandmeister.Win.UserControls
{
    public partial class StatusBar : UserControl
    {
        private int _counter;

        public StatusBar()
        {
            InitializeComponent();
        }

        internal void IncreaseCounter()
        {
            _counter++;
            Invoke(new Action(() =>
            {
                lblStatistics.Text = $"Received: {_counter}";
            }));
        }

        internal void SetStatus(string status)
        {
            lblConnectionStatus.Text = $"Connection Status: {status}";
        }
    }
}
