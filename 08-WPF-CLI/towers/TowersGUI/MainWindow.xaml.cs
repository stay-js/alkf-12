using System.Windows;
using System.Windows.Controls;

namespace TowersGUI
{
    public partial class MainWindow : Window
    {
        private int _size => int.Parse(Size.SelectedItem.ToString() ?? "0");

        public MainWindow()
        {
            InitializeComponent();

            Size.ItemsSource = Enumerable.Range(3, 4);
            Size.SelectedIndex = 0;

            CheckButton.IsEnabled = false;
            CalculateButton.IsEnabled = false;
        }

        private void SetUpButton_Click(object sender, RoutedEventArgs e)
        {
            Output.Children.Clear();
            Output.ColumnDefinitions.Clear();
            Output.RowDefinitions.Clear();

            int size = _size + 2;

            for (int i = 0; i < size; i++)
            {
                Output.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(60) });
                Output.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int[] firstOrLast = [0, size - 1];

                    if (firstOrLast.Contains(i) && firstOrLast.Contains(j)) continue;

                    var tb = new TextBox
                    {
                        Height = 20,
                        Margin = new Thickness(5, 0, 5, 0),
                        VerticalAlignment = VerticalAlignment.Center,
                    };

                    if (firstOrLast.Contains(i) || firstOrLast.Contains(j)) tb.IsEnabled = false;

                    Grid.SetRow(tb, i);
                    Grid.SetColumn(tb, j);
                    Output.Children.Add(tb);
                }
            }

            CheckButton.IsEnabled = true;
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            var fields = Output.Children.OfType<TextBox>().Where(x => x.IsEnabled);

            if (fields.Any(x => string.IsNullOrWhiteSpace(x.Text)))
            {
                MessageBox.Show("A játékterület minden mezőjét ki kell tölteni!");
                return;
            }

            if (fields.Any(x => !int.TryParse(x.Text, out int value) || value < 1 || value > _size))
            {
                MessageBox.Show("A kitöltés nem felel meg a szabályoknak!");
                return;
            }

            if (Enumerable.Range(1, _size)
                .Any(i => CheckDuplicates(GetNumbersInRow(i))
                || CheckDuplicates(GetNumbersInColumn(i))))
            {
                MessageBox.Show("A kitöltés nem felel meg a szabályoknak!");
                return;
            }

            CalculateButton.IsEnabled = true;
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= _size; i++)
            {
                int[] rowNumbers = GetNumbersInRow(i);
                int[] colNumbers = GetNumbersInColumn(i);

                GetTextBoxAt(0, i).Text = CountVisibleTowers(rowNumbers).ToString();
                GetTextBoxAt(_size + 1, i).Text = CountVisibleTowers(rowNumbers.Reverse().ToArray()).ToString();

                GetTextBoxAt(i, 0).Text = CountVisibleTowers(colNumbers).ToString();
                GetTextBoxAt(i, _size + 1).Text = CountVisibleTowers(colNumbers.Reverse().ToArray()).ToString();
            }
        }

        private int[] GetNumbersInRow(int row)
        {
            return Output.Children.OfType<TextBox>()
                .Where(x => Grid.GetRow(x) == row && Grid.GetColumn(x) > 0 && Grid.GetColumn(x) <= _size)
                .Select(x => int.Parse(x.Text)).ToArray();
        }

        private int[] GetNumbersInColumn(int col) => Output
            .Children
            .OfType<TextBox>()
            .Where(x => Grid.GetColumn(x) == col && Grid.GetRow(x) > 0 && Grid.GetRow(x) <= _size)
            .Select(x => int.Parse(x.Text)).ToArray();


        private TextBox GetTextBoxAt(int row, int col) => Output
            .Children
            .OfType<TextBox>()
            .First(x => Grid.GetRow(x) == row && Grid.GetColumn(x) == col);

        private static bool CheckDuplicates(int[] heights) => heights
            .GroupBy(x => x)
            .Any(g => g.Count() > 1);

        private static int CountVisibleTowers(int[] heights)
        {
            int max = 0;
            int count = 0;

            foreach (int h in heights)
            {
                if (h > max)
                {
                    max = h;
                    count++;
                }
            }

            return count;
        }
    }
}
