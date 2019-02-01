using System;
using System.Security.Cryptography;

namespace ServerManager
{
    /// <summary>
    /// Set of tools to make development easier.
    /// </summary>
    public static class Tools
    {
        /// <summary>
        /// Creates a secure string via RNGCryptoServiceProvider.
        /// </summary>
        /// <param name="Length">The desired lenght of the string.</param>
        /// <returns>The secure string with the specified length.</returns>
        public static string GenerateSecureString(int Length)
        {
            // Create a new instance of RNGCryptoServiceProvider
            RNGCryptoServiceProvider RNG = new RNGCryptoServiceProvider();
            // Create a place to store the output
            byte[] Output = new byte[Length];
            // Create the random string as bytes
            RNG.GetBytes(Output);
            // And then, return that byte array as a string
            return Convert.ToBase64String(Output);
        }
    }
}
