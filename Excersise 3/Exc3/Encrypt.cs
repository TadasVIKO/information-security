using System.Numerics;

namespace Exc3;

public static class Encrypt
{
    public static string run(string message, int[] publicKey)
    {
        string cypherText = "";

        foreach (var i in message)
        {
            BigInteger charText = BigInteger.ModPow(i, publicKey[1], publicKey[0]);
            cypherText += charText.ToString() + " ";
        }

        return cypherText;
    }
}