using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Api.Services
{
    public class PasswordService
    {
        public static void PasswordHasher(string password)
        {
            // Console.Write("Enter a password: ");
            // string password = Console.ReadLine();
            // instead of the above lines, it needs to read the password the user has inputted 

            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            Console.WriteLine($"Hashed: {hashed}");
        }

        public static void PasswordChecker(string[] args)
        {

        }
    }
}