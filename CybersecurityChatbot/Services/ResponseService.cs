using CybersecurityChatbot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CybersecurityChatbot.Services
{
    public class ResponseService
    {
        private readonly List<Response> _responses;

    private readonly Random _random = new Random();

        private readonly List<string> _prefixes =
            new List<string>
        {
        "Good question!",
        "That’s important to know.",
        "Here’s what you should understand:",
        "Let me explain that clearly:",
        "That’s a common concern:"
        };

        public ResponseService(List<Response> responses)
        {
            _responses = responses;
        }

        public string GetResponse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "I’m not sure I understand. Can you rephrase that?";

            string cleanInput =
                Regex.Replace(
                    input.ToLower(),
                    @"[^\w\s]",
                    "");

            bool wantsDefinition =
                cleanInput.Contains("what is") ||
                cleanInput.Contains("tell me about") ||
                cleanInput.Contains("define") ||
                cleanInput.Contains("explain");

            var match = _responses.FirstOrDefault(r =>
                cleanInput.Contains(r.Keyword.ToLower()) ||

                (r.Synonyms != null &&
                 r.Synonyms.Any(s =>
                    cleanInput.Contains(s.ToLower())))
            );

            if (match != null)
            {
                string reply;

                // ===================================
                // DEFINITION REQUEST
                // ===================================

                if (wantsDefinition)
                {
                    reply = match.Replies[0];

                    return reply +
                        "\n\nWould you like tips on this topic?";
                }

                // ===================================
                // RANDOM RESPONSE
                // ===================================

                reply =
                    match.Replies[
                        _random.Next(match.Replies.Count)];

                string prefix =
                    _prefixes[
                        _random.Next(_prefixes.Count)];

                return prefix + " " + reply +
                    "\n\nWould you like more details on this topic?";
            }

            // ===================================
            // SMART FALLBACK
            // ===================================

            return "I’m not completely sure, but are you asking about passwords, scams, phishing, malware, or online privacy?";
        }

        public string GetFollowUpResponse(string topic)
        {
            topic = topic.ToLower();

            if (topic.Contains("password"))
            {
                return "Strong passwords should include uppercase letters, lowercase letters, numbers, and symbols. Avoid using birthdays or names.";
            }

            if (topic.Contains("phishing"))
            {
                return "Phishing attacks often create urgency to trick victims. Never click suspicious links or download unknown attachments.";
            }

            if (topic.Contains("privacy"))
            {
                return "Protect your privacy by reviewing social media settings and limiting personal information shared online.";
            }

            if (topic.Contains("malware"))
            {
                return "Malware can infect devices through unsafe downloads, fake apps, or suspicious email attachments.";
            }

            if (topic.Contains("ransomware"))
            {
                return "Ransomware encrypts files and demands payment. Regular backups are one of the best protections.";
            }

            return "Cybersecurity helps protect your information and systems from digital threats. Staying cautious online is very important.";
        }
    }

}
