using System.Numerics;

namespace Decryptor;

public static class Decrypt
{
    private static int publicKey;
    private static int privateKey;
    
    public static string run(string filePath)
    {
        int f = 0;
        int e = 0;
        int n = 0;
        
        string[] textFromFile = File.ReadAllText(filePath).Split(";; ");
        string[] fne = textFromFile[1].Split(", ");

        int.TryParse(fne[0], out int fne_int);

        for (int i = 2; i <= fne_int; i++)
        {
            while (fne_int % i == 0)
            {
                bool isPrime = true;
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    if (e == 0)
                        e = i;
                    else
                        n = i;
                }
                fne_int /= i;
            }
        }
                
        findKeys(e, n);
        
        string[] encryptedPart = textFromFile[0].Split(" , ");
            
        string[] encryptedText = encryptedPart[1].Split(" ");
        
        string decryptedText = "";
        string plainText = "";

        foreach (var i in encryptedText)
        {
            if (!string.IsNullOrWhiteSpace(i) && int.TryParse(i, out int num))
            {
                BigInteger charText = BigInteger.ModPow(num, privateKey, publicKey);
                decryptedText += (char)charText;
            }
        }
        
        string[] text = encryptedPart[0].Split(" ");
        
        foreach (var i in text)
        {
            if (!string.IsNullOrWhiteSpace(i) && int.TryParse(i, out int num))
            {
                plainText += (char)num;
            }
        }
        
        if (decryptedText != plainText)
        {
            return "Does NOT match!";
        }
        
        return decryptedText;
    }

    private static void findKeys(int p, int q)
    {
        List<int> eList = new List<int>();

        int e = 0;

        int n = p * q;

        int fn = (p - 1) * (q - 1);

        for (int i = 0; i <= fn; i++)
        {
            if (i % p != 0 && i % q != 0 && i != 1)
            {
                eList.Add(i);
            }
        }

        foreach (var i in eList)
        {
            if (GCD(i, fn) == 1)
            {
                e = i;
                break;
            }
        }

        publicKey = n;
        privateKey = FindPrivate(e, fn);
    }
    
    private static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    
    private static int FindPrivate(int a, int b)
    {
        int b0 = b;
        int y = 0, x = 1;

        while (a > 1)
        {
            int q = a / b;
            int c = b;

            b = a % b;
            a = c;
            c = y;

            y = x - q * y;
            x = c;
        }

        if (x < 0)
        {
            x += b0;
        }

        return x;
    }
}