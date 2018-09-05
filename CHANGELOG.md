# Changelog

## Version 1.2 - 2018-09-05

OtterKeys can now correctly generate Ed25519 key pairs and output these as `hex` or `base64` encoded strings, or as a `byte` array. Use the `-i` and `-o` option to specify which format should be used.

### New features

- Add trailing comma at each byte-array line [`a4eba25`](https://github.com/miqo-no/OtterKeys/commit/a4eba25c00c27a36af6fc0e01c5bf2d53d570af7)
- The `-f` option has been replaced with `-o` for specifying output format. A new option `-i` for specifying input format has been added.

### Bug fixes

- OtterKeys incorrectly called `base64` keys `hex` encoded. This has been corrected. [`17ff435`](https://github.com/miqo-no/OtterKeys/commit/17ff4356f97adec46078288418cacf429bd67d0c)

## Version 1.1 - 2018-09-01

### New features

- Adds option to output key pair as a byte array. [`bf74dee`](https://github.com/miqo-no/OtterKeys/commit/bf74deeed69cb50c2c3117c14946a5a1f645ef6f)
