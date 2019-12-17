using System.Text;

namespace LambentLight.Extensions
{
    public static class StringExtensions
    {
        public static string SpaceOnUpperCase(this string str)
        {
            // Create a string builder for the game name
            StringBuilder builder = new StringBuilder();
            // Now, iterate over the name of the game on the enum
            foreach (char character in str)
            {
                // If the character is numeric or uppercase and there are characters on the builder
                if ((char.IsDigit(character) || char.IsUpper(character)) && builder.Length != 0)
                {
                    // Add a space on the builder
                    builder.Append(" ");
                }

                // Then, append the character
                builder.Append(character);
            }

            // Finally, return the result of the string builder
            return builder.ToString();
        }
    }
}
