namespace CybersecurityChatbot.Utilities
{
    // Utility class for validating user input
    public static class InputValidator
    {
        // Checks if the input is not null, empty, or whitespace
        public static bool IsValid(string input)
        {
            // Return true if input contains valid text
            return !string.IsNullOrWhiteSpace(input);
        }
    }
}
