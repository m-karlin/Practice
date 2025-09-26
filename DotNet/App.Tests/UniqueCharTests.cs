using App.Problems;

namespace App.Tests;

public class UniqueCharTests
{
    [Fact]
    public void FindIndex_ReturnsCorrectIndex_WhenUniqueCharExists()
    {
        var input = "job";
        var expected = 0;

        var result = UniqueChar.UniqueCharFinder.FindIndex(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void FindIndex_ReturnsNegativeOne_WhenNoUniqueCharExists()
    {
        var input = "aabb";
        var expected = -1;

        var result = UniqueChar.UniqueCharFinder.FindIndex(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void FindIndex_ReturnsCorrectIndex_WhenUniqueCharInMiddle()
    {
        var input = "aacbbd";
        var expected = 2;

        var result = UniqueChar.UniqueCharFinder.FindIndex(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void FindIndex_ReturnsZero_WhenFirstCharIsUnique()
    {
        var input = "abcdef";
        var expected = 0;

        var result = UniqueChar.UniqueCharFinder.FindIndex(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void FindIndex_ReturnsLastIndex_WhenLastCharIsUnique()
    {

        var input = "aabbccdef";
        var expected = 6;


        var result = UniqueChar.UniqueCharFinder.FindIndex(input);


        Assert.Equal(expected, result);
    }

    [Fact]
    public void FindIndex_ReturnsNegativeOne_WhenStringIsEmpty()
    {

        var input = "";
        var expected = -1;


        var result = UniqueChar.UniqueCharFinder.FindIndex(input);


        Assert.Equal(expected, result);
    }

    [Fact]
    public void FindIndex_ReturnsNegativeOne_WhenAllCharsAreSame()
    {

        var input = "aaaa";
        var expected = -1;


        var result = UniqueChar.UniqueCharFinder.FindIndex(input);


        Assert.Equal(expected, result);
    }

    [Fact]
    public void FindIndex_ReturnsCorrectIndex_WithSingleCharacter()
    {

        var input = "a";
        var expected = 0;


        var result = UniqueChar.UniqueCharFinder.FindIndex(input);


        Assert.Equal(expected, result);
    }
}