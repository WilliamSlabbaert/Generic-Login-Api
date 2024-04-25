using BusinessLayer.Dto_s;
using BusinessLayer.Helpers;
using BusinessLayer.Services.Interfaces;
using DataLayer.Repo.Interfaces;
using Microsoft.Extensions.Configuration;


namespace BusinessLayer.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepo _repo;
        private IConfiguration _configuration;
        public LoginService(IUserRepo repo, IConfiguration configuration)
        {
            _repo = repo;
            _configuration = configuration;
        }
        public async Task<string?> Login(LoginCredentialsDTO dto)
        {
            if (await CheckUserExists(dto.Username))
            {
                return null;
            }
            var response = await _repo.Get(dto.Username);
            var result = dto.Password.Verify(response.SaltHex, response.Password);

            var token = _configuration.GetJwtToken("User-Management");

            return result ? token : null;
        }

        public async Task Register(LoginCredentialsDTO dto)
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
        private async Task<bool> CheckUserExists(string username)
        {
            var userEntity = await _repo.Get(username);
            return userEntity == null;
        }
    }
}
