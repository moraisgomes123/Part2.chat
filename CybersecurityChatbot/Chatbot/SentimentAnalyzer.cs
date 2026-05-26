namespace CybersecurityChatbot.Chatbot
{
    public class SentimentAnalyzer
    {
        public string DetectSentiment(string input)
        {
            if (input.Contains("worried"))
                return "worried";

            if (input.Contains("frustrated"))
                return "frustrated";

            if (input.Contains("curious"))
                return "curious";

            return "neutral";
        }
    }
}