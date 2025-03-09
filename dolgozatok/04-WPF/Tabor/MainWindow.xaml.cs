using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Tabor
{
    public partial class MainWindow : Window
    {
        private readonly Dictionary<string, string[]> _languages;

        public MainWindow()
        {
            _languages = ReadLanguages("nyelv.csv");

            InitializeComponent();
            ResetForm();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Adja meg a jelentkező nevét!",
                    "Hiba!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            string line = string.Join(';',
                name,
                LevelComboBox.SelectedValue,
                LanguageComboBox.SelectedValue,
                SleepInCheckBox.IsChecked == true ? "igen" : "nem",
                MaleRadioButton.IsChecked == true ? "fiú" : "lány");

            File.AppendAllText("jelentkezok.txt", $"{line}\n");
            ResetForm();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) => ResetForm();

        private void LevelComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string level = LevelComboBox.SelectedValue.ToString() ?? "";

            if (_languages.TryGetValue(level, out string[]? languages))
            {
                LanguageComboBox.ItemsSource = languages;
                LanguageComboBox.SelectedIndex = 0;
            }
        }

        private void ResetForm()
        {
            NameTextBox.Text = string.Empty;
            LevelComboBox.ItemsSource = new string[] { "kezdő", "középhaladó", "haladó" };
            LevelComboBox.SelectedIndex = 0;
            SleepInCheckBox.IsChecked = false;
            MaleRadioButton.IsChecked = true;
            FemaleRadioButton.IsChecked = false;
        }

        private static Dictionary<string, string[]> ReadLanguages(string fileName)
        {
            return File
                .ReadAllLines(fileName)
                .Skip(1)
                .Select(line => line.Split(';'))
                .GroupBy(x => x[0], x => x[1])
                .ToDictionary(x => x.Key, x => x.Order().ToArray());
        }
    }
}
