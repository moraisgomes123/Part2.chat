using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using CybersecurityChatbot.Chatbot;
using CybersecurityChatbot.Services;

namespace CybersecurityChatbot
{
    public partial class MainWindow : Window
    {
        private readonly ChatbotEngine _chatbot;
        private readonly VoiceGreeting _voiceGreeting = new VoiceGreeting();

        public MainWindow()
        {
            InitializeComponent();

            AsciiBanner.Text = @"
╔══════════════════════════════════════════════════════════════╗
║        ░█████╗░██╗░░░██╗██████╗░███████╗██████╗░              ║
║        ██╔══██╗╚██╗░██╔╝██╔══██╗██╔════╝██╔══██╗              ║
║        ██║░░╚═╝░╚████╔╝░██████╦╝█████╗░░██████╔╝              ║
║        ██║░░██╗░░╚██╔╝░░██╔══██╗██╔══╝░░██╔══██╗              ║
║        ╚█████╔╝░░░██║░░░██████╦╝███████╗██║░░██║              ║
║        ░╚════╝░░░░╚═╝░░░╚═════╝░╚══════╝╚═╝░░                ║
║                 CYBERSECURITY AWARENESS BOT                  ║
║                  Stay Safe Online!                           ║
╚══════════════════════════════════════════════════════════════╝
";

            var loader = new JsonResponseLoader("Data/responses.json");
            var responses = loader.LoadResponses();

            var service = new ResponseService(responses);
            _chatbot = new ChatbotEngine(service);

            AppendMessage("Chatbot", "Hello! What is your name?", Colors.Cyan);

            Loaded += MainWindow_Loaded;
        }

        // Executed as soon as the window is fully rendered for the user
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await _voiceGreeting.PlayGreetingAsync();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string input = UserInput.Text;

            if (string.IsNullOrWhiteSpace(input))
                return;

            // Show real username instead of "You"
            string displayName = string.IsNullOrWhiteSpace(_chatbot.UserName)
                ? "You"
                : _chatbot.UserName;

            AppendMessage(displayName, input, Colors.LightGreen);

            string response = _chatbot.ProcessMessage(input);

            AppendMessage("Chatbot", response, Colors.Cyan);

            UserInput.Clear();
        }

        private void AppendMessage(string sender, string message, Color color)
        {
            Paragraph paragraph = new Paragraph();

            paragraph.Inlines.Add(new Run(sender + ": ")
            {
                Foreground = new SolidColorBrush(color),
                FontWeight = FontWeights.Bold
            });

            paragraph.Inlines.Add(new Run(message)
            {
                Foreground = new SolidColorBrush(Colors.White)
            });

            ChatDisplay.Document.Blocks.Add(paragraph);
            ChatDisplay.ScrollToEnd();
        }
    }
}
