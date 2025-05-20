using System;

class Program
{
    static void Main()
    {
        AudioManager audioManager = new AudioManager();
        audioManager.PlayVoiceGreeting();

        UserInteraction userInteraction = new UserInteraction();
        userInteraction.DisplayAsciiArt();
        string userName = userInteraction.GreetUser();

        ChatBot chatBot = new ChatBot();
        chatBot.DisplayQuestionList();

        RunChatLoop(chatBot, userName);
    }

    static void RunChatLoop(ChatBot chatBot, string userName)
    {
        while (true)
        {
            Console.Write("\n💬 Ask a question or type 'exit': ");
            string input = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("⚠️ Please enter something.");
                continue;
            }

            if (input == "exit") break;

            string response = chatBot.GetResponse(input, userName);
            Console.WriteLine(response);
        }
    }
}
