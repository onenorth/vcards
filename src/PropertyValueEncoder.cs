namespace OneNorth.VCards
{
    /// <summary>
    /// Property value encoder.
    /// </summary>
    internal static class PropertyValueEncoder
    {
        /// <summary>
        /// Get encoded property value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="quotedPrintable"></param>
        /// <returns></returns>
        public static string GetEncodedPropertyValue(string value, bool quotedPrintable)
        {
            if (!quotedPrintable)
            {
                return value.Replace("\\", "\\\\").Replace(",", "\\,").Replace(";", "\\;").Replace("\n", "\\n");
            }
            return value.Replace("\\", "=5C").Replace(",", "=2C").Replace(";", "=3B").Replace("\n", "=0D=0A");
        }
    }
}
