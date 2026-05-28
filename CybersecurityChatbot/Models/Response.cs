using System.Collections.Generic;

namespace CybersecurityChatbot.Models
{
    // Represents a chatbot response model
    public class Response
    {
        // Main keyword used to identify the response
        public string Keyword { get; set; } = "";

        // List of alternative words related to the keyword
        public List<string> Synonyms { get; set; }
            = new List<string>();

        // List of possible replies the chatbot can return
        public List<string> Replies { get; set; }
            = new List<string>();

        // Single reply message
        public string Reply { get; set; } = "";
    }
}
