using Excersise_1;

class Program 
{
    static void Main(string[] args)
    {
        Encryption encryption = new Encryption();
        Decryption decryption = new Decryption();
        
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
            Console.WriteLine("Please input a message to encrypt: ");
            string message = Console.ReadLine();
            
            Console.WriteLine("Please input a pass key: ");
            string passKey = Console.ReadLine();
            
            encryption.Run(message, passKey);
        }
        
        if (selection == 2)
        {
            Console.WriteLine("Please input a message to decrypt: ");
            string message = Console.ReadLine();
            Console.WriteLine("Please input a pass key: ");
            string passKey = Console.ReadLine();
            
            decryption.Run(message, passKey);
        }

        if (selection == 3)
        {
            return;
        }
    }
}