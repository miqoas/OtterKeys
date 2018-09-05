// Credit: kgriffs @ stackoverflow
// https://stackoverflow.com/a/3974535

namespace OtterKeys
{
    /// <summary>
    /// Helper methods to convert a byte array to a hex formatted string or the
    /// other way around.
    /// </summary>
    public static class HexExtensions
    {
        /// <summary>
        /// Converts a byte array to a hex string.
        /// </summary>
        /// <param name="bytes">The byte array to convert.</param>
        /// <returns>A hex encoded string.</returns>
        public static string EncodeHex(this byte[] bytes)
        {
            char[] c = new char[bytes.Length * 2];

            byte b;

            for (int bx = 0, cx = 0; bx < bytes.Length; ++bx, ++cx)
            {
                b = ((byte)(bytes[bx] >> 4));
                c[cx] = (char)(b > 9 ? b + 0x37 + 0x20 : b + 0x30);

                b = ((byte)(bytes[bx] & 0x0F));
                c[++cx] = (char)(b > 9 ? b + 0x37 + 0x20 : b + 0x30);
            }

            return new string(c);
        }

        /// <summary>
        /// Converts a hex string to a byte array.
        /// </summary>
        /// <param name="hex">The hex encoded string.</param>
        /// <returns>A byte array.</returns>
        public static byte[] DecodeHex(this string hex)
        {
            if (hex.Length == 0 || hex.Length % 2 != 0)
                return new byte[0];

            byte[] buffer = new byte[hex.Length / 2];
            char c;
            for (int bx = 0, sx = 0; bx < buffer.Length; ++bx, ++sx)
            {
                // Convert first half of byte
                c = hex[sx];
                buffer[bx] = (byte)((c > '9' ? (c > 'Z' ? (c - 'a' + 10) : (c - 'A' + 10)) : (c - '0')) << 4);

                // Convert second half of byte
                c = hex[++sx];
                buffer[bx] |= (byte)(c > '9' ? (c > 'Z' ? (c - 'a' + 10) : (c - 'A' + 10)) : (c - '0'));
            }

            return buffer;
        }
    }
}
