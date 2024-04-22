using System.Security.Cryptography;

namespace BusinessLayer.Helpers
{
    internal static class HashHelper
    {
        internal static HashResponse Hash(this string credential, byte[] salt = null)
        {

            var saltSize = 128 / 8;
            var keySize = 256 / 8;
            var iterations = 350000;
            var hashAlgo = HashAlgorithmName.SHA256;

            salt ??= RandomNumberGenerator.GetBytes(saltSize);

            var myHash = Rfc2898DeriveBytes.Pbkdf2(credential, salt, iterations, hashAlgo, keySize);

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
