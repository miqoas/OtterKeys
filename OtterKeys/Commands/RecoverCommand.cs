using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using McMaster.Extensions.CommandLineUtils;
using NSec.Cryptography;

namespace OtterKeys.Commands {
	[Command(Description = "Recover the public key from a Ed25519 private key.")]

	public class RecoverCommand {
		[Argument(0, "PrivateKey", "The Ed25519 private key.")]
		[Required]
		private string PrivateKey { get; }

		private void OnExecute(CommandLineApplication app) {
			var algorithm = SignatureAlgorithm.Ed25519;
			using (var key = Key.Import(algorithm, Convert.FromBase64String(PrivateKey), KeyBlobFormat.PkixPrivateKey, new KeyCreationParameters {ExportPolicy = KeyExportPolicies.AllowPlaintextExport})) {
				Console.WriteLine($"{Encoding.UTF8.GetString(key.Export(KeyBlobFormat.PkixPublicKeyText))}");
			}
		}
	}
}
