using System.Net;
using System.Net.Sockets;

namespace Interception;

public static class Socket
{
    public static void Send(string file)
    {
        string filePath = file;

        string fileContents = File.ReadAllText(filePath);

        using (TcpClient client = new TcpClient("127.0.0.1", 8888))
        {
            using (NetworkStream stream = client.GetStream())
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(fileContents);
                }
            }
        }

        Console.WriteLine("File sent successfully.");
    }
    
    public static void Receive()
    {
        string filePath = "/Users/tadasgrigaitis/Library/CloudStorage/OneDrive-Vilniauskolegija/" +
                          "Information Security/Excersise 4/Encryptor/Interception/interceptedMsg.txt";
        
        TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8887);
        listener.Start();

        Console.WriteLine("Waiting for sender...");

        using (TcpClient client = listener.AcceptTcpClient())
        {
            using (NetworkStream stream = client.GetStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string fileContents = reader.ReadToEnd();
                    
                    File.WriteAllText(filePath, fileContents);
                    Console.WriteLine("Message received successfully and saved to file.");
                }
            }
        }

        listener.Stop();
    }
}