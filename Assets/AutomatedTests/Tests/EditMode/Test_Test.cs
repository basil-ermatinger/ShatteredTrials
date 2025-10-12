using System.Collections;
using System.Diagnostics;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestTools.Utils;

public class Test_Test
{
  [TestCase(10, 0)]
  [TestCase(-20, 10)]
  [TestCase(5000, 10000)]
  public void AddNumbers_WhenGivenTwoInts_ReturnSum(int numA, int numB)
  {
    // Arrange
    Calculator calculator = new Calculator();

    // Act
    int actual = calculator.AddNumbers(numA, numB);

    // Assert
    Assert.AreEqual(numA + numB, actual, "Adding two numbers didn't produce the expected result");
  }

  [Test]
  public void GetPI_WhenCalled_ReturnsPI()
  {
    // Arrange
    Calculator calculator = new Calculator();

    // Act
    float actual = calculator.GetPI();

    // Assert
    FloatEqualityComparer floatEqualityComparer = new FloatEqualityComparer(0.01f);
    Assert.That(actual, Is.EqualTo(3.14f).Using(floatEqualityComparer));
  }

  [Test]
  public void DivideNumber_WhenDivideByZero_ReturnsError()
  {
    // Arrange
    Calculator calculator = new Calculator();

    // Act
    float actual = calculator.DivideNumbers(10, 0);

    // Assert
    LogAssert.Expect(LogType.Error, "Cannot divide by zero!");
  }
}
