using Exc2;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "/Users/tadasgrigaitis/Library/CloudStorage/OneDrive-Vilniauskolegija/Information Security/Excersise 2/Exc2/message.txt";
        
        Console.WriteLine("Select encryption method (ECB, CBC, CFB):");
        string encryptionMethod = Console.ReadLine().ToUpper();
        
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

        if (selection == 1)
        {
            Console.WriteLine("Enter the message to encrypt:");
            string message = Console.ReadLine();

            Console.WriteLine("Enter the passkey:");
            string passkey = Console.ReadLine();

            if (passkey.Length < 16)
            {
                passkey = Misc.PadPasskey(passkey);
            }

            string encryptedMessage = Encrypt.Run(message, passkey, encryptionMethod);

            File.WriteAllText(filePath, encryptedMessage);

            Console.WriteLine("Message encrypted and saved to file.");
        }

        if (selection == 2)
        {
            Console.WriteLine("Enter the passkey:");
            string passkey = Console.ReadLine();

            if (passkey.Length < 16)
            {
                passkey = Misc.PadPasskey(passkey);
            }
            
            string decryptedMessage = Decrypt.Run(filePath, passkey, encryptionMethod);

            File.AppendAllText(filePath, Environment.NewLine + decryptedMessage);

            Console.WriteLine("Decrypted message appended to the file.");
        }
    }
}
