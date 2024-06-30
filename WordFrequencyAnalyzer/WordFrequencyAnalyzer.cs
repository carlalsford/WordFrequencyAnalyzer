using Ardalis.GuardClauses;
using WordFrequencyAnalyzer.Interfaces;

namespace WordFrequencyAnalyzer;

public class WordFrequencyAnalyzer : IWordFrequencyAnalyzer
{
    private string TextValidationRule = @"^[a-z ]+$"; // text can be a-z with spaces
    private string WordValidationRule = @"^[a-z]+$"; // words can only be a-z

    /// <inheritdoc />
    public int CalculateHighestFrequency(string text)
    {
        Guard.Against.NullOrWhiteSpace(text);
        Guard.Against.InvalidFormat(text.ToLowerInvariant(), nameof(text), TextValidationRule);

        return GenerateWordFrequencies(text).Values.Max();
    }

    /// <inheritdoc />
    public int CalculateFrequencyForWord(string text, string word)
    {
        Guard.Against.NullOrWhiteSpace(text);
        Guard.Against.NullOrWhiteSpace(word);
        Guard.Against.InvalidFormat(text.ToLowerInvariant(), nameof(text), TextValidationRule);
        Guard.Against.InvalidFormat(word.ToLowerInvariant(), nameof(word), WordValidationRule);

        var wordFrequencies = GenerateWordFrequencies(text);

        if (wordFrequencies.TryGetValue(word.ToLowerInvariant(), out var value))
        {
            return value;
        }

        return 0;
    }

    /// <inheritdoc />
    public IList<IWordFrequency> CalculateMostFrequentWords(string text, int number)
    {
        Guard.Against.NullOrWhiteSpace(text);
        Guard.Against.InvalidFormat(text.ToLowerInvariant(), nameof(text), TextValidationRule);
        Guard.Against.NegativeOrZero(number);

        return GenerateWordFrequencies(text)
                .OrderByDescending(wf => wf.Value)
                .ThenBy(wf => wf.Key)
                .Take(number)
                .Select(wf => new WordFrequency { Word = wf.Key, Frequency = wf.Value})
                .ToList<IWordFrequency>();
    }

    private Dictionary<string, int> GenerateWordFrequencies(string text)
    {
        var textEntries = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(entry => entry.ToLower());

        var wordFrequencies = new Dictionary<string, int>();

        foreach (var word in textEntries)
        {
            if (wordFrequencies.TryGetValue(word, out var value))
            {
                wordFrequencies[word] = ++value;
            }
            else
            {
                wordFrequencies[word] = 1;
            }
        }

        return wordFrequencies;
    }
}