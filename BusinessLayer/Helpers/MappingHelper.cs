using BusinessLayer.Dto_s;
using BusinessLayer.Models;
using DataLayer.Entities;

namespace BusinessLayer.Helpers
{
    internal static class MappingHelper
    {
        internal static User UserMapper(UserModel model, string saltHex)
        {
            var result = new User()
            {
                Id = model.Id,
                Password = model.Password,
                Username = model.Username,
                SaltHex = saltHex
            };
            return result;
        }
        internal static User UserMapper(RegisterCredentialsDTO dto, string newPassword)
        {
            var userModel = new UserModel()
            {
                Password = newPassword,
                Username = dto.Username,
            };
            return UserMapper(userModel, dto.SaltHex);
        }

        internal static UserModel UserMapper(User entity)
        {
            var result = new UserModel()
            {
                Id = entity.Id,
                Password = entity.Password,
                Username = entity.Username
            };
            return result;
        }

        internal static RegisterCredentialsDTO CredentialDtoMapper(LoginCredentialsDTO dto, string salthex)
        {
            var result = new RegisterCredentialsDTO()
            {
                SaltHex = salthex,
                Password = dto.Password,
                Username = dto.Username,
            };
            return result;
        }
    }
}
