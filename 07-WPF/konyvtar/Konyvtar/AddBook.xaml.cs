using System.Windows;
using System.Windows.Controls;

namespace Konyvtar
{
    public partial class AddBook : UserControl
    {
        private readonly MainWindow _mainWindow;

        public AddBook(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) =>
            _mainWindow.GoToListBooksPage();

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleTextBox.Text;
            string author = AuthorTextBox.Text;

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author))
            {
                MessageBox.Show("A mezők kitöltése kötelező.",
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            _mainWindow.AddBook(title, author);
        }
    }
}
