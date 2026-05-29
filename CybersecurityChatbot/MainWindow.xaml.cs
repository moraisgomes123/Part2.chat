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
        // Main chatbot engine used to process user messages
        private readonly ChatbotEngine _chatbot;

        // Handles the voice greeting functionality
        private readonly VoiceGreeting _voiceGreeting = new VoiceGreeting();

        // Constructor - runs when the application starts
        public MainWindow()
        {
            // Initializes all UI components from MainWindow.xaml
            InitializeComponent();

            // Display ASCII art banner in the UI
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

            // Load chatbot responses from the JSON file
            var loader = new JsonResponseLoader("Data/responses.json");
            var responses = loader.LoadResponses();

            // Create the response service using loaded responses
            var service = new ResponseService(responses);

            // Initialize chatbot engine
            _chatbot = new ChatbotEngine(service);

            // Display initial welcome message in chat window
            AppendMessage("Chatbot", "Hello! What is your name?", Colors.Cyan);

            // Register Loaded event to play voice greeting when window opens
            Loaded += MainWindow_Loaded;
        }

        // Runs once the window has fully loaded and rendered
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Play voice greeting asynchronously
            await _voiceGreeting.PlayGreetingAsync();
        }

        // Handles Send button click event
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            // Get user input from textbox
            string input = UserInput.Text;

            // Prevent sending empty or whitespace messages
            if (string.IsNullOrWhiteSpace(input))
                return;

            // Display actual username if available, otherwise show "You"
            string displayName = string.IsNullOrWhiteSpace(_chatbot.UserName)
                ? "You"
                : _chatbot.UserName;

            // Display user's message in chat area
            AppendMessage(displayName, input, Colors.LightGreen);

            // Process user message through chatbot engine
            string response = _chatbot.ProcessMessage(input);

            // Display chatbot response
            AppendMessage("Chatbot", response, Colors.Cyan);

            // Clear input textbox after sending message
            UserInput.Clear();
        }

        // Adds formatted messages to the chat display area
        private void AppendMessage(string sender, string message, Color color)
        {
            // Create a new paragraph for each message
            Paragraph paragraph = new Paragraph();

            // Add sender name with custom color and bold styling
            paragraph.Inlines.Add(new Run(sender + ": ")
            {
                Foreground = new SolidColorBrush(color),
                FontWeight = FontWeights.Bold
            });

            // Add actual message text in white color
            paragraph.Inlines.Add(new Run(message)
            {
                Foreground = new SolidColorBrush(Colors.White)
            });

            // Add completed paragraph to RichTextBox document
            ChatDisplay.Document.Blocks.Add(paragraph);

            // Automatically scroll to latest message
            ChatDisplay.ScrollToEnd();
        }
    }
}
