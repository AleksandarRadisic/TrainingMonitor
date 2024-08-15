using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TrainingMonitor.Domain.Utilities.Interface;

namespace TrainingMonitor.Domain.Utilities.Implementation
{
    public class EncryptionUtility : IEncryptionUtility
    {
        public string Encrypt(string text)
        {
            using var sha = SHA256.Create();
            var computedHash = sha.ComputeHash(Encoding.Unicode.GetBytes(text));
            return Convert.ToBase64String(computedHash);
        }
    }
}
