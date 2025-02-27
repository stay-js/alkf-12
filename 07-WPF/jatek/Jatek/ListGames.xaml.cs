using System.Windows;
using System.Windows.Controls;

namespace Jatek
{
    public partial class ListGames : UserControl
    {
        private readonly MainWindow _mainWindow;

        public ListGames(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        public void AddGame(string title, string author) =>
            GamesListView.Items.Add($"{title} - {author}");

        private void AddButton_Click(object sender, RoutedEventArgs e) =>
            _mainWindow.GoToAddGamePage();

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (GamesListView.SelectedItem is null)
            {
                MessageBox.Show("Nem jelölt ki törlendő elemet.",
                    "Figyelmeztetés",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            GamesListView.Items.Remove(GamesListView.SelectedItem);
        }
    }
}
