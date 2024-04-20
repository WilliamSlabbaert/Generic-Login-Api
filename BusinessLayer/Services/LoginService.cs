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

            try
            {
                //var response = await _repo.Get(dto.Username, dto.Password);
                //var hash = response.Password.Hash();

                //return response.Password.Verify(hash.SaltHex, hash.Hash);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
