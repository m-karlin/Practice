namespace App.Structures;

public class Stacks
{
	private class MyStack(int capacity)
	{
		private int[] _items = new int[capacity];
		private int _top = -1;


		public void Push(int item)
		{
			if (_top == _items.Length - 1)
				Array.Resize(ref _items, _items.Length * 2);

			_items[++_top] = item;
		}

		public int Pop()
		{
			return IsEmpty() ? throw new InvalidOperationException("Stack is empty") : _items[_top--];
		}

		public int Peek() => IsEmpty()
			? throw new InvalidOperationException("Stack is empty")
			: _items[_top];

		public bool IsEmpty() => _top == -1;
		public int Count => _top + 1;
	}

	public static void Run()
	{
		var stack = new MyStack(4);
		stack.Push(1);
		stack.Push(2);
		stack.Push(3);
		stack.Push(4);

		Console.WriteLine(stack.Pop());
		Console.WriteLine(stack.Pop());
		Console.WriteLine(stack.Pop());
		Console.WriteLine(stack.Pop());
	}
}