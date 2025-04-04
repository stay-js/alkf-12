using Nyelviskola_Lib;
using System.Windows;
using System.Windows.Controls;

namespace Nyelviskola_GUI
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
            TeacherComboBox.IsEnabled = false;
            TeacherComboBox.ItemsSource = null;
            DataGrid.Visibility = Visibility.Collapsed;
        }

        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ResetGUI();

            var selectedLanguage = (Language)LanguageComboBox.SelectedItem;

            var teachers = DataStore.Instance?.Teachers
                .Where(t => t.LanguageID == selectedLanguage.ID);

            if (teachers is null || !teachers.Any()) return;

            TeacherComboBox.ItemsSource = teachers;
            TeacherComboBox.DisplayMemberPath = "Name";
            TeacherComboBox.IsEnabled = true;
        }

        private void TeacherComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedTeacher = (Teacher)TeacherComboBox.SelectedItem;
            if (selectedTeacher is null) return;

            PhoneTextBox.Text = selectedTeacher.PhoneNumber;
            EmailTextBox.Text = selectedTeacher.Email;
            HourlyRateTextBox.Text = selectedTeacher.HourlyRate.ToString();
            OnlineCheckBox.IsChecked = selectedTeacher.Net;
            DataGrid.Visibility = Visibility.Visible;
        }
    }
}
