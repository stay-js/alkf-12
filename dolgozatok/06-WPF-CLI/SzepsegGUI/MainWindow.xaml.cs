using System.Windows;
using SzepsegLib;


namespace SzepsegGUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataStore.Initialize();

            ProfessionComboBox.ItemsSource = DataStore.Instance?.Professions;
        }

        private void ProfessionComboBox_SelectionChanged(object sender,
            System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var profession = (Profession)ProfessionComboBox.SelectedItem;
            if (profession is null) return;

            WorkerComboBox.ItemsSource = DataStore
                .Instance?
                .Workers
                .Where(x => x.ProfessionId == profession.Id);

            WorkerComboBox.DisplayMemberPath = "Name";
            WorkerComboBox.IsEnabled = true;
            WorkerLabel.IsEnabled = true;
            PhoneNumberTextBox.Text = string.Empty;
        }

        private void WorkerComboBox_SelectionChanged(object sender,
            System.Windows.Controls.SelectionChangedEventArgs e)
        {

            var worker = (Worker)WorkerComboBox.SelectedItem;
            if (worker is null) return;

            PhoneNumberTextBox.Text = worker.PhoneNumber;
        }
    }
}
