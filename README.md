# 🛡️ Cybersecurity Awareness Chatbot – Part 2

An advanced modular cybersecurity chatbot built with **C#**, **WPF**, and **.NET** that educates users on cybersecurity awareness through an intelligent and interactive graphical interface.

This enhanced version expands on Part 1 by introducing:

- Intent recognition
- Sentiment analysis
- Memory management
- Context-aware follow-up handling
- Randomized response generation
- Fallback response mechanisms
- WPF graphical user interface

The chatbot is designed using modern software engineering principles including modular programming, separation of concerns, SOLID principles, and layered architecture.



# 📁 Project Structure

CybersecurityChatbot/
│
├── Audio/
│   └── greeting.wav
│
├── bin/
│
├── Chatbot/
│   ├── AsciiArt.cs
│   ├── ChatbotEngine.cs
│   ├── ConversationContext.cs
│   ├── FollowUpHandler.cs
│   ├── MemoryManager.cs
│   ├── SentimentAnalyzer.cs
│   ├── UIFormatter.cs
│   └── VoiceGreeting.cs
│
├── Data/
│   └── responses.json
│
├── Models/
│   └── Response.cs
│
├── obj/
│
├── Services/
│   ├── FallbackService.cs
│   ├── IntentClassifier.cs
│   ├── JsonResponseLoader.cs
│   ├── KeywordRecognitionService.cs
│   ├── RandomResponseService.cs
│   └── ResponseService.cs
│
├── Utilities/
│   └── InputValidator.cs
│
├── App.config
├── App.xaml
├── App.xaml.cs
├── MainWindow.xaml
├── MainWindow.xaml.cs
├── packages.config
└── README.md



# 🏗️ System Architecture

The application follows a modular layered architecture to ensure:

- Scalability
- Maintainability
- Reusability
- Separation of concerns
- Clean code organization


# 📂 Folder Responsibilities

