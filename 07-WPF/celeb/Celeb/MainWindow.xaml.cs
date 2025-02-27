using Celeb_Lib;
using System.IO;
using System.Windows;

namespace Celeb
{
    public partial class MainWindow : Window
    {
        private readonly IEnumerable<Person> _people;

        public MainWindow()
        {
            _people = ReadPeople();

            InitializeComponent();
            LoadNationalities();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Adja meg a híres ember nevét!",
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            string line = string.Join(';',
                name,
                JobComboBox.Text,
                NationalityComboBox.Text,
                WorldFamousCheckBox.IsChecked == true ? "igen" : "nem",
                MaleRadioButton.IsChecked == true ? "férfi" : "nő");

            File.AppendAllText("hires.txt", $"{line}\n");
            ResetForm();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) => ResetForm();

        private void LoadNationalities()
        {
            NationalityComboBox.ItemsSource = _people
                .Select(x => x.Nationality)
                .Distinct()
                .Order();

            NationalityComboBox.SelectedIndex = 0;
        }

        private void ResetForm()
        {
            NameTextBox.Text = string.Empty;
            JobComboBox.SelectedIndex = 0;
            NationalityComboBox.SelectedIndex = 0;
            WorldFamousCheckBox.IsChecked = false;
            MaleRadioButton.IsChecked = true;
            FemaleRadioButton.IsChecked = false;
        }

        private static IEnumerable<Person> ReadPeople() => File
            .ReadAllLines("hires.txt")
            .Skip(1)
            .Select(x => new Person(x));
    }
}