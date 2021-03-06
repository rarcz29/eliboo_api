using Eliboo.Application.Services;
using System;
using System.Security.Cryptography;

namespace Eliboo.Infrastructure.Services
{
    class PasswordHashService : IPasswordHashService
    {
        private const int SaltByteSize = 24;
        private const int HashByteSize = 24;
        private const int PBKDF2Iterations = 1000;
        private const int IterationIndex = 0;
        private const int SaltIndex = 1;
        private const int PBKDF2Index = 2;

        public string CreateHash(string password)
        {
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SaltByteSize];
            csprng.GetBytes(salt);

            byte[] hash = PBKDF2(password, salt, PBKDF2Iterations, HashByteSize);
            return PBKDF2Iterations + ":" +
                Convert.ToBase64String(salt) + ":" +
                Convert.ToBase64String(hash);
        }

        public bool ValidatePassword(string password, string correctHash)
        {
            char[] delimiter = { ':' };
            string[] split = correctHash.Split(delimiter);
            int iterations = int.Parse(split[IterationIndex]);
            byte[] salt = Convert.FromBase64String(split[SaltIndex]);
            byte[] hash = Convert.FromBase64String(split[PBKDF2Index]);

            byte[] testHash = PBKDF2(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }

        private byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }

        private bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;

            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }

            return diff == 0;
        }
    }
}
