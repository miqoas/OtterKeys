using System;
using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;
using NSec.Cryptography;

namespace OtterKeys.Commands {
	[Command(Description = "Recover the public key from a Ed25519 private key.")]
	public class RecoverCommand {
		[Argument(0, "PrivateKey", "The Ed25519 private key.")]
		[Required]
		private string PrivateKey { get; }

		[Option(CommandOptionType.SingleValue, ShortName = "f", LongName = "format",
			Description = "Output format of the key pair. Possible values: hex, byte. Default is 'hex' string.")]
		[AllowedValues("byte", "hex", IgnoreCase = true)]
		public string Format { get; } = "hex";

		private void OnExecute(CommandLineApplication app) {
			var algorithm = SignatureAlgorithm.Ed25519;
			using (var key = Key.Import(algorithm, Convert.FromBase64String(PrivateKey), KeyBlobFormat.PkixPrivateKey, new KeyCreationParameters {ExportPolicy = KeyExportPolicies.AllowPlaintextExport})) {
				switch (Format) {
					case "hex":
						new Formatters.HexStringFormatWriter(key);
						break;

					case "byte":
						new Formatters.ByteArrayFormatWriter(key);
						break;

					default:
						throw new ArgumentException(nameof(Format));
				}
			}
		}
	}
}
