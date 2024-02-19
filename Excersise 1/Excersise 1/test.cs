using System;

class Vigenere
{
    // Encrypts the plaintext using the given key
    public static string Encrypt(string plaintext, string key)
    {
        string ciphertext = "";
        int keyIndex = 0;

        for (int i = 0; i < plaintext.Length; i++)
        {
            char plainChar = plaintext[i];
            char keyChar = key[keyIndex];

            // Calculate the shift amount based on ASCII values
            int shift = (int)keyChar;

            // Encrypt the character
            char encryptedChar = (char)(plainChar + shift);

            ciphertext += encryptedChar;

            // Move to the next key character
            keyIndex = (keyIndex + 1) % key.Length;
        }

        return ciphertext;
    }

    // Decrypts the ciphertext using the given key
    public static string Decrypt(string ciphertext, string key)
    {
        string plaintext = "";
        int keyIndex = 0;

        for (int i = 0; i < ciphertext.Length; i++)
        {
            char cipherChar = ciphertext[i];
            char keyChar = key[keyIndex];

            // Calculate the shift amount based on ASCII values
            int shift = (int)keyChar;

            // Decrypt the character
            char decryptedChar = (char)(cipherChar - shift);

            plaintext += decryptedChar;

            // Move to the next key character
            keyIndex = (keyIndex + 1) % key.Length;
        }

        return plaintext;
    }
}

class Program
{
    static void Main()
    {
        string plaintext = "Hello, World!";
        string key = "KEY";

        // Encrypt the plaintext
        string encryptedText = Vigenere.Encrypt(plaintext, key);
        Console.WriteLine("Encrypted: " + encryptedText);

        // Decrypt the ciphertext
        string decryptedText = Vigenere.Decrypt(encryptedText, key);
        Console.WriteLine("Decrypted: " + decryptedText);
    }
}