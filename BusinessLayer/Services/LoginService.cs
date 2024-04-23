using BusinessLayer.Dto_s;
using BusinessLayer.Helpers;
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
                var response = await _repo.Get(dto.Username);
                var result = dto.Password.Verify(response.SaltHex, response.Password);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Register(LoginCredentialsDTO dto)
        {
            try
            {
                if (await CheckUserExists(dto.Username))
                {
                    var hashReponse = dto.Password.Hash();
                    var registerDto = MappingHelper.CredentialDtoMapper(dto, hashReponse.SaltHex);
                    var user = MappingHelper.UserMapper(registerDto, hashReponse.Hash);

                    await _repo.Add(user);
                }
                else
                {
                    throw new Exception("Account already exsists");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<bool> CheckUserExists(string username)
        {
            var userEntity = await _repo.Get(username);
            return userEntity == null;
        }
    }
}
