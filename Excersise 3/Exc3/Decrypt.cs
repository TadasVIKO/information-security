using System.Numerics;

namespace Exc3;

public static class Decrypt
{
    public static string run(string filePath, int privateKey, int[] publicKey)
    {
        string[] fullText = File.ReadAllText(filePath).Split(";;");
        
        string[] encryptedText = fullText[0].Split(" ");
        
        string plainText = "";

        foreach (var i in encryptedText)
        {
            if (!string.IsNullOrWhiteSpace(i) && int.TryParse(i, out int num))
            {
                BigInteger charText = BigInteger.ModPow(num, privateKey, publicKey[0]);
                plainText += (char)charText;
            }
        }

        return plainText;
    }
}