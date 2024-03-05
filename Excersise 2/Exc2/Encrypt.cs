namespace Exc2;

using System.Security.Cryptography;
using System.Text;

public static class Encrypt
{
    public static string Run(string message, string passkey, string encryptionMethod)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Encoding.UTF8.GetBytes(passkey);
            aesAlg.Mode = Misc.CipherModeFromString(encryptionMethod);

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);

                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(message);
                    }
                }
                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }
    }
}