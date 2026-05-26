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
        // Instancia a classe de áudio
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

            // Vincula o evento Loaded para disparar a saudação de voz de forma segura
            Loaded += MainWindow_Loaded;
        }

        // Executado assim que a janela aparece totalmente renderizada para o usuário
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // O await garante que o áudio rode em segundo plano sem congelar os botões ou o chat
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