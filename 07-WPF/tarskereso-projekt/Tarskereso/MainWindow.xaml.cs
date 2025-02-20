using System.Windows;

namespace Tarskereso
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContent.Content = new SignUpPage(this);
        }

        public void GoToSetUpProfilePage() => MainContent.Content = new SetUpProfilePage();
    }
}
