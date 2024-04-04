
using Exc3;

class Program {
    static void Main(string[] args)
    {
        int[] primes = {
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71,
            73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151,
            157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233,
            239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317,
            331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419,
            421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499, 503,
            509, 521, 523, 541, 547, 557, 563, 569, 571, 577, 587, 593, 599, 601, 607,
            613, 617, 619, 631, 641, 643, 647, 653, 659, 661, 673, 677, 683, 691, 701,
            709, 719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787, 797, 809, 811,
            821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 911,
            919, 929, 937, 941, 947, 953, 967, 971, 977, 983, 991, 997
        };
        
        string filePath =
            "/Users/tadasgrigaitis/Library/CloudStorage/OneDrive-Vilniauskolegija/Information Security/Excersise 3/Exc3/message.txt";
        
        Keys key = new Keys();
        
        int p;
        int q;
        string plainText;
        
        Console.WriteLine("");
        Console.WriteLine("What would you like to do: ");
        Console.WriteLine("1. Encrypt");
        Console.WriteLine("2. Decrypt");
        Console.WriteLine("3. Exit");

        int selection = Convert.ToInt32(Console.ReadLine());

        while (selection > 3 || selection < 1)
        {
            Console.WriteLine("Wrong input.");
            selection = Convert.ToInt32(Console.ReadLine());
        }

        switch (selection)
        {
            case 1:
                Console.WriteLine("Enter the p number:");
                p = Convert.ToInt32(Console.ReadLine());
                
                Console.WriteLine("Enter the q number:");
                q = Convert.ToInt32(Console.ReadLine());
                
                key.findKeys(p, q);
                
                Console.WriteLine("Enter the message to encrypt:");
                plainText = Console.ReadLine();

                string encryption = Encrypt.run(plainText, key.getPublicKey());
                
                File.WriteAllText(filePath, encryption + ";; " + key.getPublicKey()[0] + ", " + key.getPublicKey()[1]);
                Console.WriteLine("Message encrypted and saved to file.");
                
                break;
            case 2:
                int f = 0;
                int e = 0;
                int n = 0;
                
                string[] encryptedText = File.ReadAllText(filePath).Split(";; ");
                string[] fne = encryptedText[1].Split(", ");

                int.TryParse(fne[0], out int num);
                int fne_int = num;
                
                foreach (var i in primes)
                {
                    foreach (var j in primes)
                    {
                        f = i * j;
                        
                        if (f == fne_int)
                        {
                            e = j;
                            n = i;
                        }
                    }
                }

                key.findKeys(e, n);
                
                string decryption = Decrypt.run(filePath, key.getPrivateKey(), key.getPublicKey());
                
                File.AppendAllText(filePath, Environment.NewLine + decryption);
                Console.WriteLine("Decrypted message appended to the file.");
                
                break;
            case 3:
                Console.WriteLine("Goodbye!");
                return;
        }
    }
}