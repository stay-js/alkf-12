using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SeatLeon
{
    public partial class MainWindow : Window
    {
        private const int MIN = 1;
        private const int MAX = 6;

        private int _current = 1;

        public MainWindow()
        {
            InitializeComponent();

            ShowTechnicalData();
            UpdateImage();
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            if (_current == MIN) _current = MAX;
            else _current--;

            UpdateImage();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (_current == MAX) _current = MIN;
            else _current++;

            UpdateImage();
        }

        private void UpdateImage()
        {
            var uri = new Uri($"/images/{_current}.jpg", UriKind.Relative);
            CarImage.Source = new BitmapImage(uri);
        }

        private void ShowTechnicalData()
        {
            string[] data = File.ReadAllLines("data.txt");

            for (int i = 0; i < data.Length; i++)
            {
                var tb = new TextBlock()
                {
                    Text = data[i],
                    Foreground = Brushes.White,
                    FontSize = 14,
                    Padding = new Thickness(5),
                };

                if (i % 2 != 0)
                {
                    var color = (Color)ColorConverter.ConvertFromString("#3E3E3E");
                    tb.Background = new SolidColorBrush(color);
                }

                TechnicalData.Children.Add(tb);
            }
        }
    }
}
