using ForditoIrodaLib;
using System.Windows;
using System.Windows.Controls;

namespace ForditoIrodaGUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataStore.Initialize();

            if (DataStore.Instance is null) return;
            LanguageComboBox.ItemsSource = DataStore.Instance.Languages;
        }

        private void ResetGUI()
        {
            TranslatorComboBox.IsEnabled = false;
            TranslatorComboBox.ItemsSource = null;
            DataGrid.Visibility = Visibility.Collapsed;
        }

        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ResetGUI();

            var selectedLanguage = (Language)LanguageComboBox.SelectedItem;

            var translators = DataStore.Instance?.Translators
                .Where(x => x.LanguageId == selectedLanguage.Id);

            if (translators is null || !translators.Any()) return;

            TranslatorComboBox.ItemsSource = translators;
            TranslatorComboBox.DisplayMemberPath = "Name";
            TranslatorComboBox.IsEnabled = true;
        }

        private void TranslatorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedTeacher = (Translator)TranslatorComboBox.SelectedItem;
            if (selectedTeacher is null) return;

            PhoneTextBox.Text = selectedTeacher.PhoneNumber;
            EmailTextBox.Text = selectedTeacher.Email;
            TranslationFeeTextBox.Text = selectedTeacher.TranslationFee.ToString();
            DailyPagesTextBox.Text = selectedTeacher.DailyPages.ToString();

            DataGrid.Visibility = Visibility.Visible;
        }
    }
}
