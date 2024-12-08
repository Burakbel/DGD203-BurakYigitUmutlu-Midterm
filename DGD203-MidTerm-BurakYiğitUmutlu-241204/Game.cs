// This code was generated with the assistance of Claude 3.5 Sonnet
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class Game
{
    private readonly List<(string Question, string[] Options)> _questions;
    private readonly Player _player;

    public Game()
    {
        _questions = QuestionBank.GetQuestions();
        _player = new Player();
    }

    public void Start()
    {
        Console.Clear();
        DisplayUtility.DisplayWelcomeScreen();
        GetPlayerName();
        RunQuestionnaireLoop();
        DisplayUtility.DisplayResults(_player.GetDetailedFeedback());
    }

    private void GetPlayerName()
    {
        while (true)
        {
            string? name = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(name) || name.Length < GameConstants.MinNameLength || name.Length > GameConstants.MaxNameLength)
            {
                DisplayUtility.TypeText($"\nName must be between {GameConstants.MinNameLength} and {GameConstants.MaxNameLength} characters long. Please try again: ");
                continue;
            }

            _player.Name = name;
            DisplayUtility.TypeText($"\nWelcome, {name}! Let's begin your journey of self-discovery!\n");
            Thread.Sleep(1500);
            break;
        }
    }

    private void RunQuestionnaireLoop()
    {
        for (int i = 0; i < _questions.Count; i++)
        {
            Console.Clear();
            var (question, options) = _questions[i];
            DisplayUtility.DisplayProgress(i + 1, _questions.Count);
            DisplayUtility.DisplayQuestion(i + 1, _questions.Count, question, options);
            ProcessPlayerAnswer();
        }
    }

    private void ProcessPlayerAnswer()
    {
        while (true)
        {
            DisplayUtility.TypeText("\nYour choice (A-D): ", GameConstants.TypeSpeed, false);
            var input = Console.ReadLine()?.Trim().ToUpper();

            if (input?.Length == 1 && input[0] >= 'A' && input[0] <= 'D')
            {
                int selectedOption = input[0] - 'A' + 1;
                _player.AddAnswer(selectedOption);
                Thread.Sleep(500);
                break;
            }

            DisplayUtility.TypeText("\nInvalid input. Please choose A, B, C, or D.");
        }
    }
}
