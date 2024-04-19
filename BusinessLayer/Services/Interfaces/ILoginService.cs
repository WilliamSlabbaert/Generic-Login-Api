using BusinessLayer.Dto_s;

namespace BusinessLayer.Services.Interfaces
{
    public interface ILoginService
    {
        Task<bool> Login(LoginCredentialsDTO dto);
    }
}
