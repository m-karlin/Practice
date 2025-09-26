using App.Problems;

namespace App.Tests;

public class MissingNumberTests
{
	[Fact]
	public void Find_ReturnsMissingNumber_InArrayWithMissingMiddleNumber()
	{
		var result = MissingNumber.Find([3, 0, 1]);
		Assert.Equal(2, result);
	}

	[Fact]
	public void Find_ReturnsMissingNumber_InArrayWithMissingLastNumber()
	{
		var result = MissingNumber.Find([0, 1]);
		Assert.Equal(2, result);
	}
}