| Folder | Responsibility |
|---|---|
| **Chatbot/** | Core chatbot logic, context tracking, sentiment analysis, memory handling, UI formatting |
| **Services/** | Business logic services including intent recognition, keyword matching, fallback handling, and response generation |
| **Models/** | Data models used throughout the application |
| **Utilities/** | Validation and helper functionality |
| **Data/** | JSON-based knowledge base |
| **Audio/** | WAV audio greeting resources |



# 🚀 Features

# 🧠 Intelligent Intent Recognition

The chatbot can identify the user's intent using the `IntentClassifier` service.

## Supported Intent Types

- Greeting
- Password Safety
- Phishing Awareness
- Malware Awareness
- Cybersecurity Help
- Exit Commands

The intent recognition system improves conversational accuracy and creates more meaningful interactions.



# 😊 Sentiment Analysis

The chatbot analyzes the user's emotional tone using the `SentimentAnalyzer`.

## Supported Sentiments

- Positive
- Neutral
- Negative
- Frustrated

The chatbot adapts responses based on detected sentiment to create a more natural conversational experience.



# 💾 Memory Management

The `MemoryManager` stores conversation history and previously discussed topics.

## Benefits

- Maintains conversation continuity
- Supports contextual understanding
- Improves follow-up interactions
- Simulates human-like memory



# 🔄 Context-Aware Follow-Up Handling

The chatbot can understand follow-up questions based on previous conversation context.

## Example

User: What is phishing?
Bot: Explains phishing attack

User: How can I avoid it?
Bot: Understands "it" refers to phishing


This functionality is managed using:

- `ConversationContext.cs`
- `FollowUpHandler.cs`


# 🎲 Randomized Responses

The `RandomResponseService` generates varied responses to avoid repetitive conversations.


# 🛡️ Fallback Response System

If the chatbot cannot identify the user's intent or keywords, the `FallbackService` generates safe fallback responses.

## Example

```text
"I'm not sure I understand that yet, but I can help with cybersecurity topics like phishing, passwords, malware, and safe browsing."
```

# 🔐 Cybersecurity Topics Covered

The chatbot provides educational information about:

- Phishing
- Malware
- Password Security
- Multi-Factor Authentication
- Social Engineering
- Safe Browsing
- Email Security
- Online Privacy
- Cyber Hygiene
- Ransomware
- Cyber Threat Awareness

# 🖥️ WPF Graphical User Interface

Part 2 introduces a complete WPF graphical interface replacing the console-only interface from Part 1.


# 🎨 GUI Features

- Modern graphical chat interface
- User-friendly interaction
- Styled message display
- Responsive layout using XAML
- Event-driven programming architecture
- Improved user experience

# ⚙️ Technical Stack

| Technology | Purpose |
|---|---|
| **C#** | Core programming language |
| **.NET** | Application framework |
| **WPF** | Desktop graphical user interface |
| **XAML** | UI design and layout |
| **System.Text.Json** | JSON parsing and serialization |
| **NAudio** | Audio playback |
| **Regular Expressions** | Input cleaning and keyword matching |


# 📋 Class Overview

| Class | Responsibility |
|---|---|
| **ChatbotEngine** | Main chatbot workflow and response pipeline |
| **ConversationContext** | Stores current conversation topic |
| **FollowUpHandler** | Handles follow-up and contextual questions |
| **MemoryManager** | Stores conversation memory |
| **SentimentAnalyzer** | Detects user sentiment |
| **IntentClassifier** | Identifies user intent |
| **KeywordRecognitionService** | Detects cybersecurity keywords |
| **RandomResponseService** | Generates varied responses |
| **FallbackService** | Handles unmatched input |
| **ResponseService** | Retrieves responses from the knowledge base |
| **JsonResponseLoader** | Loads and parses `responses.json` |
| **VoiceGreeting** | Plays startup greeting audio |
| **UIFormatter** | Handles chatbot message formatting |
| **InputValidator** | Cleans and validates user input |
| **Response** | Data model for chatbot responses |


# 📄 Example Knowledge Base Structure

The chatbot stores responses in a JSON file located in:

```text
/Data/responses.json
```

## Example

```json
[
  {
    "Keyword": "Phishing",
    "Reply": "Phishing is a cyberattack where attackers impersonate trusted organizations to steal sensitive information."
  },
  {
    "Keyword": "Password",
    "Reply": "Use strong passwords with a mix of letters, numbers, and symbols."
  }
]
```

# 🧪 Software Engineering Principles Applied

## ✔ SOLID Principles

The project follows SOLID design principles to improve:

- Maintainability
- Extensibility
- Readability
- Scalability

---

## ✔ Separation of Concerns

Each class has a clearly defined responsibility.

---

## ✔ Modular Design

The chatbot is divided into reusable independent modules.

---

## ✔ Layered Architecture

The application separates:

- UI Layer
- Business Logic Layer
- Data Layer
- Utility Layer

---

## ✔ Event-Driven Programming

The WPF interface uses event-driven interaction patterns.

---

# 🛠️ Technologies Used

- C#
- .NET
- WPF
- XAML
- JSON
- NAudio
- Regular Expressions
- Object-Oriented Programming (OOP)

---

# ▶️ Getting Started

# 1️⃣ Prerequisites

Install the following:

- Visual Studio 2022 or later
- .NET SDK
- .NET Desktop Development workload

---

# 2️⃣ Clone the Repository

```bash
git clone https://github.com/your-username/CybersecurityChatbot.git
```

---

# 3️⃣ Open the Solution

Open the `.sln` file in Visual Studio.

---

# 4️⃣ Restore NuGet Packages

Install required dependencies.

Example:

```bash
Install-Package NAudio
```

---

# 5️⃣ Ensure Required Files Exist

Verify that the following files exist:

```text
/Audio/greeting.wav
/Data/responses.json
```

---

# 6️⃣ Run the Application

Press:

```text
F5
```

or select:

```text
Start Debugging
```

---

# 💬 Example Chat Flow

```text
User: Hello
Bot: Hello! How can I help you stay safe online today?

User: What is phishing?
Bot: Phishing is a cyberattack where attackers impersonate trusted organizations to steal sensitive information.

User: How do I avoid it?
Bot: Avoid clicking suspicious links and always verify the sender before responding.
```

---

# 📈 Improvements from Part 1

| Part 1 | Part 2 |
|---|---|
| Console-based application | WPF graphical application |
| Basic keyword matching | Intelligent intent recognition |
| Static responses | Dynamic randomized responses |
| Simple context tracking | Advanced memory management |
| Basic chatbot flow | Context-aware conversation handling |
| Limited interaction | Sentiment-aware responses |
| Basic architecture | Modular layered architecture |

---

# 🔮 Future Enhancements

Potential future improvements include:

- AI/NLP integration
- Machine learning-based response prediction
- Database integration
- User authentication system
- Voice recognition
- Real-time cybersecurity news feed
- Dark mode support
- Cloud deployment
- OpenAI API integration
- Multi-language support

---

# 📚 References

## Cybersecurity References

Stallings, W. and Brown, L. (2018) *Cybersecurity Essentials*. 2nd edn. Pearson.

Pfleeger, C.P. and Pfleeger, S.L. (2012) *Security in Computing*. 5th edn. Prentice Hall.

NIST (2020) *Cybersecurity Framework*.

ENISA (2022) *Cybersecurity Awareness Raising Guide*.

Kaspersky (2024) *What is phishing?*

---

## Microsoft Technologies

Microsoft (2025) .NET Documentation.  
https://learn.microsoft.com/

Microsoft (2025) WPF Documentation.  
https://learn.microsoft.com/dotnet/desktop/wpf/

Microsoft (2025) System.Text.Json Documentation.  
https://learn.microsoft.com/dotnet/standard/serialization/system-text-json

---

## Libraries

Heath, M. (2024) NAudio GitHub Repository.  
https://github.com/naudio/NAudio

---

## Software Engineering

Martin, R.C. (2008) *Clean Code: A Handbook of Agile Software Craftsmanship*.

Gamma, E., Helm, R., Johnson, R. and Vlissides, J. (1994) *Design Patterns: Elements of Reusable Object-Oriented Software*.

Friedl, J.E.F. (2006) *Mastering Regular Expressions*. 3rd edn. O’Reilly.

---

# 👨‍💻 Author

## Cybersecurity Awareness Chatbot – Part 2

Developed as an educational cybersecurity awareness application using:

- C#
- WPF
- .NET
- Modern software engineering principles
- Modular architecture
- Object-oriented programming
````


