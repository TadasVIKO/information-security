using Exc2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the message to encrypt:");
        string message = Console.ReadLine();

        Console.WriteLine("Enter the passkey:");
        string passkey = Console.ReadLine();

        if (passkey.Length < 16)
        {
            passkey = PadPasskey(passkey);
        }

        Console.WriteLine("Select encryption method (ECB, CBC, CFB):");
        string encryptionMethod = Console.ReadLine().ToUpper();

        string encryptedMessage = Encrypt.Run(message, passkey, encryptionMethod);

        string filePath = "/Users/tadasgrigaitis/Library/CloudStorage/OneDrive-Vilniauskolegija/Information Security/Exc2/Exc2/message.txt";
        File.WriteAllText(filePath, encryptedMessage);

        Console.WriteLine("Message encrypted and saved to file.");

        string decryptedMessage = Decrypt.Run(filePath, passkey, encryptionMethod);

        File.AppendAllText(filePath, Environment.NewLine + decryptedMessage);

        Console.WriteLine("Decrypted message appended to the file.");
    }

    static string PadPasskey(string passkey)
    {
        while (passkey.Length < 16)
        {
            passkey += "0";
        }
        return passkey;
    }
}
