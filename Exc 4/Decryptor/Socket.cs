using System.Net;
using System.Net.Sockets;

namespace Decryptor;

public static class Socket
{
    public static string Receive()
    {
        TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8888);
        listener.Start();

        Console.WriteLine("Waiting for sender...");
        
        using (TcpClient client = listener.AcceptTcpClient())
        {
            using (NetworkStream stream = client.GetStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string fileContents = reader.ReadToEnd();

                    listener.Stop();
                    
                    return fileContents;
                }
            }
        }
    }
}