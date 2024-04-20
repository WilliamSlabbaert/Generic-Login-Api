namespace DataLayer.HelperModels
{
    public class RegisterCredentials : Credentials
    {
        public string SaltHex { get; private set; }

        public RegisterCredentials(string username, string pass, string saltHex) : base(username, pass)
        {
            SaltHex = saltHex;
            SetPassword(pass);
            SetUserName(username);
        }
    }
}
