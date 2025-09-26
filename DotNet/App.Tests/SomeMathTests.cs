using App.Problems;

namespace App.Tests;

public class SomeMathTests
{
    [Fact]
    public void IsPrime_ReturnsTrue_ForPrimeNumbers()
    {
        
        var primeNumbers = new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };

        foreach (var number in primeNumbers)
        {
            Assert.True(SomeMath.IsPrime(number), $"{number} should be prime");
        }
    }

    [Fact]
    public void IsPrime_ReturnsFalse_ForNonPrimeNumbers()
    {
        
        var nonPrimeNumbers = new[] { 1, 4, 6, 8, 9, 10, 12, 14, 15, 16, 18, 20, 21, 22, 24, 25, 26, 27, 28 };

        foreach (var number in nonPrimeNumbers)
        {
            Assert.False(SomeMath.IsPrime(number), $"{number} should not be prime");
        }
    }

    [Fact]
    public void IsPrime_ReturnsFalse_ForNegativeNumbers()
    {
        
        var negativeNumbers = new[] { -1, -2, -3, -4, -5 };

        foreach (var number in negativeNumbers)
        {
            Assert.False(SomeMath.IsPrime(number), $"{number} should not be prime");
        }
    }

    [Fact]
    public void RFactorial_ReturnsCorrectValues()
    {
        
        var testCases = new (int input, long expected)[]
        {
            (0, 1),
            (1, 1),
            (2, 2),
            (3, 6),
            (4, 24),
            (5, 120),
            (6, 720)
        };

        foreach (var (input, expected) in testCases)
        {
            var result = SomeMath.RFactorial(input);
            Assert.Equal(expected, result);
        }
    }

    [Fact]
    public void IFactorial_ReturnsCorrectValues()
    {
        
        var testCases = new (int input, long expected)[]
        {
            (0, 1),
            (1, 1),
            (2, 2),
            (3, 6),
            (4, 24),
            (5, 120),
            (6, 720)
        };

        foreach (var (input, expected) in testCases)
        {
            var result = SomeMath.IFactorial(input);
            Assert.Equal(expected, result);
        }
    }

    [Fact]
    public void Fibonacci_ReturnsCorrectValues()
    {
        
        var testCases = new (int input, int expected)[]
        {
            (0, 0),
            (1, 1),
            (2, 1),
            (3, 2),
            (4, 3),
            (5, 5),
            (6, 8),
            (7, 13),
            (8, 21),
            (9, 34),
            (10, 55)
        };

        foreach (var (input, expected) in testCases)
        {
            var result = SomeMath.Fibonacci(input);
            Assert.Equal(expected, result);
        }
    }

    [Fact]
    public void GetDistance_ReturnsCorrectDistance()
    {
        
        var testCases = new (int x1, int y1, int x2, int y2, double expected)[]
        {
            (0, 0, 3, 4, 5.0),
            (1, 1, 4, 5, 5.0),
            (0, 0, 0, 0, 0.0),
            (-1, -1, 2, 3, 5.0),
            (0, 0, 1, 1, Math.Sqrt(2))
        };

        foreach (var (x1, y1, x2, y2, expected) in testCases)
        {
            var result = SomeMath.GetDistance(x1, y1, x2, y2);
            Assert.Equal(expected, result, 10); // Проверка с точностью до 10 знаков после запятой
        }
    }
}