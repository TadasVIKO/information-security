using System.Numerics;

namespace Exc3;

public static class Decrypt
{
    public static string run(string filePath, int privateKey, int[] publicKey)
    {
        string[] encryptedText = File.ReadAllText(filePath).Split(" ");
        
        string plainText = "";
        int index = 1;

        foreach (var i in encryptedText)
        {
            if (!string.IsNullOrWhiteSpace(i) && int.TryParse(i, out int num))
            {
                Console.WriteLine("Number: " + index + " Equation: " + num + " ^ " + privateKey + " % " + publicKey[0]);
                BigInteger charText = BigInteger.ModPow(num, privateKey, publicKey[0]);
                plainText += (char)charText;
                index += 1;
            }
        }

        return plainText;
    }
}