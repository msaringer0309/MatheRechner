using MvvmCross.Platforms.Wpf.Views;

namespace MatheRechner.WpfApp.Views
{
    /// <summary>
    /// Interaktionslogik für MainView.xaml
    /// </summary>
    public partial class MainView : MvxWpfView
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
