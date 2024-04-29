using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace api.Service
{
    public class EncryptionService
    {
        private readonly string key;
        private readonly string iv;

        public EncryptionService()
        {
            // For simplicity, using hardcoded key and IV. In production, securely store and manage keys!
            key = "GmjmVSjB4lpZYmqN3jnMb/5KKyMjcMi/eD5VL1shY34=";
            iv = "gZF8UL2eCe0R9ohHJl/sOw==";
        }

        public string Encrypt(string plainText)
        {
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = Convert.FromBase64String(key);
                aesAlg.IV = Convert.FromBase64String(iv);

                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public string Decrypt(string cipherText)
        {
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = Convert.FromBase64String(key);
                aesAlg.IV = Convert.FromBase64String(iv);

                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (var msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
