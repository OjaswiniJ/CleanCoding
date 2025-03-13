using Moq;

namespace PredictionEngine.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("Hello how are y","y")]
    [TestCase("Hello how are you doing", "doing")]
    [TestCase("", "")]
    public void ShouldCallUsingUnigramWhenInputIsPartialWord(string inputString, string lastWord)
    {
        var mockAlgo = new Mock<ILanguageModelAlgo>();

        PredictionEngine predictionEngine = new PredictionEngine(mockAlgo.Object);

        String predictWord = predictionEngine.Predict(inputString);

        mockAlgo.Verify(p => p.predictUsingMonogram(lastWord), Times.Once());
    }

    [TestCase("Hello how are you ", "you")]
    [TestCase(" ", "")]
    public void ShouldCallBigramWhenInputIsEndingWithSpace(string inputString, string lastWord)
    {
        var mockAlgo = new Mock<ILanguageModelAlgo>();

        PredictionEngine predictionEngine = new PredictionEngine(mockAlgo.Object);

        String predictWord = predictionEngine.Predict(inputString);

        mockAlgo.Verify(p => p.predictUsingBigram(lastWord), Times.Once());
    }
}
