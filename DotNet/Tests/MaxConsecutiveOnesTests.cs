using App.Problems;

namespace App.Tests;

public class MaxConsecutiveOnesTests
{
    [Fact]
    public void Calculate_ReturnsCorrectMaxConsecutiveOnes()
    {
        
        var nums = new[] { 1, 1, 0, 1, 1, 1 };
        var expected = 3;

        
        var result = MaxConsecutiveOnes.Calculate(nums);

        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Calculate_ReturnsZero_WhenNoOnesInArray()
    {
        
        var nums = new[] { 0, 0, 0, 0 };
        var expected = 0;

        
        var result = MaxConsecutiveOnes.Calculate(nums);

        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Calculate_ReturnsCorrectValue_WhenOnesAtEnd()
    {
        
        var nums = new[] { 0, 0, 1, 1, 1, 1 };
        var expected = 4;

        
        var result = MaxConsecutiveOnes.Calculate(nums);

        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Calculate_ReturnsCorrectValue_WhenOnesAtBeginning()
    {
        
        var nums = new[] { 1, 1, 1, 0, 0, 0 };
        var expected = 3;

        
        var result = MaxConsecutiveOnes.Calculate(nums);

        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Calculate_ReturnsZero_WhenArrayIsEmpty()
    {
        
        var nums = new int[0];
        var expected = 0;

        
        var result = MaxConsecutiveOnes.Calculate(nums);

        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Calculate_ReturnsOne_WhenSingleOneInArray()
    {
        
        var nums = new[] { 0, 1, 0, 0 };
        var expected = 1;

        
        var result = MaxConsecutiveOnes.Calculate(nums);

        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Calculate_ReturnsCorrectValue_WhenAllOnes()
    {
        
        var nums = new[] { 1, 1, 1, 1, 1 };
        var expected = 5;

        
        var result = MaxConsecutiveOnes.Calculate(nums);

        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Calculate_ReturnsCorrectValue_WithMultipleGroups()
    {
        
        var nums = new[] { 1, 1, 0, 1, 1, 1, 0, 1 };
        var expected = 3;

        
        var result = MaxConsecutiveOnes.Calculate(nums);

        
        Assert.Equal(expected, result);
    }
}