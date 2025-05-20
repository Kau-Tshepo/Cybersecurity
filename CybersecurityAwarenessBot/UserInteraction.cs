using System;

public class UserInteraction
{
    public void DisplayAsciiArt()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
   ___      _                          __          ___ _           _   _           _   
  / __\   _| |__   ___ _ __ ___  __ _ / _| ___    / __\ |__   __ _| |_| |__   ___ | |_ 
 / / | | | | '_ \ / _ \ '__/ __|/ _` | |_ / _ \  / /  | '_ \ / _` | __| '_ \ / _ \| __|
/ /__| |_| | |_) |  __/ |  \__ \ (_| |  _|  __/ / /___| | | | (_| | |_| |_) | (_) | |_ 
\____/\__, |_.__/ \___|_|  |___/\__,_|_|  \___| \____/|_| |_|\__,_|\__|_.__/ \___/ \__|
      |___/                                                                            


   🛡️  Stay Safe | Stay Aware | Cybersecurity Chatbot Activated! 🛡️
");
        Console.ResetColor();
    }

    public string GreetUser()
    {
        Console.Write("👤 Enter your name: ");
        string name = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(name))
        {
            Console.Write("⚠️ Please enter a valid name: ");
            name = Console.ReadLine();
        }

        Console.WriteLine($"\n👋 Welcome, {name}! I'm your Cybersecurity Awareness Bot.\n");
        return name;
    }
}
