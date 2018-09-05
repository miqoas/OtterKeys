using System;
using NSec.Cryptography;

namespace OtterKeys.Formatters {
	internal class ByteArrayFormatWriter : IOutputFormatWriter {
		private readonly Key _key;

		public ByteArrayFormatWriter(Key key) {
			_key = key;

			OutputPrivateKey();
			OutputPublicKey();
		}

		public void OutputPrivateKey() {
			var bytes = _key.Export(KeyBlobFormat.RawPrivateKey);

			Console.WriteLine("Private key:");
			WriteByteArrayToConsole(bytes);
		}

		public void OutputPublicKey() {
			var bytes = _key.Export(KeyBlobFormat.RawPublicKey);

			Console.WriteLine("Public key:");
			WriteByteArrayToConsole(bytes);
		}

		private void WriteByteArrayToConsole(byte[] bytes) {
			var i = 0;

			for (var c = 0; c < bytes.Length; c++) {
				Console.Write($"0x{bytes[c]:X2}");

				i++;
				if (i == 8) {
					Console.WriteLine(c < bytes.Length - 1 ? "," : "");
					i = 0;
				}
				else {
					Console.Write(c < bytes.Length - 1 ? ", " : "");
				}
			}

			Console.WriteLine();
		}
	}
}
