using Ardalis.GuardClauses;
using System.Text.RegularExpressions;
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

        return -1;
    }

    /// <inheritdoc />
    public int CalculateFrequencyForWord(string text, string word)
    {
        Guard.Against.NullOrWhiteSpace(text);
        Guard.Against.NullOrWhiteSpace(word);
        Guard.Against.InvalidFormat(text.ToLowerInvariant(), nameof(text), ValidationRule);
        Guard.Against.InvalidFormat(word.ToLowerInvariant(), nameof(word), ValidationRule);

        return -1;
    }

    /// <inheritdoc />
    public IList<IWordFrequency> CalculateMostFrequentWords(string text, int number)
    {
        Guard.Against.NullOrWhiteSpace(text);
        Guard.Against.InvalidFormat(text.ToLowerInvariant(), nameof(text), ValidationRule);
        Guard.Against.NegativeOrZero(number);

        return [];
    }
}