using FluentAssertions;
using WordFrequencyAnalyzer.Interfaces;

namespace WordFrequencyAnalyzer.Tests;

[TestClass]
public class WordFrequencyAnalyzerTests
{
    #region Test Setup & Helpers

    private WordFrequencyAnalyzer? analyzer;
    private string ValidTestString = "The Sun Shines Over The Lake"; // Mixed case - tests set to lower/upper as required
    private string ShortValidTestString = "lake and lake";
    private string InvalidTestString = "The sun shines over the lake."; // invalid due to .

    [TestInitialize]
    public void Initialize()
    {
        analyzer = new WordFrequencyAnalyzer();
    }

    private IWordFrequency GenerateWordFrequency(string word, int frequency)
    {
        return new WordFrequency
        {
            Frequency = frequency,
            Word = word
        };
    }

    #endregion

    #region CalculateHighestFrequency Tests

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void CalculateHighestFrequency_NullEntry_ThrowsArgumentNullException()
    {
        // Arrange

        // Act
        var result = analyzer!.CalculateHighestFrequency(null!);

        // Assert

    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CalculateHighestFrequency_EmptyEntry_ThrowsArgumentException()
    {
        // Arrange

        // Act
        var result = analyzer!.CalculateHighestFrequency(string.Empty);

        // Assert

    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CalculateHighestFrequency_InvalidEntry_ThrowsArgumentException()
    {
        // Arrange

        // Act
        var result = analyzer!.CalculateHighestFrequency(InvalidTestString);

        // Assert
    }

    [TestMethod]
    public void CalculateHighestFrequency_ValidEntry_ReturnsCorrectValue()
    {
        // Arrange
        var total = 2;

        // Act
        var result = analyzer!.CalculateHighestFrequency(ValidTestString);

        // Assert
        result.Should().Be(total, $"because it exists {total} times in the {ValidTestString}");
    }

    [TestMethod]
    public void CalculateHighestFrequency_UpperValidEntry_ReturnsCorrectValue()
    {
        // Arrange
        var total = 2;

        // Act
        var result = analyzer!.CalculateHighestFrequency(ValidTestString.ToUpperInvariant());

        // Assert
        result.Should().Be(total, $"because it exists {total} times in the {ValidTestString}");
    }

    [TestMethod]
    public void CalculateHighestFrequency_LowerValidEntry_ReturnsCorrectValue()
    {
        // Arrange
        var total = 2;

        // Act
        var result = analyzer!.CalculateHighestFrequency(ValidTestString.ToLowerInvariant().ToUpperInvariant());

        // Assert
        result.Should().Be(total, $"because it exists {total} times in the {ValidTestString}");
    }

    #endregion

    #region CalculateFrequencyForWord Tests

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void CalculateFrequencyForWord_NullText_ThrowsArgumentNullException()
    {
        // Arrange
        var testWord = "the";

        // Act
        var result = analyzer!.CalculateFrequencyForWord(null!, testWord);

        // Assert

    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CalculateFrequencyForWord_EmptyText_ThrowsArgumentException()
    {
        // Arrange
        var testWord = "the";

        // Act
        var result = analyzer!.CalculateFrequencyForWord(string.Empty, testWord);

        // Assert

    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CalculateFrequencyForWord_EmptyWord_ThrowsArgumentException()
    {
        // Arrange
        var testWord = string.Empty;

        // Act
        var result = analyzer!.CalculateFrequencyForWord(string.Empty, testWord);

        // Assert

    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CalculateFrequencyForWord_InvalidText_ThrowsArgumentException()
    {
        // Arrange
        var testWord = "the";

        // Act
        var result = analyzer!.CalculateFrequencyForWord(InvalidTestString, testWord);

        // Assert

    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CalculateFrequencyForWord_InvalidWord_ThrowsArgumentException()
    {
        // Arrange
        var testWord = string.Empty;

        // Act
        var result = analyzer!.CalculateFrequencyForWord(ValidTestString, testWord);

        // Assert

    }

    [TestMethod]
    public void CalculateFrequencyForWord_ValidTextWithoutWord_Returns0()
    {
        // Arrange
        var testWord = "them";

        // Act
        var result = analyzer!.CalculateFrequencyForWord(ValidTestString, testWord);

        // Assert
        result.Should().Be(0, $"because it doesn't exist in the {ValidTestString}");
    }

    [TestMethod]
    public void CalculateFrequencyForWord_UpperValidTextWithoutWord_Returns0()
    {
        // Arrange
        var testWord = "them";

        // Act
        var result = analyzer!.CalculateFrequencyForWord(ValidTestString.ToUpperInvariant(), testWord);

        // Assert
        result.Should().Be(0, $"because it doesn't exist in the {ValidTestString}");
    }

    [TestMethod]
    public void CalculateFrequencyForWord_LowerValidTextWithoutWord_Returns0()
    {
        // Arrange
        var testWord = "them";

        // Act
        var result = analyzer!.CalculateFrequencyForWord(ValidTestString.ToLowerInvariant(), testWord);

        // Assert
        result.Should().Be(0, $"because it doesn't exist in the {ValidTestString}");
    }

    [TestMethod]
    public void CalculateFrequencyForWord_ValidTextWithWord_ReturnsCorrectValue()
    {
        // Arrange
        var testWord = "the";
        var total = 2;

        // Act
        var result = analyzer!.CalculateFrequencyForWord(ValidTestString, testWord);

        // Assert
        result.Should().Be(total);
    }

    [TestMethod]
    public void CalculateFrequencyForWord_UpperValidTextWithWord_ReturnsCorrectValue()
    {
        // Arrange
        var testWord = "the";
        var total = 2;

        // Act
        var result = analyzer!.CalculateFrequencyForWord(ValidTestString.ToUpperInvariant(), testWord);

        // Assert
        result.Should().Be(total);
    }

    [TestMethod]
    public void CalculateFrequencyForWord_LowerValidTextWithWord_ReturnsCorrectValue()
    {
        // Arrange
        var testWord = "the";
        var total = 2;

        // Act
        var result = analyzer!.CalculateFrequencyForWord(ValidTestString.ToLowerInvariant(), testWord);

        // Assert
        result.Should().Be(total);
    }

    [TestMethod]
    public void CalculateFrequencyForWord_LowerValidTextWithUpperWord_ReturnsCorrectValue()
    {
        // Arrange
        var testWord = "the";
        var total = 2;

        // Act
        var result = analyzer!.CalculateFrequencyForWord(ValidTestString.ToLowerInvariant(), testWord.ToUpperInvariant());

        // Assert
        result.Should().Be(total);
    }

    #endregion

    #region CalculateMostFrequentWords Tests

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void CalculateMostFrequentWords_NullText_ThrowsArgumentNullException()
    {
        // Arrange

        // Act
        var result = analyzer!.CalculateMostFrequentWords(null!, 1);

        // Assert

    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CalculateMostFrequentWords_EmptyText_ThrowsArgumentException()
    {
        // Arrange

        // Act
        var result = analyzer!.CalculateMostFrequentWords(string.Empty, 1);
        
        // Assert

    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CalculateMostFrequentWords_InvalidText_ThrowsArgumentException()
    {
        // Arrange

        // Act
        var result = analyzer!.CalculateMostFrequentWords(InvalidTestString, 1);

        // Assert

    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CalculateMostFrequentWords_InvalidNumber_ThrowsArgumentException()
    {
        // Arrange

        // Act
        var result = analyzer!.CalculateMostFrequentWords(string.Empty, 0);

        // Assert

    }

    [TestMethod]
    public void CalculateMostFrequentWords_ValidTextWithMoreWordsThanNumber_ReturnsNumberOfEntries()
    {
        // Arrange
        var total = 2;
        var expected = new List<IWordFrequency>
        {
            GenerateWordFrequency("the", 2),
            GenerateWordFrequency("lake", 1)
        };

        // Act
        var result = analyzer!.CalculateMostFrequentWords(ValidTestString, total);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void CalculateMostFrequentWords_UpperValidTextWithMoreWordsThanNumber_ReturnsNumberOfEntries()
    {
        // Arrange
        var total = 2;
        var expected = new List<IWordFrequency>
        {
            GenerateWordFrequency("the", 2),
            GenerateWordFrequency("lake", 1)
        };

        // Act
        var result = analyzer!.CalculateMostFrequentWords(ValidTestString.ToUpperInvariant(), total);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void CalculateMostFrequentWords_LowerValidTextWithMoreWordsThanNumber_ReturnsNumberOfEntries()
    {
        // Arrange
        var total = 2;
        var expected = new List<IWordFrequency>
        {
            GenerateWordFrequency("the", 2),
            GenerateWordFrequency("lake", 1)
        };

        // Act
        var result = analyzer!.CalculateMostFrequentWords(ValidTestString.ToLowerInvariant(), total);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void CalculateMostFrequentWords_ValidTextWithSameWordsAsNumber_ReturnsNumberOfEntries()
    {
        // Arrange
        var total = 2;
        var expected = new List<IWordFrequency>
        {
            GenerateWordFrequency("lake", 2),
            GenerateWordFrequency("and", 1)
        };

        // Act
        var result = analyzer!.CalculateMostFrequentWords(ShortValidTestString, total);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void CalculateMostFrequentWords_ValidTextWithMoreLessThanNumber_ReturnsNumberOfWords()
    {
        // Arrange
        var total = 3;
        var expected = new List<IWordFrequency>
        {
            GenerateWordFrequency("lake", 2),
            GenerateWordFrequency("and", 1)
        };

        // Act
        var result = analyzer!.CalculateMostFrequentWords(ShortValidTestString, total);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    #endregion
}
