namespace TemplateEngine.Tests;

public class TemplateEngineTestSuite
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("Oju")]
    [TestCase("Anju")]
    public void ForOneVariable(string value)
    {
        //Arrange
        TemplateEngine templateEngine = new TemplateEngine();
        templateEngine.setTemplate("Hello {name}");
        templateEngine.setVariable("name", value);

        //Act
        string result = templateEngine.Evaluate();

        //Assert
        Assert.That("Hello "+value, Is.EqualTo(result));
    }

    [TestCase("Ojaswini", "J")]
    public void ForTwoVariable(string firstValue, string secondValue)
    {
        //Arrange
        TemplateEngine templateEngine = new TemplateEngine();
        templateEngine.setTemplate("Hello {firstName} {lastName}");
        templateEngine.setVariable("firstName", firstValue);
        templateEngine.setVariable("lastName", secondValue);

        //Act
        string result = templateEngine.Evaluate();

        //Assert
        Assert.That("Hello " + firstValue + " " + secondValue, Is.EqualTo(result));
    }

    
}
