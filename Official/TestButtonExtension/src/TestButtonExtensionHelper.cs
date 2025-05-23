using System;

namespace SaveVaultApp.Extensions.TestButtonExtension
{
    /// <summary>
    /// Provides a simple interface for the Test Button Extension
    /// </summary>
    public static class TestButtonExtensionHelper
    {
        /// <summary>
        /// Logs a message to the console
        /// </summary>
        /// <param name="message">The message to log</param>
        public static void Log(string message)
        {
            Console.WriteLine($"[TestButtonExtension] {message}");
        }

        /// <summary>
        /// Gets the version of the extension
        /// </summary>
        /// <returns>The version string</returns>
        public static string GetVersion()
        {
            return "1.0.0";
        }

        /// <summary>
        /// Checks if the extension is enabled
        /// </summary>
        /// <returns>True if enabled, false otherwise</returns>
        public static bool IsEnabled()
        {
            try
            {
                // You can implement more complex logic here
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
