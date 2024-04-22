namespace BusinessLayer.Dto_s
{
    public class RegisterCredentialsDTO : LoginCredentialsDTO
    {
        public string SaltHex { get; set; }
    }
}
