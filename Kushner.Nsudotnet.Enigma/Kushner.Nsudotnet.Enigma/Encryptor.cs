using System;
using System.IO;
using System.Security.Cryptography;

namespace Kushner.Nsudotnet.Enigma
{
    class Encryptor
    {
        private static readonly String  KeyFileName = "file.key.txt";
        private SymmetricAlgorithm _algorithm;

        public Encryptor(SymmetricAlgorithm algorithm)
        {
            _algorithm = algorithm;
        }

        public void EncryptStringToBytes_Aes(FileInfo inputFileInfo, String outputFileName)
        {
            byte[] Key = _algorithm.Key;
            byte[] IV = _algorithm.IV;

            using (StreamWriter sw = new StreamWriter(KeyFileName))
            {
                sw.Write(Convert.ToBase64String(Key));
                sw.Write("\n");
                sw.Write(Convert.ToBase64String(IV));
            }

            ICryptoTransform encryptor = _algorithm.CreateEncryptor(Key, IV);

            using (CryptoStream csEncrypt = new CryptoStream(File.OpenWrite(outputFileName), encryptor, CryptoStreamMode.Write))
            {
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {
                    using (StreamReader inputStreamReader = new StreamReader(inputFileInfo.OpenRead()))
                    {
                        String line;
                        while ((line = inputStreamReader.ReadLine()) != null)
                        {
                            swEncrypt.Write(line + "\n");
                        }   
                    }
                }
            }
   
        }

    }
}
