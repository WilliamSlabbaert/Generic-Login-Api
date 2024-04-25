using BusinessLayer.Dto_s;

namespace BusinessLayer.Services.Interfaces
{
    public interface ILoginService
    {
        Task<string> Login(LoginCredentialsDTO dto);
        Task Register(LoginCredentialsDTO dto);
    }
}
