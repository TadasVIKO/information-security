
using Exc3;

class Program {
    static void Main(string[] args)
    {
        string filePath =
            "/Users/tadasgrigaitis/Library/CloudStorage/OneDrive-Vilniauskolegija/Information Security/Excersise 3/Exc3/Exc3/message.txt";
        
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
                
                File.WriteAllText(filePath, encryption);
                Console.WriteLine("Message encrypted and saved to file.");
                
                break;
            case 2:
                Console.WriteLine("Enter the p number:");
                p = Convert.ToInt32(Console.ReadLine());
                
                Console.WriteLine("Enter the q number:");
                q = Convert.ToInt32(Console.ReadLine());
                
                key.findKeys(p, q);

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