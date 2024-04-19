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
        public string Login(LoginCredentialsDTO dto)
        {
            _repo.Get();
            return "test";
        }
    }
}
