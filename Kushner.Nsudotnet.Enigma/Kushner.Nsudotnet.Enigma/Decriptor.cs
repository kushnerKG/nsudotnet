using System.IO;
using System.Security.Cryptography;

namespace Kushner.Nsudotnet.Enigma
{
    class Decriptor
    {
        private SymmetricAlgorithm _algorithm;

        public Decriptor(SymmetricAlgorithm algorithm)
        {
            _algorithm = algorithm;
        }

        public void DecryptStringFromBytes_Aes(FileInfo fileInfo)
        {

        }
    }
}
