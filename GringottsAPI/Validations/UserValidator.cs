using GringottsAPI.Helpers;

namespace GringottsAPI.Validations
{
    public static class UserValidator
    {
        public static bool ValidatePassword(string userPassword, string passwordEntered)
        {
            string sha256Password = StringHelper.Sha256Hash(passwordEntered);

            return sha256Password == userPassword;
        }
    }
}
