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
        // Instantiates the audio class
        private readonly VoiceGreeting _voiceGreeting = new VoiceGreeting();

        public MainWindow()
        {
            InitializeComponent();

            // =========================
            // ASCII BANNER
            // =========================
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

            // Binds the Loaded event to safely trigger the voice greeting
            Loaded += MainWindow_Loaded;
        }

        // Executed as soon as the window is fully rendered for the user
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // The await ensures the audio runs in the background without freezing the buttons or chat
            await _voiceGreeting.PlayGreetingAsync();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string input = UserInput.Text;

            if (string.IsNullOrWhiteSpace(input))
                return;

            AppendMessage("You", input, Colors.LightGreen);

            string response = _chatbot.ProcessMessage(input);

            AppendMessage("Chatbot", response, Colors.Cyan);

            UserInput.Clear();
        }

        // ✅ NEW CORE FIX (COLOR SYSTEM)
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
