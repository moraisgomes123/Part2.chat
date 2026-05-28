namespace CybersecurityChatbot.Chatbot
{
    // Analyzes the user's sentiment based on input text
    public class SentimentAnalyzer
    {
        // Detects the sentiment from the user's message
        public string DetectSentiment(string input)
        {
            // Check if the user feels worried
            if (input.Contains("worried"))
                return "worried";

            // Check if the user feels frustrated
            if (input.Contains("frustrated"))
                return "frustrated";

            // Check if the user feels curious
            if (input.Contains("curious"))
                return "curious";

            // Return neutral if no sentiment keywords are found
            return "neutral";
        }
    }
}
