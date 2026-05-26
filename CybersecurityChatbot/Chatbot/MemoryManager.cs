namespace CybersecurityChatbot.Chatbot
{
    public class MemoryManager
    {
        public void SaveFavoriteTopic(ConversationContext context, string topic)
        {
            context.FavoriteTopic = topic;
        }
    }
}