namespace SubmarineDiagnostics.Core.Utils
{
    /// <summary>
    /// Utilitário responsável por converter valores binários em decimal.
    /// </summary>
    public static class BinaryConverter
    {
        public static int ToDecimal(string binary)
        => Convert.ToInt32(binary, 2);
    }
}
