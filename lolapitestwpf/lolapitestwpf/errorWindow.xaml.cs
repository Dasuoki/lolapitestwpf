using System.Windows;

namespace lolapitestwpf
{
    /// <summary>
    /// Interaction logic for errorWindow.xaml
    /// </summary>
    public partial class errorWindow : Window
    {
        public errorWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
