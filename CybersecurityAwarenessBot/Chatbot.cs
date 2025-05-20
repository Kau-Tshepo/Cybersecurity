using System;
using System.Collections.Generic;

public class ChatBot
{
    private Dictionary<string, List<string>> topicResponses;
    private Dictionary<string, List<string>> followUpQuestions;
    private Dictionary<string, string> userMemory;
    private string currentTopic;
    private Random random;
    private string userTone = "neutral"; // "casual", "formal", or "neutral"

    public ChatBot()
    {
        random = new Random();
        InitializeTopicResponses();
        InitializeFollowUpQuestions();
        userMemory = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        currentTopic = null;
    }

    private void InitializeTopicResponses()
    {
        topicResponses = new Dictionary<string, List<string>>
        {
            ["password"] = new List<string>
            {
                "Make sure to use strong, unique passwords for each account.",
                "Avoid using names or birthdays in your passwords.",
                "Use a password manager to generate and store complex passwords."
            },
            ["scam"] = new List<string>
            {
                "Be cautious of unsolicited messages asking for personal info.",
                "Scammers often pretend to be legitimate companies. Always double-check.",
                "Never click on suspicious links or attachments."
            },
            ["privacy"] = new List<string>
            {
                "Review your privacy settings regularly.",
                "Be cautious about what personal information you share online.",
                "Use tools like VPNs to enhance online privacy."
            },
            ["phishing"] = new List<string>
            {
                "Be wary of emails asking you to verify account information.",
                "Check sender addresses carefully—scammers spoof them.",
                "Don't download attachments unless you're sure of the source."
            },
            ["thankyou"] = new List<string>
            {
                "You're welcome! Stay safe online!",
                "Anytime! I'm here to help.",
                "No problem! Let me know if you have more questions."
            }
        };
    }

    private void InitializeFollowUpQuestions()
    {
        followUpQuestions = new Dictionary<string, List<string>>
        {
            ["password"] = new List<string>
            {
                "Would you like to know how to create a secure password?",
                "Need help choosing a password manager?"
            },
            ["privacy"] = new List<string>
            {
                "Want tips on securing your social media accounts?",
                "Should we talk about data tracking prevention?"
            },
            ["scam"] = new List<string>
            {
                "Do you want to learn how to report online scams?",
                "Would you like examples of common scams?"
            }
        };
    }

    private string FormatResponse(string message)
    {
        switch (userTone)
        {
            case "casual":
                return $"😎 Sure thing! {message}";
            case "formal":
                return $"Certainly. {message}";
            default:
                return message;
        }
    }

    private void DetectTone(string input)
    {
        if (input.Contains("yo") || input.Contains("dude") || input.Contains("what's up") || input.Contains("cool"))
            userTone = "casual";
        else if (input.Contains("please") || input.Contains("kindly") || input.Contains("may I") || input.Contains("would you"))
            userTone = "formal";
    }

    public string GetResponse(string input)
    {
        input = input.ToLower();
        DetectTone(input);

        foreach (var keyword in topicResponses.Keys)
        {
            if (input.Contains(keyword))
            {
                currentTopic = keyword;

                if (!userMemory.ContainsKey("topic"))
                    userMemory["topic"] = keyword;

                var responses = topicResponses[keyword];
                string response = responses[random.Next(responses.Count)];

                string followUp = followUpQuestions.ContainsKey(keyword)
                    ? " " + followUpQuestions[keyword][random.Next(followUpQuestions[keyword].Count)]
                    : "";

                return FormatResponse(response + followUp);
            }
        }

        if (input.Contains("thank you") || input.Contains("thanks"))
        {
            var responses = topicResponses["thankyou"];
            return FormatResponse(responses[random.Next(responses.Count)]);
        }

        if (input.Contains("worried") || input.Contains("frustrated"))
        {
            return FormatResponse("It's completely understandable to feel that way. Let's work through it together.");
        }

        if (input.Contains("curious") || input.Contains("interested"))
        {
            return FormatResponse("Curiosity is great! Let’s dive deeper into that topic.");
        }

        if (currentTopic != null && topicResponses.ContainsKey(currentTopic))
        {
            var extra = topicResponses[currentTopic];
            return FormatResponse(extra[random.Next(extra.Count)]);
        }

        return FormatResponse("I'm not sure I understand. Can you try rephrasing or ask about another cybersecurity topic?");
    }

    public void RememberUserName(string name)
    {
        userMemory["name"] = name;
    }

    public string RecallUserName()
    {
        return userMemory.ContainsKey("name") ? userMemory["name"] : null;
    }

    public string RecallUserTopic()
    {
        return userMemory.ContainsKey("topic") ? userMemory["topic"] : null;
    }
}
