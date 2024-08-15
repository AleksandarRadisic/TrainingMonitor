using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingMonitor.Domain.Utilities.Interface
{
    public interface IEncryptionUtility
    {
        public string Encrypt(string text);
    }
}
