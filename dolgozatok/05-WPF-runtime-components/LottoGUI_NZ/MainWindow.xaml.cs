using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LottoGUI_NZ
{
    public partial class MainWindow : Window
    {
        private const int ITEM_SIZE = 30;

        private readonly List<int> _selected = [];

        private int GameType
        {
            get
            {
                if (Type0RadioButton.IsChecked == true) return 0;
                if (Type1RadioButton.IsChecked == true) return 1;
                return 2;

            }
        }

        private int MaxSelected => GameType + 5;

        private int Max => GameType switch
        {
            0 => 90,
            1 => 45,
            _ => 35,
        };

        public MainWindow()
        {
            InitializeComponent();
            Type1RadioButton.IsChecked = true;
        }

        public void SetUpGridForCurrentGameType()
        {
            switch (GameType)
            {
                case 0:
                    SetUpGrid(9, 10);
                    break;
                case 1:
                    SetUpGrid(5, 9);
                    break;
                case 2:
                    SetUpGrid(5, 7);
                    break;
                default:
                    throw new UnreachableException();
            }
        }

        public void SetUpGrid(int rows, int columns)
        {
            NumbersGrid.RowDefinitions.Clear();
            NumbersGrid.ColumnDefinitions.Clear();
            NumbersGrid.Children.Clear();

            for (int i = 0; i < rows; i++)
            {
                NumbersGrid.RowDefinitions.Add(new RowDefinition
                {
                    Height = new GridLength(ITEM_SIZE)
                });
            }

            for (int i = 0; i < columns; i++)
            {
                NumbersGrid.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = new GridLength(ITEM_SIZE)
                });
            }

            int number = 1;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    var item = new Label
                    {
                        Content = number++.ToString(),
                        Width = ITEM_SIZE,
                        Height = ITEM_SIZE,
                        Padding = new Thickness(0),
                        VerticalContentAlignment = VerticalAlignment.Center,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                    };

                    item.MouseDown += NumberMouseDown;

                    Grid.SetRow(item, i);
                    Grid.SetColumn(item, j);

                    NumbersGrid.Children.Add(item);
                }
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            _selected.Clear();
            PollButton.IsEnabled = false;
            Output.Text = string.Empty;
            SetUpGridForCurrentGameType();
        }

        private void PollButton_Click(object sender, RoutedEventArgs e)
        {
            HashSet<int> selected = [];

            while (selected.Count < MaxSelected)
            {
                selected.Add(Random.Shared.Next(1, Max + 1));
            }

            Output.Text = $"A kihúzott számok: {string.Join(", ", selected.Order())}" +
                $"\n\nTalálatok száma: {selected.Intersect(_selected).Count()}";
        }

        private void NumberMouseDown(object sender, RoutedEventArgs e)
        {
            if (sender is not Label label) return;

            int number = int.Parse(label.Content.ToString()!);

            if (_selected.Contains(number))
            {
                label.Background = Brushes.White;
                _selected.Remove(number);
            }
            else if (_selected.Count < MaxSelected)
            {
                label.Background = Brushes.LightGreen;
                _selected.Add(number);
            }

            PollButton.IsEnabled = _selected.Count == MaxSelected;
        }
    }
}
