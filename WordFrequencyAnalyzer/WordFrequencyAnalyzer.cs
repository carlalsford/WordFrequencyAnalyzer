using System.Text.RegularExpressions;
using WordFrequencyAnalyzer.Interfaces;

namespace WordFrequencyAnalyzer;

public class WordFrequencyAnalyzer : IWordFrequencyAnalyzer
{
    /// <inheritdoc />
    public int CalculateHighestFrequency(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            throw new ArgumentNullException(nameof(text));
        }

        if (!IsEntryValid(text))
        {
            throw new ArgumentException($"{nameof(text)} contains invalid characters.");
        }

        return -1;
    }

    /// <inheritdoc />
    public int CalculateFrequencyForWord(string text, string word)
    {
        if (string.IsNullOrEmpty(text))
        {
            throw new ArgumentNullException(nameof(text));
        }

        if (string.IsNullOrEmpty(word))
        {
            throw new ArgumentNullException(nameof(word));
        }

        if (!IsEntryValid(text))
        {
            throw new ArgumentException($"{nameof(text)} contains invalid characters.");
        }

        if (!IsEntryValid(word))
        {
            throw new ArgumentException($"{nameof(word)} contains invalid characters.");
        }

        return -1;
    }

    /// <inheritdoc />
    public IList<IWordFrequency> CalculateMostFrequentWords(string text, int number)
    {
        if (string.IsNullOrEmpty(text))
        {
            throw new ArgumentNullException(nameof(text));
        }

        if (!IsEntryValid(text))
        {
            throw new ArgumentException($"{nameof(text)} contains invalid characters.");
        }

        if (number < 1)
        {
            throw new ArgumentException($"{nameof(number)} is invalid.");
        }

        return [];
    }

    private bool IsEntryValid(string text)
    {
        return Regex.IsMatch(text.ToLower(), @"^[a-z]+$");
    }
}