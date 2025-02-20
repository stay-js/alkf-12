using System.Net.Mail;

namespace Tarskereso_Lib
{
    public static partial class Validator
    {
        public static bool ValidateAge(DateTime? dateOfBirth) => dateOfBirth <= DateTime.Now.AddYears(-18);

        public static bool ValidateEmail(string email) => MailAddress.TryCreate(email, out _);
    }
}
