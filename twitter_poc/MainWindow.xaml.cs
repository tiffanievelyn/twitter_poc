using System.Windows;

using twitter_poc.ViewModel;

namespace twitter_poc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Twitter _twitter;

        public MainWindow()
        {
            InitializeComponent();

            _twitter = new Twitter();
            this.DataContext = _twitter;
        }
        
    }
}
