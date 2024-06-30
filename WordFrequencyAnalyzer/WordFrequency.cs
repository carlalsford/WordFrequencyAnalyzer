using WordFrequencyAnalyzer.Interfaces;

namespace WordFrequencyAnalyzer;

public class WordFrequency : IWordFrequency
{
    public string Word { get; set; }
    public int Frequency { get; set; }
}