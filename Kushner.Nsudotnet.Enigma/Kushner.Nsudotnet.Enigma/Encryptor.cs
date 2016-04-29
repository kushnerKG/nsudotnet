using System;
using System.IO;
using System.Security.Cryptography;

namespace Kushner.Nsudotnet.Enigma
{
    class Encryptor
    {
        private SymmetricAlgorithm _algorithm;

        public Encryptor(SymmetricAlgorithm algorithm)
        {
            _algorithm = algorithm;
        }

        public void EncryptStringToBytes_Aes(FileInfo inputFileInfo, String outputFileName)
        {
            /*
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key
, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt
, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(
csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }*/
        }
    }
}
