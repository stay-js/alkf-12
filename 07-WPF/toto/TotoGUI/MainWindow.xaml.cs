using System.Windows;
using System.Windows.Controls;

namespace TotoGUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ResultsTextBox.Text = "12X12X12X12X12";
            UpdateUI();
        }

        private void ResultsTextBox_TextChanged(object sender, TextChangedEventArgs e) =>
            UpdateUI();

        private void UpdateUI()
        {
            CheckCharacterCount();
            CheckIncorrectCharacters();
            SetSaveButtonState();
        }

        private void CheckCharacterCount()
        {
            int length = ResultsTextBox.Text.Length;

            IncorrectCharacterCountCheckBox.IsChecked = length != 14;
            IncorrectCharacterCountCheckBox.Content =
                $"Nem megfelelő a karakterek száma ({length})";
        }

        private void CheckIncorrectCharacters()
        {
            char[] valid = ['1', '2', 'X'];
            char[] invalidChars = ResultsTextBox.Text.Where(x => !valid.Contains(x)).ToArray();

            InvalidCharactersInResultsCheckBox.IsChecked = invalidChars.Length != 0;
            InvalidCharactersInResultsCheckBox.Content =
                $"Helytelen karakterek az eredményben ({string.Join(';', invalidChars)})";
        }

        private void SetSaveButtonState() => SaveButton.IsEnabled =
            IncorrectCharacterCountCheckBox.IsChecked != true
            && InvalidCharactersInResultsCheckBox.IsChecked != true;
    }
}
