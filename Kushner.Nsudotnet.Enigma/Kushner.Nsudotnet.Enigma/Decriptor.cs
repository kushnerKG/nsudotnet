using System;
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

        public void Decrypt(FileInfo encryptfileInfo, String outputFileName, String keyFile)
        {
            byte[] key, IV;
            using (StreamReader sr = new StreamReader(keyFile))
            {
                key = Convert.FromBase64String(sr.ReadLine());
                IV = Convert.FromBase64String(sr.ReadLine());
            }

            ICryptoTransform decryptor = _algorithm.CreateDecryptor(key, IV);
            _algorithm.Key = key;
            _algorithm.IV = IV;


            using (CryptoStream csDecript = new CryptoStream(encryptfileInfo.OpenRead(), decryptor, CryptoStreamMode.Read))
            {

                using (FileStream outFileStream = File.OpenWrite(outputFileName))
                {
                    csDecript.CopyTo(outFileStream);
                }        
            }  
        }

    }
}