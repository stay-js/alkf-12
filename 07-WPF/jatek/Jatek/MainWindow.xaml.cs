using System.Windows;

namespace Jatek
{
    public partial class MainWindow : Window
    {
        private readonly ListGames _listGames;

        public MainWindow()
        {
            _listGames = new ListGames(this);

            InitializeComponent();
            GoToListGamesPage();
        }

        public void GoToAddGamePage() => MainContent.Content = new AddGame(this);
        public void GoToListGamesPage() => MainContent.Content = _listGames;

        public void AddGame(string title, string genre)
        {
            _listGames.AddGame(title, genre);
            GoToListGamesPage();
        }
    }
}
