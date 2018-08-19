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

## Recovering a public key

> A lost public key can be recovered from a private key by running the command:

```bash
otterkeys recover [privatekey]
```

## Acknowledgements

Otter uses the excellent [NSec library](https://nsec.rocks/).
