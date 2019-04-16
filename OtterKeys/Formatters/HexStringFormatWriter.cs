using System;
using OtterKeys;
using NSec.Cryptography;

namespace OtterKeys.Formatters
{
    internal class HexStringFormatWriter : IOutputFormatWriter
    {
        private readonly Key _key;

        public HexStringFormatWriter(Key key)
        {
            _key = key;

            OutputPrivateKey();
            Console.WriteLine();
            OutputPublicKey();
        }

        public void OutputPrivateKey()
        {
            Console.WriteLine("Private key:");
            Console.WriteLine(_key.Export(KeyBlobFormat.RawPrivateKey).EncodeHex());
        }

        public void OutputPublicKey()
        {
            Console.WriteLine("Public key:");
            Console.WriteLine(_key.Export(KeyBlobFormat.RawPublicKey).EncodeHex());
        }
    }
}
