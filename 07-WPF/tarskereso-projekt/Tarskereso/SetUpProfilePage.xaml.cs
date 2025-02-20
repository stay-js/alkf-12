using System.IO;
using System.Windows;

namespace Tarskereso
{
    public partial class SetUpProfilePage
    {
        private Gender? _gender;
        private GenderPreference? _genderPreference;

        public SetUpProfilePage() => InitializeComponent();

        private void RadioButtonMale_Checked(object sender, RoutedEventArgs e) => _gender = Gender.Male;
        private void RadioButtonFemale_Checked(object sender, RoutedEventArgs e) => _gender = Gender.Female;

        private void RadioButtonPreferenceMale_Checked(object sender, RoutedEventArgs e) =>
            _genderPreference = GenderPreference.Male;
        private void RadioButtonPreferenceFemale_Checked(object sender, RoutedEventArgs e) =>
            _genderPreference = GenderPreference.Female;
        private void RadioButtonPreferenceBoth_Checked(object sender, RoutedEventArgs e) =>
            _genderPreference = GenderPreference.Both;

        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            string[] interests = InterestsTextBox.Text.Split(',').Select(x => x.Trim()).ToArray();

            if (_gender is null
                || _genderPreference is null
                || string.IsNullOrEmpty(InterestsTextBox.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error");
                return;
            }

            File.AppendAllText("out.txt", ";" +
                string.Join(";", _gender, _genderPreference, string.Join(",", interests)));

            MessageBox.Show("Sign Up Successful.", "Success");
            Environment.Exit(0);
        }
    }
}
