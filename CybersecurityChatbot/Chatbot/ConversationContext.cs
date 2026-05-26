namespace CybersecurityChatbot.Chatbot
{
    public class ConversationContext
    {
        // =========================
        // USER INFO
        // =========================

        public string UserName { get; set; } = "";

        public bool WaitingForName { get; set; } = true;

        // =========================
        // CONVERSATION MEMORY
        // =========================

        public string LastTopic { get; set; } = "";

        public string FavoriteTopic { get; set; } = "";

        public string CurrentIntent { get; set; } = "";

        public string Emotion { get; set; } = "";

        public int TopicDepth { get; set; } = 0;
    }
}