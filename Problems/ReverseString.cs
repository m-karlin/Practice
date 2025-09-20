namespace Practice.Problems;

// https://solvit.space/coding/2873
public class ReverseStringTests
{
	private static void ReverseString(string[] s)
	{
		var i = 0;
		var j = s.Length - 1;
		while (i <= j)
		{
			string t = s[j];
			s[j] = s[i];
			s[i] = t;
			i++;
			j--;
		}
	}

	[Fact]
	public void Test()
	{
		string[] s = ["H", "a", "n", "n", "a", "h"];
		ReverseString(s);
		Assert.Equal(["h","a","n","n","a","H"], s);
	}
}