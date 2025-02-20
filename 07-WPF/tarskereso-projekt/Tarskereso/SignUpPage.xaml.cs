using System.IO;
using System.Windows;
using System.Windows.Controls;
using Tarskereso_Lib;

namespace Tarskereso
{
    public partial class SignUpPage
    {
        private readonly MainWindow _mainWindow;

        public SignUpPage(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;
            var dateOfBirth = DatePicker.SelectedDate;

            if (string.IsNullOrEmpty(name)
                || string.IsNullOrEmpty(email)
                || string.IsNullOrEmpty(password)
                || string.IsNullOrEmpty(confirmPassword)
                || dateOfBirth is null)
            {
                MessageBox.Show("Please fill in all fields.",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            if (!Validator.ValidateEmail(email))
            {
                MessageBox.Show("Please input a valid e-mail address.",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            if (!Validator.ValidatePassword(password, confirmPassword, out string? message))
            {
                MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!Validator.ValidateAge(dateOfBirth))
            {
                MessageBox.Show("You must be at least 18 years old!",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            if (TermsCheckBox.IsChecked != true)
            {
                MessageBox.Show("Please accept the terms and conditions.",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            File.WriteAllText("out.txt", string.Join(";", name, email, password, dateOfBirth));

            _mainWindow.GoToSetUpProfilePage();
        }
    }
}
