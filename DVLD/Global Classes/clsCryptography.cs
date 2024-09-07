using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Global_Classes
{
    internal class clsCryptography
    {
        public static string EncryptUsingHashing(string input)
        {
            // Create an instance of the SHA-256 algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Use StringBuilder to convert the byte array to a lowercase hexadecimal string
                StringBuilder hashString = new StringBuilder(hashBytes.Length * 2);

                foreach (byte b in hashBytes)
                {
                    hashString.AppendFormat("{0:x2}", b); // 'x2' formats each byte as a two-character hexadecimal value
                }

                return hashString.ToString();
            }
        }
    }
}
