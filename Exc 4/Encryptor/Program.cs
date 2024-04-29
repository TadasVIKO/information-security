using Encryptor;

class Program {
    static void Main(string[] args)
    {
        string filePath = 
            "/Users/tadasgrigaitis/Library/CloudStorage/OneDrive-Vilniauskolegija/" +
            "Information Security/Excersise 4/Encryptor/Encryptor/encryptedMsg.txt";
        
        Keys key = new Keys();
        
        int p;
        int q;
        string plainText;

        Console.WriteLine("Enter the p number:");
        p = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Enter the q number:");
        q = Convert.ToInt32(Console.ReadLine());
        
        key.findKeys(p, q);
        
        Console.WriteLine("Enter the message to encrypt:");
        plainText = Console.ReadLine();

        string text = "";
        
        foreach (var i in plainText)
        {
            text += (int)i + " ";
        }

        string encryption = Encrypt.run(plainText, key.getPublicKey());
        
        File.WriteAllText(filePath, $"{text}, {encryption};; " + key.getPublicKey()[0] + ", " + key.getPublicKey()[1]);
        Console.WriteLine("Message encrypted and saved to file.");
        
        Socket.Send(filePath);
    }
}