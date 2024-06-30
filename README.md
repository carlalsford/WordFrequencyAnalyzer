# WordFrequencyAnalyzer

A library used to determine the frequency that words appear in a given input.
Features include:
* Finding highest frequency word
* Finding the frequency for any given word
* Finding the 'n' most frequent words for any given text input
    * This sorts by frequency, then alphabetically.

## Usage

```c#
public int GetHighestFrequency()
{
    var analyzer = new WordFrequencyAnalyzer();
    var text = "The sun shines over the lake";

    return analyzer.CalculateHighestFrequency(text); // returns 2, for 'the'
}

public int GetFrequency()
{
    var analyzer = new WordFrequencyAnalyzer();
    var text = "The sun shines over the lake";

    return analyzer.CalculateFrequencyForWord(text, "THE"); // returns 2
}

public void Find2MostFrequentWords()
{
    var analyzer = new WordFrequencyAnalyzer();
    var text = "The sun shines over the lake";

    var results = analyzer.CalculateMostFrequentWords(text, 2); // results in a list of IWordFrequency of size 2. 'The' with a frequency of 2, and 'lake' with a frequency of 1
}