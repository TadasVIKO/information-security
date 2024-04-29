using System;
using System.Net.Sockets;

namespace Encryptor;

public static class Socket
{
    public static void Send(string file)
    {
        string filePath = file;

        string[] fileContents = File.ReadAllText(filePath).Split(" ;; ");

        using (TcpClient client = new TcpClient("127.0.0.1", 8888))
        {
            using (NetworkStream stream = client.GetStream())
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    // Send the file contents to the receiver
                    writer.Write(fileContents[1]);
                }
            }
        }
        
        using (TcpClient client = new TcpClient("127.0.0.1", 8887))
        {
            using (NetworkStream stream = client.GetStream())
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    // Send the file contents to the receiver
                    writer.Write(fileContents[0]);
                }
            }
        }

        Console.WriteLine("File sent successfully.");
    }
}