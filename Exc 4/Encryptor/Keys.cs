namespace Encryptor;

public class Keys
{
    private int[] publicKey = new []{0, 0};
    private int privateKey;

    public int[] getPublicKey()
    {
        return publicKey;
    }
    
    public int getPrivateKey()
    {
        return privateKey;
    }

    public void findKeys(int p, int q)
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

        publicKey[0] = n;
        publicKey[1] = e;
        
        privateKey = FindPrivate(e, fn);
    }
    
    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    private int FindPrivate(int a, int b)
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