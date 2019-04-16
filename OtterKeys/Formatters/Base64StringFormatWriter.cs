using System;
using NSec.Cryptography;

namespace OtterKeys.Formatters
{
    internal class Base64StringFormatWriter : IOutputFormatWriter
    {
        private readonly Key _key;

        public Base64StringFormatWriter(Key key)
        {
            _key = key;

            OutputPrivateKey();
            Console.WriteLine();
            OutputPublicKey();
        }

        public void OutputPrivateKey()
        {
            Console.WriteLine("Private key:");
            Console.WriteLine(Convert.ToBase64String(_key.Export(KeyBlobFormat.RawPrivateKey)));
        }

        public void OutputPublicKey()
        {
            Console.WriteLine("Public key:");
            Console.WriteLine(Convert.ToBase64String(_key.Export(KeyBlobFormat.RawPublicKey)));
        }
    }
}
