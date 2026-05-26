namespace CybersecurityChatbot.Services
{
    public class IntentClassifier
    {
        public string DetectIntent(string input)
        {
            input = input.ToLower();

            if (input.Contains("password") || input.Contains("login") || input.Contains("account"))
                return "password";

            if (input.Contains("scam") || input.Contains("phishing") || input.Contains("email"))
                return "phishing";

            if (input.Contains("privacy") || input.Contains("data"))
                return "privacy";

            if (input.Contains("hack") || input.Contains("breach"))
                return "security_breach";

            return "unknown";
        }
    }
}