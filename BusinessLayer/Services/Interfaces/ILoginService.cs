using BusinessLayer.Dto_s;

namespace BusinessLayer.Services.Interfaces
{
    public interface ILoginService
    {
        string Login(LoginCredentialsDTO dto);
    }
}
