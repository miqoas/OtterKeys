# :rat::closed_lock_with_key: OtterKeys

[![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)](https://forthebadge.com)
[![forthebadge](https://forthebadge.com/images/badges/built-with-love.svg)](https://forthebadge.com)

A .NET Core Tool to quickly create Ed25519 key pairs for signing and verifying messages or other data.

## Installation

Download and install the [.NET Core 2.1 SDK](https://www.microsoft.com/net/download) or newer. Once installed, run the following command to run OtterKeys:

```bash
dotnet tool install -g otterkeys
```

## Usage

```text
Usage: OtterKeys [options] [command]

Options:
  -?|-h|--help  Show help information

Commands:
  new           Generate a new Ed25519 key pair.
  recover       Recover the public key from a Ed25519 private key.
```

> You can use the --help option to get more details about the commands and their options.

### Creating a new key pair

> Creating a new Ed25519 key pair is as easy as typing:

```bash
otterkeys new
```

Otter will print the private and public key.

The private key should be stored securely and should be unique for each of your products. The public key is distributed with your software.

## Specify key pair output format

You can specify a key pair output format by adding the option `-o`. Possible formats are `base64`, `byte` and `hex`. Example:

```bash
otterkeys new -o byte

Private key:
0xA2, 0xBF, 0xC3, 0x3E, 0xFD, 0x0F, 0x6D, 0x71
0x34, 0xF5, 0x52, 0xC2, 0x63, 0xBC, 0xFC, 0xD0
0xFF, 0x3B, 0x60, 0x7A, 0x47, 0x5C, 0x17, 0x23
0x36, 0x49, 0xAB, 0xED, 0x3C, 0x8F, 0x0A, 0x52

Public key:
0x2C, 0xC2, 0x2B, 0xF2, 0x47, 0xF8, 0xBD, 0x45
0x2A, 0xE5, 0x97, 0xB9, 0xA9, 0x0F, 0xFD, 0x84
0xB1, 0x16, 0x14, 0x48, 0xFC, 0x8C, 0xD7, 0xC5
0x4C, 0x8E, 0x1A, 0xBC, 0x5A, 0x8D, 0x68, 0x51
```

The default output format is a hex-formatted string.

## Recovering a public key

> A lost public key can be recovered from a private key by running the command:

```bash
otterkeys recover [privatekey]
```

You can specify an input and output format by adding the options `-i` and `-o`. The `recover` command supports `base64` and `hex` as input formats, and `base64`, `byte` and `hex` as output formats.

Example:

```bash
otterkeys recover -i base64 -o base64 Oxky5RUtUuHwoZDQQ5TjFgJAFdOyU7fkpVgUqVoju0Y=

Private key:
Oxky5RUtUuHwoZDQQ5TjFgJAFdOyU7fkpVgUqVoju0Y=

Public key:
cs94OIA5LL0Yy70NZtzMi+EJDuHnm3oZDkbE4oBT7n0=
```

## Acknowledgements

Otter uses the excellent [NSec library](https://nsec.rocks/).
