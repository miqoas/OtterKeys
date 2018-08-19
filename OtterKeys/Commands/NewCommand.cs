using System;
using System.Text;
using McMaster.Extensions.CommandLineUtils;
using NSec.Cryptography;

namespace OtterKeys.Commands {
	[Command(Description = "Generate a new Ed25519 key pair.")]
	public class NewCommand {
		private void OnExecute(CommandLineApplication app) {
			var algorithm = SignatureAlgorithm.Ed25519;

			using (var key = Key.Create(algorithm, new KeyCreationParameters { ExportPolicy = KeyExportPolicies.AllowPlaintextExport })) {
				Console.WriteLine($"{Encoding.UTF8.GetString(key.Export(KeyBlobFormat.PkixPrivateKeyText))}");
				Console.WriteLine($"{Encoding.UTF8.GetString(key.Export(KeyBlobFormat.PkixPublicKeyText))}");
			}
		}
	}
}
