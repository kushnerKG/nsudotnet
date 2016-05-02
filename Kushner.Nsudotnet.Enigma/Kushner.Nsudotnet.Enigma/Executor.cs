using System;
using System.IO;
using System.Security.Cryptography;

namespace Kushner.Nsudotnet.Enigma
{
    enum Algorithms
    {
        Aes = 0, Des = 1, Rc2 = 2, Rijndael = 4
    };

    enum Mode
    {
        Encrypt = 0,
        Decrypt = 1
    };

    class Executor
    {
        public Executor()
        {

        }

        public void Execute(String[] argumentsLine)
        {
            Algorithms algorithms;
            Mode mode;

            if (!Enum.TryParse(argumentsLine[0], true, out mode))
            {
                throw new ArgumentException("неправильное название режима");
            }

            if (!Enum.TryParse(argumentsLine[2], true, out algorithms))
            {
                throw new ArgumentException("неправильное название алгоритма");
            }

            if (mode == Mode.Encrypt)
            {
                String input = argumentsLine[1];
                String output = argumentsLine[3];

                switch (algorithms)
                {
                    case Algorithms.Aes:
                        Encryptor encryptor = new Encryptor(Aes.Create());
                        encryptor.EncryptStringToBytes_Aes(new FileInfo(input), output);
                        break;
                    case Algorithms.Des:
                        encryptor = new Encryptor(DES.Create());
                        encryptor.EncryptStringToBytes_Aes(new FileInfo(input), output);
                        break;
                    case Algorithms.Rc2:
                        encryptor = new Encryptor(RC2.Create());
                        encryptor.EncryptStringToBytes_Aes(new FileInfo(input), output);
                        break;
                    case Algorithms.Rijndael:
                        encryptor = new Encryptor(Rijndael.Create());
                        encryptor.EncryptStringToBytes_Aes(new FileInfo(input), output);
                        break;
                }
            }
            else
            {
                String input = argumentsLine[1];
                String output = argumentsLine[4];
                String key = argumentsLine[3];
                switch (algorithms)
                {
                    case Algorithms.Aes:
                        Decriptor decriptor = new Decriptor(Aes.Create());
                        decriptor.Decrypt(new FileInfo(input), output, key);
                        break;
                    case Algorithms.Des:
                        decriptor = new Decriptor(DES.Create());
                        decriptor.Decrypt(new FileInfo(input), output, key);
                        break;
                    case Algorithms.Rc2:
                        decriptor = new Decriptor(RC2.Create());
                        decriptor.Decrypt(new FileInfo(input), output, key);
                        break;
                    case Algorithms.Rijndael:
                        decriptor = new Decriptor(Rijndael.Create());
                        decriptor.Decrypt(new FileInfo(input), output, key);
                        break;
                }
            }

        }
    }
}
