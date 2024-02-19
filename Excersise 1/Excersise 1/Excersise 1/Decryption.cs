namespace Excersise_1;

public class Decryption
{
    
    public void Run(string message, string key)
    {
        string plaintext = "";
        int keyIndex = 0;

        for (int i = 0; i < message.Length; i++)
        {
            char cipherChar = message[i];
            char keyChar = key[keyIndex];

            int shift = (int)keyChar - 32;

            char decryptedChar = (char)((cipherChar - 32 - shift + 95) % 95 + 32);

            plaintext += decryptedChar;

            keyIndex = (keyIndex + 1) % key.Length;
        }

        Console.WriteLine(plaintext);
    }
}