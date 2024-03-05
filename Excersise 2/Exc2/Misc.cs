namespace Exc2;

using System.Security.Cryptography;

public class Misc
{
    public static CipherMode CipherModeFromString(string mode)
    {
        switch (mode)
        {
            case "ECB":
                return CipherMode.ECB;
            case "CBC":
                return CipherMode.CBC;
            case "CFB":
                return CipherMode.CFB;
            default:
                throw new ArgumentException("Invalid encryption method.");
        }
    }
}