using System.Collections.Generic;
using System.Linq;

namespace CybersecurityChatbot.Services
{
    public class KeywordRecognitionService
    {
        private readonly List<string> _keywords =
            new List<string>()
            {
                "password",
                "privacy",
                "scam",
                "phishing",
                "malware"
            };

        public bool ContainsKeyword(string input)
        {
            input = input.ToLower();

            return _keywords.Any(k => input.Contains(k));
        }
    }
}