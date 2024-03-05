namespace Exc2;

using System.Security.Cryptography;
using System.Text;

public class Decrypt
{
    public static string Run(string filePath, string passkey, string encryptionMethod)
    {
        string encryptedText = File.ReadAllText(filePath);
        byte[] cipherText = Convert.FromBase64String(encryptedText);

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Encoding.UTF8.GetBytes(passkey);
            aesAlg.Mode = Misc.CipherModeFromString(encryptionMethod);

            byte[] iv = new byte[aesAlg.BlockSize / 8];
            Array.Copy(cipherText, 0, iv, 0, iv.Length);
            aesAlg.IV = iv;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(cipherText, iv.Length, cipherText.Length - iv.Length))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }
}