// This code was generated with the assistance of Claude 3.5 Sonnet
using System;
using System.Threading;

public static class DisplayUtility
{
    public static void DisplayWelcomeScreen()
    {
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════╗");
        Console.WriteLine("║      Welcome to Personality Quest      ║");
        Console.WriteLine("╚═══════════════════════════════════════╝\n");
        
        TypeText(" Discover your unique personality traits through this engaging journey!\n\n");
        TypeText(" Please enter your name (2-12 characters): ");
    }

    public static void DisplayProgress(int current, int total)
    {
        int width = 40;
        int progress = (int)((double)current / total * width);
        string bar = new string('█', progress) + new string('░', width - progress);
        double percentage = ((double)current / total) * 100;
        
        Console.WriteLine($"\n[{bar}] {percentage:F1}%");
    }

    public static void DisplayQuestion(int current, int total, string question, string[] options)
    {
        TypeText($"\nQuestion {current}/{total}:", GameConstants.TypeSpeed);
        TypeText($"\n{question}", GameConstants.TypeSpeed);
        
        for (int i = 0; i < options.Length; i++)
        {
            TypeText($"\n{(char)('A' + i)}. {options[i]}", GameConstants.TypeSpeed);
        }
    }

    public static void TypeText(string text, int speed = GameConstants.TypeSpeed, bool newLine = true)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(speed);
        }
        if (newLine)
        {
            Console.WriteLine();
        }
    }

    public static void DisplayResults(string feedback)
    {
        Console.Clear();
        Console.WriteLine("\n╔═══════════════════════════════════════╗");
        Console.WriteLine("║         Your Personality Profile       ║");
        Console.WriteLine("╚═══════════════════════════════════════╝\n");

        TypeText(feedback);
        
        Console.WriteLine("\n\nPress any key to exit...");
        Console.ReadKey();
    }
}
