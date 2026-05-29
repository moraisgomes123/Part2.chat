namespace CybersecurityChatbot.Chatbot
{
    // Handles detection of follow-up type questions from the user
    public class FollowUpHandler
    {
        // Checks whether the user's message is asking for more information
        public bool IsFollowUp(string input)
        {
            // Returns true if the input contains common follow-up phrases
            return input.Contains("tell me more")
                || input.Contains("another tip")
                || input.Contains("explain more");
        }
    }
}
