using App.Problems;

namespace App.Tests;

public class ReverseStringTests
{
    [Fact]
    public void Reverse_CorrectlyReversesStringArray()
    {
        
        var s = new[] { "h", "e", "l", "l", "o" };
        var expected = new[] { "o", "l", "l", "e", "h" };

        
        ReverseString.Reverse(s);

        
        Assert.Equal(expected, s);
    }

    [Fact]
    public void Reverse_CorrectlyReversesSingleCharacterArray()
    {
        
        var s = new[] { "a" };
        var expected = new[] { "a" };

        
        ReverseString.Reverse(s);

        
        Assert.Equal(expected, s);
    }

    [Fact]
    public void Reverse_CorrectlyReversesTwoCharacterArray()
    {
        
        var s = new[] { "a", "b" };
        var expected = new[] { "b", "a" };

        
        ReverseString.Reverse(s);

        
        Assert.Equal(expected, s);
    }

    [Fact]
    public void Reverse_CorrectlyReversesPalindrome()
    {
        
        var s = new[] { "r", "a", "c", "e", "c", "a", "r" };
        var expected = new[] { "r", "a", "c", "e", "c", "a", "r" };

        
        ReverseString.Reverse(s);

        
        Assert.Equal(expected, s);
    }

    [Fact]
    public void Reverse_CorrectlyReversesEmptyArray()
    {
        
        var s = new string[0];
        var expected = new string[0];

        
        ReverseString.Reverse(s);

        
        Assert.Equal(expected, s);
    }

    [Fact]
    public void Reverse_CorrectlyReversesArrayWithDuplicateCharacters()
    {
        
        var s = new[] { "a", "a", "b", "b", "a", "a" };
        var expected = new[] { "a", "a", "b", "b", "a", "a" };

        
        ReverseString.Reverse(s);

        
        Assert.Equal(expected, s);
    }

    [Fact]
    public void Reverse_CorrectlyReversesArrayWithMixedCase()
    {
        
        var s = new[] { "H", "e", "L", "l", "O" };
        var expected = new[] { "O", "l", "L", "e", "H" };

        
        ReverseString.Reverse(s);

        
        Assert.Equal(expected, s);
    }
}