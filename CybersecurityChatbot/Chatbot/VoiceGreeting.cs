using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows; // Para o MessageBox temporário de erro
using NAudio.Wave;

namespace CybersecurityChatbot.Chatbot
{
    public class VoiceGreeting
    {
        // Mudamos para async Task para não travar a interface do usuário
        public async Task PlayGreetingAsync()
        {
            try
            {
                string path = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Audio",
                    "greeting.wav");

                if (!File.Exists(path))
                {
                    // Alerta temporário para você saber se o arquivo sumiu
                    MessageBox.Show($"Arquivo não encontrado em: {path}");
                    return;
                }

                // Usamos Task.Run para processar o áudio fora da Thread principal (UI)
                await Task.Run(() =>
                {
                    using (var audioFile = new AudioFileReader(path))
                    {
                        using (var outputDevice = new WaveOutEvent())
                        {
                            outputDevice.Init(audioFile);
                            outputDevice.Play();

                            // Aguarda o áudio terminar sem travar o processador
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
                // Mostra o erro real se algo der errado com o NAudio
                MessageBox.Show($"Erro ao tocar áudio: {ex.Message}");
            }
        }
    }
}