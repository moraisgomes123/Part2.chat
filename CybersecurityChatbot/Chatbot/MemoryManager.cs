namespace CybersecurityChatbot.Chatbot
{
    // Handles chatbot memory-related operations
    public class MemoryManager
    {
        // Saves the user's favorite topic into the conversation context
        public void SaveFavoriteTopic(ConversationContext context, string topic)
        {
            // Store the favorite topic
            context.FavoriteTopic = topic;
        }
    }
}
