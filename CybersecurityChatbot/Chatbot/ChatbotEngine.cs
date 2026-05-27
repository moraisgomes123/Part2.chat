using System.Globalization;
using CybersecurityChatbot.Services;

namespace CybersecurityChatbot.Chatbot
{
    public class ChatbotEngine
    {
        private readonly ResponseService _service;
        private readonly ConversationContext _context;
        private readonly SentimentAnalyzer _sentiment;
        private readonly MemoryManager _memory;
        private readonly FollowUpHandler _followUp;

        // Exposes username to the UI
        public string UserName => _context.UserName;

        public ChatbotEngine(ResponseService service)
        {
            _service = service;
            _context = new ConversationContext();
            _sentiment = new SentimentAnalyzer();
            _memory = new MemoryManager();
            _followUp = new FollowUpHandler();
        }

        public string ProcessMessage(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "Hello! What is your name?";

            // =========================
            // NAME PHASE
            // =========================
            if (_context.WaitingForName)
            {
                string clean = input.ToLower().Trim();

                clean = clean.Replace(",", "").Replace(".", "").Replace("!", "").Replace("?", "");

                clean = clean
                    .Replace("my name is", "")
                    .Replace("i am", "")
                    .Replace("i'm", "")
                    .Replace("hello", "")
                    .Replace("hi", "")
                    .Replace("hey", "")
                    .Trim();

                if (string.IsNullOrWhiteSpace(clean))
                    return "Sorry, I didn’t catch your name. What is your name?";

                _context.UserName =
                    CultureInfo.CurrentCulture.TextInfo.ToTitleCase(clean);

                _context.WaitingForName = false;

                return $"Nice to meet you, {_context.UserName}! I'm your Cybersecurity Assistant. How can I help you today?";
            }

            string lowerInput = input.ToLower();

            // MEMORY (favorite topic)
            if (lowerInput.Contains("i like") ||
                lowerInput.Contains("i am interested in") ||
                lowerInput.Contains("my favorite topic is"))
            {
                string topic = lowerInput
                    .Replace("i like", "")
                    .Replace("i am interested in", "")
                    .Replace("my favorite topic is", "")
                    .Trim();

                _memory.SaveFavoriteTopic(_context, topic);

                return $"Great {_context.UserName}! I'll remember that you're interested in {topic}.";
            }

            // SENTIMENT
            string mood = _sentiment.DetectSentiment(lowerInput);

            if (mood == "worried")
                return $"{_context.UserName}, it’s understandable to feel worried about online threats. Let me help you stay safe.";

            if (mood == "frustrated")
                return $"I understand {_context.UserName}. Cybersecurity can feel overwhelming sometimes.";

            if (mood == "curious")
                return $"That’s great, {_context.UserName}! Curiosity helps you stay safe online.";

            // FOLLOW-UP
            if (_followUp.IsFollowUp(lowerInput))
            {
                _context.TopicDepth++;
                return _service.GetFollowUpResponse(_context.LastTopic);
            }

            // MAIN RESPONSE
            _context.LastTopic = input;

            string response = _service.GetResponse(input);

            // PERSONAL MEMORY ADD-ON
            if (!string.IsNullOrWhiteSpace(_context.FavoriteTopic))
            {
                response += $"\n\nSince you're interested in {_context.FavoriteTopic}, stay safe online, {_context.UserName}.";
            }

            return response;
        }
    }
}
