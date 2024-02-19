namespace Excersise_1;

public class Encryption
{
    public void Run(string message, string key)
    {
        string ciphertext = "";
        int keyIndex = 0;

        for (int i = 0; i < message.Length; i++)
        {
            char msgChar = message[i];
            char keyChar = key[keyIndex];

            int shift = (int)keyChar - 32;

            char encryptedChar = (char)((msgChar - 32 + shift) % 95 + 32);

            ciphertext += encryptedChar;

            keyIndex = (keyIndex + 1) % key.Length;
        }
        
        Console.WriteLine(ciphertext);
    }
}