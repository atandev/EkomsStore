using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EkomsStore.Application.Utilities
{
    public class PasswordSecurityHelper
    {
        public static bool CheckPassword(string password, string loginPassword)
        {
            return password == loginPassword ? true : false;
        }

        public static string GenerateSalt()
        {
            var buffer = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(buffer);
            return Convert.ToBase64String(buffer);
        }

        public static string CalculateHash(string stringToHash, string salt)
        {
            var cryptoValue = $"{salt}{stringToHash}";
            using (SHA256 sha = new SHA256CryptoServiceProvider())
            {
                byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(cryptoValue));
                // Convert to hex string and remove dashes - e.g. "80-10-F0" -> "8010F0"
                return (BitConverter.ToString(hash)).Replace("-", "");
            }
        }
    } 
}
