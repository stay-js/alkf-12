using System.Windows;
using System.Windows.Controls;

namespace Konyvtar
{
    public partial class ListBooks : UserControl
    {
        private readonly MainWindow _mainWindow;

        public ListBooks(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        public void AddBook(string title, string author) =>
            BooksListView.Items.Add($"{title} - {author}");

        private void AddButton_Click(object sender, RoutedEventArgs e) =>
            _mainWindow.GoToAddBookPage();

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (BooksListView.SelectedItem is null)
            {
                MessageBox.Show("Nem jelölt ki törlendő elemet.",
                    "Figyelmeztetés",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            BooksListView.Items.Remove(BooksListView.SelectedItem);
        }
    }
}
