using System.Windows;
using System.Windows.Controls;

namespace Jatek
{
    public partial class AddGame : UserControl
    {
        private readonly MainWindow _mainWindow;

        public AddGame(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) =>
            _mainWindow.GoToListGamesPage();

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleTextBox.Text;
            string genre = GenreTextBox.Text;

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(genre))
            {
                MessageBox.Show("A mezők kitöltése kötelező.",
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            _mainWindow.AddGame(title, genre);
        }
    }
}
