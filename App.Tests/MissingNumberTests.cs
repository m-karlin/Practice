using App.Problems;

namespace App.Tests;

public class MissingNumberTests
{
	[Fact]
	public void Test1()
	{
		var result = MissingNumber.Find([3, 0, 1]);
		Assert.Equal(2, result);
	}

	[Fact]
	public void Test2()
	{
		var result = MissingNumber.Find([0, 1]);
		Assert.Equal(2, result);
	}
}