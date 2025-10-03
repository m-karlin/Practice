using System.Collections;

namespace App.Structures;

public class MyStack : IEnumerable<int>
{
	private const int DefaultCapacity = 4;
	private int[] _items;
	private int _top;

	public MyStack(int capacity = DefaultCapacity)
	{
		if (capacity < 0)
			throw new ArgumentOutOfRangeException(nameof(capacity), "Емкость не может быть отрицательной.");

		_items = new int[capacity];
		_top = -1;
	}

	public void Push(int item)
	{
		if (_top == _items.Length - 1)
		{
			var newCapacity = _items.Length == 0 ? DefaultCapacity : _items.Length * 2;
			Array.Resize(ref _items, newCapacity);
		}

		_items[++_top] = item;
	}

	public int Pop()
	{
		if (IsEmpty())
			throw new InvalidOperationException("Стек пуст.");

		return _items[_top--];
	}

	public int Peek()
	{
		if (IsEmpty())
			throw new InvalidOperationException("Стек пуст.");

		return _items[_top];
	}

	public bool IsEmpty() => _top == -1;

	public int Count => _top + 1;

	public void Clear()
	{
		_top = -1;
	}

	public IEnumerator<int> GetEnumerator()
	{
		for (var i = _top; i >= 0; i--)
		{
			yield return _items[i];
		}
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
