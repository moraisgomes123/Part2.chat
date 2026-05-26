namespace CybersecurityChatbot.Chatbot
{
    public class FollowUpHandler
    {
        public bool IsFollowUp(string input)
        {
            return input.Contains("tell me more")
                || input.Contains("another tip")
                || input.Contains("explain more");
        }
    }
}