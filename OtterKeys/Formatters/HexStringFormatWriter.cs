using System;
using System.Text;
using NSec.Cryptography;

namespace OtterKeys.Formatters {
	internal class HexStringFormatWriter : IOutputFormatWriter {
		private readonly Key _key;

		public HexStringFormatWriter(Key key) {
			_key = key;

			OutputPrivateKey();
			OutputPublicKey();
		}

		public void OutputPrivateKey() {
			Console.WriteLine(Encoding.UTF8.GetString(_key.Export(KeyBlobFormat.PkixPrivateKeyText)));
		}

		public void OutputPublicKey() {
			Console.WriteLine(Encoding.UTF8.GetString(_key.Export(KeyBlobFormat.PkixPublicKeyText)));
		}
	}
}
