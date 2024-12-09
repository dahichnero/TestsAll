using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shtirlitz
{
    public abstract class BaseEncryptionAlgorithm
    {
        public abstract string Encrypt(string text);
        public abstract string Decrypt(string text);
    }
}
