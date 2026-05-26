namespace CybersecurityChatbot.Chatbot
{
    public static class UIFormatter
    {
        public static string Bot(string message)
        {
            return "Chatbot: " + message;
        }

        public static string User(string userName, string message)
        {
            return string.IsNullOrWhiteSpace(userName)
                ? "You: " + message
                : $"{userName}: {message}";
        }
    }
}