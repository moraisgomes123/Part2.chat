using System.Collections.Generic;

namespace CybersecurityChatbot.Models
{
    public class Response
    {
        public string Keyword { get; set; } = "";

    public List<string> Synonyms { get; set; }
        = new List<string>();

        public List<string> Replies { get; set; }
            = new List<string>();

        public string Reply { get; set; } = "";
    }

}
