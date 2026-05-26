namespace CybersecurityChatbot.Chatbot
{
    public static class UIFormatter
    {
        // Formats messages sent by the chatbot
        public static string Bot(string message)
        {
            return "Chatbot: " + message;
        }
       // Formats messages sent by the user.
        public static string User(string userName, string message)
        {
            return string.IsNullOrWhiteSpace(userName)
                ? "You: " + message
                : $"{userName}: {message}";
        }
    }
}
