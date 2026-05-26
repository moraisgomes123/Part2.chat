using System;
using System.Collections.Generic;

namespace CybersecurityChatbot.Services
{
    public class RandomResponseService
    {
        private readonly Random _random = new Random();

        public string GetRandomResponse(List<string> responses)
        {
            int index = _random.Next(responses.Count);

            return responses[index];
        }
    }
}