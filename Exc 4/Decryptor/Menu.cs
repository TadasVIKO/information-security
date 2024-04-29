namespace Decryptor;

public static class Menu
{
    public static void Run()
    {
        Console.WriteLine("What would you like to do: ");
        Console.WriteLine("1. Receive key");
        Console.WriteLine("2. Receive text");
        Console.WriteLine("3. Decrypt & validate file");
        Console.WriteLine("0. Exit");

        int selection = Convert.ToInt32(Console.ReadLine());

        while (selection > 3 || selection < 1)
        {
            Console.WriteLine("Wrong input.");
            selection = Convert.ToInt32(Console.ReadLine());
        }

        switch (selection)
        {
            case 1:
                string filePath = "/Users/tadasgrigaitis/Library/CloudStorage/OneDrive-Vilniauskolegija/" +
                                  "Information Security/Excersise 4/Encryptor/Decryptor/receivedMsg.txt";

                string fileContents = Socket.Receive();
                
                File.WriteAllText(filePath, " ;; " + fileContents);
                Console.WriteLine("Message received successfully and saved to file.");
                
                Menu.Run();
                break;
            case 2:
                filePath = "/Users/tadasgrigaitis/Library/CloudStorage/OneDrive-Vilniauskolegija/" +
                           "Information Security/Excersise 4/Encryptor/Decryptor/receivedMsg.txt";
                
                fileContents = Socket.Receive();
                
                string textFromFile = File.ReadAllText(filePath);
                
                File.WriteAllText(filePath, fileContents + textFromFile);
                Console.WriteLine("Message received successfully and saved to file.");
                
                Menu.Run();
                break;
            case 3:
                filePath = "/Users/tadasgrigaitis/Library/CloudStorage/OneDrive-Vilniauskolegija/" +
                           "Information Security/Excersise 4/Encryptor/Decryptor/decryptedMsg.txt";
                
                string message = Decrypt.run(
                    "/Users/tadasgrigaitis/Library/CloudStorage/OneDrive-Vilniauskolegija/" +
                    "Information Security/Excersise 4/Encryptor/Decryptor/receivedMsg.txt");
                
                File.WriteAllText(filePath, message);
                Console.WriteLine("Message encrypted and saved to file.");
                Menu.Run();
                break;
        }
    }
}