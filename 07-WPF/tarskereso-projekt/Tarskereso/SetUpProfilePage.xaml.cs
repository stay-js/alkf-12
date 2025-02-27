using System.IO;
using System.Windows;
using Tarskereso_Lib;

namespace Tarskereso
{
    public partial class SetUpProfilePage
    {
        public SetUpProfilePage() => InitializeComponent();

        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            string[] interests = InterestsTextBox.Text.Split(',').Select(x => x.Trim()).ToArray();
            var gender = MaleRadioButton.IsChecked == true ? Gender.Male : Gender.Female;

            GenderPreference genderPreference;

            if (BothPreferenceRadioButton.IsChecked == true)
                genderPreference = GenderPreference.Both;
            else if (MalePreferenceRadioButton.IsChecked == true)
                genderPreference = GenderPreference.Male;
            else
                genderPreference = GenderPreference.Female;

            if (string.IsNullOrEmpty(InterestsTextBox.Text))
            {
                MessageBox.Show("Please fill in all fields.",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            File.AppendAllText("out.txt", ";" +
                string.Join(";", gender, genderPreference, string.Join(",", interests)));

            MessageBox.Show("Sign Up Successful.",
                "Success",
                MessageBoxButton.OK,
                MessageBoxImage.Information);

            Environment.Exit(0);
        }
    }
}
