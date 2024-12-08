// This code was generated with the assistance of Claude 3.5 Sonnet
using System;
using System.Collections.Generic;
using System.Linq;

public class Player
{
    private readonly List<int> _answers = new();
    private readonly Dictionary<string, (string Primary, string Secondary)> _traitDescriptions = new()
    {
        { "Action", (
            "You are a natural leader who thrives on action and quick decisions. You have a strong drive to make things happen and aren't afraid to take risks.",
            "Your adaptability and practical approach help you navigate challenges effectively. You learn best through hands-on experience."
        )},
        { "Social", (
            "You have exceptional interpersonal skills and a deep understanding of others' emotions. Your empathy makes you a valuable team member and friend.",
            "Your ability to build and maintain relationships creates a supportive environment. You excel at bringing people together and fostering cooperation."
        )},
        { "Creative", (
            "You possess a vibrant imagination and an innovative approach to problem-solving. Your unique perspective brings fresh ideas to any situation.",
            "Your artistic sensibility and originality allow you to see possibilities others might miss. You naturally think outside conventional boundaries."
        )},
        { "Analytical", (
            "You excel at logical analysis and systematic problem-solving. Your methodical approach helps you understand complex situations clearly.",
            "Your attention to detail and critical thinking skills make you an excellent strategist. You naturally seek deeper understanding in all matters."
        )}
    };

    public string Name { get; set; } = string.Empty;

    public void AddAnswer(int answer)
    {
        if (answer < 1 || answer > 4)
            throw new ArgumentException("Answer must be between 1 and 4", nameof(answer));

        _answers.Add(answer);
    }

    private Dictionary<string, int> CalculateTraitScores()
    {
        var scores = new Dictionary<string, int>
        {
            { "Action", 0 },
            { "Social", 0 },
            { "Creative", 0 },
            { "Analytical", 0 }
        };

        foreach (var answer in _answers)
        {
            switch (answer)
            {
                case 1: scores["Action"]++; break;
                case 2: scores["Social"]++; break;
                case 3: scores["Creative"]++; break;
                case 4: scores["Analytical"]++; break;
            }
        }

        return scores;
    }

    private string GetGrowthSuggestion(string trait)
    {
        return trait switch
        {
            "Action" => "Consider taking time to reflect before acting. Balance your natural drive with strategic planning.",
            "Social" => "Practice setting boundaries while maintaining your caring nature. Develop your own goals alongside helping others.",
            "Creative" => "Work on implementing your ideas systematically. Transform your creative visions into concrete plans.",
            "Analytical" => "Allow yourself to trust intuition occasionally. Balance detailed analysis with quick decision-making when needed.",
            _ => throw new ArgumentException("Invalid trait type", nameof(trait))
        };
    }

    public string GetDetailedFeedback()
    {
        var scores = CalculateTraitScores();
        var dominantTrait = scores.OrderByDescending(x => x.Value).First().Key;
        var descriptions = _traitDescriptions[dominantTrait];

        return $"╔═══ Your Primary Traits ═══╗\n" +
               $"{descriptions.Primary}\n" +
               $"╚════════════════════════╝\n\n" +
               $"╔═══ Your Secondary Traits ═══╗\n" +
               $"{descriptions.Secondary}\n" +
               $"╚═════════════════════════╝\n\n" +
               $"Growth Path\n" +
               $"{GetGrowthSuggestion(dominantTrait)}";
    }
}
