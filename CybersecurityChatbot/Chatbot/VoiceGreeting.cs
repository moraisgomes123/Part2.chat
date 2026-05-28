using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows; // Used for displaying temporary error messages
using NAudio.Wave;

namespace CybersecurityChatbot.Chatbot
{
    // Handles playing the chatbot greeting audio
    public class VoiceGreeting
    {
        // Plays the greeting audio asynchronously without freezing the UI
        public async Task PlayGreetingAsync()
        {
            try
            {
                // Build the full path to the greeting audio file
                string path = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Audio",
                    "greeting.wav");

                // Check if the audio file exists
                if (!File.Exists(path))
                {
                    // Show an error message if the file is missing
                    MessageBox.Show($"Arquivo não encontrado em: {path}");
                    return;
                }

                // Run audio playback on a separate thread
                await Task.Run(() =>
                {
                    // Load the audio file
                    using (var audioFile = new AudioFileReader(path))
                    {
                        // Create the audio output device
                        using (var outputDevice = new WaveOutEvent())
                        {
                            // Initialize and play the audio
                            outputDevice.Init(audioFile);
                            outputDevice.Play();

                            // Wait until the audio finishes playing
                            while (outputDevice.PlaybackState == PlaybackState.Playing)
                            {
                                System.Threading.Thread.Sleep(100);
                            }
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                // Show an error message if audio playback fails
                MessageBox.Show($"Erro ao tocar áudio: {ex.Message}");
            }
        }
    }
}
