using CybersecurityChatbot.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CybersecurityChatbot.Services
{
    public class JsonResponseLoader
    {
        private readonly string _path;

        public JsonResponseLoader(string path)
        {
            _path = path;
        }

        public List<Response> LoadResponses()
        {
            if (!File.Exists(_path))
                return new List<Response>();

            string json = File.ReadAllText(_path);

            return JsonSerializer.Deserialize<List<Response>>(json)
                   ?? new List<Response>();
        }
    }
}