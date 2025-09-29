using App.Algorithms;

namespace App.Tests;

public class BinarySearchTests
{
	[Fact]
	public void Search_ReturnsCorrectIndex_WhenValueExists()
	{
		var array = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		const int value = 7;
		const int expectedIndex = 6;

		var result = BinarySearch.Search(array, value);

		Assert.Equal(expectedIndex, result);
	}

	[Fact]
	public void Search_ReturnsNegativeOne_WhenValueDoesNotExist()
	{
		var array = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		const int value = 10;
		const int expectedIndex = -1;


		var result = BinarySearch.Search(array, value);


		Assert.Equal(expectedIndex, result);
	}

	[Fact]
	public void Search_ReturnsZero_WhenValueIsFirstElement()
	{
		var array = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		var value = 1;
		var expectedIndex = 0;


		var result = BinarySearch.Search(array, value);


		Assert.Equal(expectedIndex, result);
	}

	[Fact]
	public void Search_ReturnsLastIndex_WhenValueIsLastElement()
	{
		var array = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		var value = 9;
		var expectedIndex = 8;


		var result = BinarySearch.Search(array, value);


		Assert.Equal(expectedIndex, result);
	}

	[Fact]
	public void Search_ReturnsNegativeOne_WhenArrayIsEmpty()
	{
		var array = Array.Empty<int>();
		const int value = 1;
		const int expectedIndex = -1;


		var result = BinarySearch.Search(array, value);


		Assert.Equal(expectedIndex, result);
	}

	[Fact]
	public void Search_ReturnsNegativeOne_WhenValueIsLessThanAllElements()
	{
		var array = new[] { 5, 10, 15, 20, 25 };
		const int value = 3;
		const int expectedIndex = -1;


		var result = BinarySearch.Search(array, value);


		Assert.Equal(expectedIndex, result);
	}

	[Fact]
	public void Search_ReturnsNegativeOne_WhenValueIsGreaterThanAllElements()
	{
		var array = new[] { 5, 10, 15, 20, 25 };
		const int value = 30;
		const int expectedIndex = -1;


		var result = BinarySearch.Search(array, value);


		Assert.Equal(expectedIndex, result);
	}

	[Fact]
	public void Search_ReturnsCorrectIndex_WithDuplicateValues()
	{
		var array = new[] { 1, 2, 2, 2, 5 };
		const int value = 2;
		var possibleIndices = new[] { 1, 2, 3 };


		var result = BinarySearch.Search(array, value);


		Assert.Contains(result, possibleIndices);
	}
}