using NUnit.Framework;

[TestFixture]
public class MathOperationsTests
{
    [Test]
    public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
    {
        // Arrange
        int a = 5;
        int b = 10;

        // Act
        int result = MathOperations.Add(a, b);

        // Assert
        Assert.AreEqual(15, result);
    }

    [Test]
    public void Divide_DivisibleNumbers_ReturnsCorrectQuotient()
    {
        // Arrange
        int a = 20;
        int b = 5;

        // Act
        int result = MathOperations.Divide(a, b);

        // Assert
        Assert.AreEqual(4, result);
    }

    // Add more test methods as needed
}
