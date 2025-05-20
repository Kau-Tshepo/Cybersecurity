using System;
using System.Media;
using System.IO;

public class AudioManager
{
    public void PlayVoiceGreeting()
    {
        string primaryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greetings\\greeting.wav");
        string fallbackPath = @"C:\Users\Tshep\Music\CybersecurityAwarenessBot\CybersecurityAwarenessBot\greeting\greeting.wav.wav";

        string audioPath = File.Exists(primaryPath) ? primaryPath : fallbackPath;

        Console.WriteLine("\n🔊 Attempting to play audio from: " + audioPath);

        if (!File.Exists(audioPath))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Unable to play greeting audio: File not found at either path.");
            Console.ResetColor();
            return;
        }

        try
        {
            using (SoundPlayer player = new SoundPlayer(audioPath))
            {
                player.PlaySync();
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Error playing audio: " + ex.Message);
            Console.ResetColor();
        }
    }
}
