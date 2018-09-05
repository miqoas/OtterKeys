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

		[Option(CommandOptionType.SingleValue, ShortName = "i", LongName = "in",
			Description = "Input format of the public key. Possible values: base64 or hex. Default is 'hex' string.")]
		[AllowedValues("base64", "hex", IgnoreCase = true)]
		public string InputFormat { get; } = "hex";

		[Option(CommandOptionType.SingleValue, ShortName = "o", LongName = "out",
			Description = "Output format of the key pair. Possible values: base64, byte or hex. Default is 'hex' string.")]
		[AllowedValues("base64", "byte", "hex", IgnoreCase = true)]
		public string OutputFormat { get; } = "hex";

		private void OnExecute(CommandLineApplication app) {
			var algorithm = SignatureAlgorithm.Ed25519;

			try {
				using (var key = Key.Import(algorithm, ConvertInputToByteArray(), KeyBlobFormat.RawPrivateKey,
					new KeyCreationParameters {ExportPolicy = KeyExportPolicies.AllowPlaintextExport})) {
					switch (OutputFormat.ToLower()) {
						case "base64":
							new Formatters.Base64StringFormatWriter(key);
							break;

						case "byte":
							new Formatters.ByteArrayFormatWriter(key);
							break;

						case "hex":
							new Formatters.HexStringFormatWriter(key);
							break;

						default:
							throw new ArgumentException($"Unknown output format: {OutputFormat}");
					}
				}
			}
			catch (Exception ex) {
				Console.WriteLine();
				Console.WriteLine("Rats! An exception occured.");
				Console.WriteLine(ex.Message);
			}
		}

		private byte[] ConvertInputToByteArray() {
			return InputFormat.ToLower() == "hex"
				? PrivateKey.DecodeHex()
				: Convert.FromBase64String(PrivateKey);
		}
	}
}
