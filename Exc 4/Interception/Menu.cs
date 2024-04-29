namespace Interception;

public static class Menu
{
    public static void Run()
    {
        Console.WriteLine("What would you like to do: ");
        Console.WriteLine("1. Intercept file");
        Console.WriteLine("2. Modify a value");
        Console.WriteLine("3. Send the file");
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
                Socket.Receive();
                Menu.Run();
                break;
            case 2:
                string filePath = "/Users/tadasgrigaitis/Library/CloudStorage/OneDrive-Vilniauskolegija/" +
                                  "Information Security/Excersise 4/Encryptor/Interception/interceptedMsg.txt";
                
                string[] textFromFile = File.ReadAllText(filePath).Split(" , ");
                string[] textSplit = textFromFile[0].Split(" ");

                string plainText = "";
                

                foreach (var i in textSplit)
                {
                    int.TryParse(i, out int num);
                    plainText += (char)num;
                }
                
                Console.WriteLine("The plain text is: " + plainText);
                Console.WriteLine("What would you like to change it to?");
                
                string input = Console.ReadLine();
                
                Console.WriteLine("Plain text was changed to: " + input);

                string modifiedText = "";
                
                foreach (var i in input)
                {
                    modifiedText += Convert.ToInt32(i) + " ";
                }
                
                File.WriteAllText(filePath, modifiedText + ", " + textFromFile[1]);
                Console.WriteLine("Message modified and saved to file.");
                
                Console.WriteLine();
                Menu.Run();
                break;
            case 3:
                Socket.Send("/Users/tadasgrigaitis/Library/CloudStorage/OneDrive-Vilniauskolegija/" +
                            "Information Security/Excersise 4/Encryptor/Interception/interceptedMsg.txt");
                Menu.Run();
                break;
        }
    }
}