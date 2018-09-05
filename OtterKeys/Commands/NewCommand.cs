using System;
using McMaster.Extensions.CommandLineUtils;
using NSec.Cryptography;

namespace OtterKeys.Commands {
	[Command(Description = "Generate a new Ed25519 key pair.")]
	public class NewCommand {
		[Option(CommandOptionType.SingleValue, ShortName = "o", LongName = "out",
			Description = "Output format of the key pair. Possible values: base64, byte or hex. Default is 'hex' string.")]
		[AllowedValues("base64", "byte", "hex", IgnoreCase = true)]
		public string Format { get; } = "hex";

		private void OnExecute(CommandLineApplication app) {
			var algorithm = SignatureAlgorithm.Ed25519;
			
			using (var key = Key.Create(algorithm, new KeyCreationParameters { ExportPolicy = KeyExportPolicies.AllowPlaintextExport })) {
				switch (Format.ToLower())
				{
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
						throw new ArgumentException($"Unknown output format: {Format}");
				}
			}
		}
	}
}
