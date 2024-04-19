using BusinessLayer.Dto_s;
using BusinessLayer.Services.Interfaces;
using DataLayer.Repo.Interfaces;


namespace BusinessLayer.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepo _repo;
        public LoginService(IUserRepo repo)
        {
            _repo = repo;
        }
        public async Task<bool> Login(LoginCredentialsDTO dto)
        {
            var response = await _repo.Get(dto.Username, dto.Password);
            return response is not null;
        }
    }
}
