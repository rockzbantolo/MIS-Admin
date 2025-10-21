using System.Security.Cryptography;
using System.Text;

namespace MIS_Admin.Model
{
    public class Authenticate
    {
        public readonly string SystemPassword = "XNX951";
        private readonly string initVector = "1234567890123456";
        private readonly int keysize = 256;

        public string EncryptString(string plainText)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            using (var password = new PasswordDeriveBytes(SystemPassword, null))
            using (var symmetricKey = new RijndaelManaged())
            {
                symmetricKey.Mode = CipherMode.CBC;
                symmetricKey.Padding = PaddingMode.PKCS7;

                byte[] keyBytes = password.GetBytes(keysize / 8);

                using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
                using (var memoryStream = new MemoryStream())
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }

        public class UserSession
        {
            public int UserID { get; set; }
            public string? UserName { get; set; }
            public string? Password { get; set; }
            public string? FullName { get; set; }
            public string? Role { get; set; }
        }
    }
}
