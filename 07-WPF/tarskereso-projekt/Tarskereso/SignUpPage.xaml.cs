using System.IO;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;

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
                MessageBox.Show("Please fill in all fields.", "Error");
                return;
            }

            if (!MailAddress.TryCreate(email, out _))
            {
                MessageBox.Show("Please input a valid e-mail address.", "Error");
                return;
            }

            if (!ValidatePassword(password, confirmPassword, out string? message))
            {
                MessageBox.Show(message, "Error");
                return;
            }

            if (dateOfBirth > DateTime.Now.AddYears(-18))
            {
                MessageBox.Show("You must be at least 18 years old!", "Error");
                return;
            }

            File.WriteAllText("out.txt", string.Join(";", name, email, password, dateOfBirth));

            _mainWindow.GoToSetUpProfilePage();
        }

        private static bool ValidatePassword(string password, string confrimPassword, out string? message)
        {
            if (password != confrimPassword)
            {
                message = "Passwords doesn't match!";
                return false;
            }

            if (password.Length < 8)
            {
                message = "Password length must be at least 8!";
                return false;
            }

            message = null;
            return true;
        }
    }
}
