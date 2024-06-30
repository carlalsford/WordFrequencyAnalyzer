# WordFrequencyAnalyzer

A library used to determine the frequency that words appear in a given input.
Features include finding highest frequency word, the frequency for any given word, and the 'n' most frequent words for any given text input.

## Usage

```c#
public int GetHighestFrequency(string text)
{
    var analyzer = new WordFrequencyAnalyzer();

    return analyzer.CalculateHighestFrequency(text);
}