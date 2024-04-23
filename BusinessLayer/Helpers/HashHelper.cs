using System.Security.Cryptography;

namespace BusinessLayer.Helpers
{
    internal static class HashHelper
    {

        private const int SaltSize = 128 / 8;
        private const int KeySize = 256 / 8;
        private const int Iterations = 350000;
        private static readonly HashAlgorithmName DefaultAlgorithm = HashAlgorithmName.SHA256;

        internal static HashResponse Hash(this string credential, byte[] salt = null)
        {
            salt ??= RandomNumberGenerator.GetBytes(SaltSize);

            var myHash = Rfc2898DeriveBytes.Pbkdf2(credential, salt, Iterations, DefaultAlgorithm, KeySize);

            var HashHex = Convert.ToHexString(myHash);
            var SaltHex = Convert.ToHexString(salt);

            return new HashResponse(HashHex, SaltHex);
        }

        internal static bool Verify(this string credential, string salt, string hash)
        {
            var computedHash = credential.Hash(Convert.FromHexString(salt)).Hash;
            return computedHash == hash;
        }
    }
    internal class HashResponse
    {
        internal string Hash { get; private set; }
        internal string SaltHex { get; private set; }

        public HashResponse(string hash, string saltHex)
        {
            Hash = hash;
            SaltHex = saltHex;
        }
    }
}
