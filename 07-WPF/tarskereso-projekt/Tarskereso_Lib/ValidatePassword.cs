namespace Tarskereso_Lib
{
    public static partial class Validator
    {
        public static bool ValidatePassword(string password, string confrimPassword, out string? message)
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
