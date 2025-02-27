using System.Windows;
using System.Windows.Controls;

namespace SudokuGUI
{
    public partial class MainWindow : Window
    {
        private int _size = 4;

        public MainWindow()
        {
            InitializeComponent();
            UpdateUI();
        }

        private void MinButton_Click(object sender, RoutedEventArgs e)
        {
            if (_size > 4) _size--;
            UpdateUI();
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            if (_size < 9) _size++;
            UpdateUI();
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            int length = StartingStateTextBox.Text.Length;
            int correctLength = _size * _size;

            if (length == correctLength)
            {
                MessageBox.Show("A feladvány megfelelő hosszúságú!",
                    "Info",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return;
            }

            if (length > correctLength)
            {
                MessageBox.Show($"A feladvány hosszú: törlendő {length - correctLength} számjegy!",
                    "Info",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return;
            }

            MessageBox.Show($"A feladvány rövid: kell még {correctLength - length} számjegy!",
                "Info",
                MessageBoxButton.OK,
                MessageBoxImage.Information);

        }

        private void StartingStateTextBox_TextChanged(object sender, TextChangedEventArgs e) =>
            UpdateUI();

        private void UpdateUI()
        {
            SizeTextBox.Text = _size.ToString();
            LengthTextBlock.Text = $"Hossz: {StartingStateTextBox.Text.Length}";
        }
    }
}
