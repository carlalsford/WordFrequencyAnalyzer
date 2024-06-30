using WordFrequencyAnalyzer.Interfaces;

namespace WordFrequencyAnalyzer;

public class WordFrequencyAnalyzer : IWordFrequencyAnalyzer
{
    /// <inheritdoc />
    public int CalculateHighestFrequency(string text)
    {
        return -1;
    }

    /// <inheritdoc />
    public int CalculateFrequencyForWord(string text, string word)
    {
        return -1;
    }

    /// <inheritdoc />
    public IList<IWordFrequency> CalculateMostFrequentWords(string text, int number)
    {
        return [];
    }
}