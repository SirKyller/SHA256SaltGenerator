using System;
using System.Security.Cryptography;
using System.Text;

public class PasswordHasher
{
    public static string GenerateHash(string password, string salt)
    {
        string combinedString = salt + password;

        using (SHA256Managed crypt = new SHA256Managed())
        {
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(combinedString));
            StringBuilder hashBuilder = new StringBuilder();

            foreach (byte theByte in crypto)
            {
                hashBuilder.Append(theByte.ToString("x2"));
            }

            return hashBuilder.ToString();
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Inserisci il valore di sale (salt): ");
        string salt = Console.ReadLine();

        Console.Write("Inserisci la password: ");
        string password = Console.ReadLine();

        string hashedPassword = PasswordHasher.GenerateHash(password, salt);

        Console.WriteLine("Hashed Password: " + hashedPassword);
    }
}
