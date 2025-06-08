using System.Windows;
using System.Windows.Controls;
using VasutvonalakLib;

namespace VasutvonalakGUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataStore.Initialize();
            InitializeComponent();

            LineComboBox.ItemsSource = DataStore.Instance?.Lines;
        }

        private void ResetGUI()
        {
            DataGrid.Visibility = Visibility.Collapsed;
            StationComboBox.ItemsSource = null;
            StationComboBox.IsEnabled = false;
        }

        private void LineComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ResetGUI();

            if (LineComboBox.SelectedItem is not Line line) return;
            var stations = line.GetStations();

            if (!stations.Any()) return;

            StationComboBox.ItemsSource = stations.OrderBy(x => x.GetDistance(line.Id));
            StationComboBox.IsEnabled = true;
        }

        private void StationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StationComboBox.SelectedItem is not Station station) return;
            if (LineComboBox.SelectedItem is not Line line) return;

            TypeTextBox.Text = station.Type;
            CountryTextBox.Text = station.Country;
            DistanceTextBox.Text = station.GetDistance(line.Id).ToString();
            ActiveCheckBox.IsChecked = station.Active;

            DataGrid.Visibility = Visibility.Visible;
        }
    }
}
