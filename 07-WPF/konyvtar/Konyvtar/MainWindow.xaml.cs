using System.Windows;

namespace Konyvtar
{
    public partial class MainWindow : Window
    {
        private readonly ListBooks _listBooks;

        public MainWindow()
        {
            _listBooks = new ListBooks(this);

            InitializeComponent();
            GoToListBooksPage();
        }

        public void GoToAddBookPage() => MainContent.Content = new AddBook(this);
        public void GoToListBooksPage() => MainContent.Content = _listBooks;

        public void AddBook(string title, string author)
        {
            _listBooks.AddBook(title, author);
            GoToListBooksPage();
        }
    }
}
