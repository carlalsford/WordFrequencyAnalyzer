using Ardalis.GuardClauses;
using WordFrequencyAnalyzer.Interfaces;

namespace WordFrequencyAnalyzer;

public class WordFrequencyAnalyzer : IWordFrequencyAnalyzer
{
    private string ValidationRule = @"^[a-z ]+$";

    /// <inheritdoc />
    public int CalculateHighestFrequency(string text)
    {
        Guard.Against.NullOrWhiteSpace(text);
        Guard.Against.InvalidFormat(text.ToLowerInvariant(), nameof(text), ValidationRule);

        return GenerateWordFrequencies(text).Values.Max();
    }

    /// <inheritdoc />
    public int CalculateFrequencyForWord(string text, string word)
    {
        Guard.Against.NullOrWhiteSpace(text);
        Guard.Against.NullOrWhiteSpace(word);
        Guard.Against.InvalidFormat(text.ToLowerInvariant(), nameof(text), ValidationRule);
        Guard.Against.InvalidFormat(word.ToLowerInvariant(), nameof(word), ValidationRule);

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
        Guard.Against.InvalidFormat(text.ToLowerInvariant(), nameof(text), ValidationRule);
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
        var entries = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(entry => entry.ToLower());

        var frequencies = new Dictionary<string, int>();

        foreach (var entry in entries)
        {
            if (frequencies.TryGetValue(entry, out var value))
            {
                frequencies[entry] = ++value;
            }
            else
            {
                frequencies[entry] = 1;
            }
        }

        return frequencies;
    }
}