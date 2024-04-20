namespace DataLayer.HelperModels
{
    public class Credentials
    {

        public string Username { get; private set; }
        public string Password { get; private set; }

        public Credentials(string username, string password)
        {
            Username = username;
            Password = password;
        }

        protected void SetUserName(string user)
        {
            this.Username = user;
        }
        protected void SetPassword(string pass)
        {
            this.Password = pass;
        }
    }
}
