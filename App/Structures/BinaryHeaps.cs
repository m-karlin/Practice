namespace App.Structures;

public class BinaryHeap
{
	// log(n) вставка
	// log(n) извлечение максимального
	private class MyBinaryHeap(int capacity, bool isMaxHeap = true)
	{
		private readonly int[] _heap = new int[capacity];
		private const int Size = 0;
		private bool _isMaxHeap = isMaxHeap; // true для max-heap, false для min-heap

		public void Push(int value)
		{
			throw new NotImplementedException();
		}

		public int Pop()
		{
			throw new NotImplementedException();
		}

		public void Print()
		{
			Console.WriteLine("Куча: " + string.Join(", ", _heap[0..Size]));
			Console.WriteLine("\nДерево:");
			PrintTree(0, 0);
		}

		private void PrintTree(int index, int level)
		{
			if (index >= Size) return;

			PrintTree(2 * index + 2, level + 1); // Правый ребенок
			Console.WriteLine(new string(' ', level * 4) + _heap[index]);
			PrintTree(2 * index + 1, level + 1); // Левый ребенок
		}
	}

	public static void Run()
	{
		var binaryHeap = new MyBinaryHeap(10);

		binaryHeap.Push(1);
		binaryHeap.Push(4);
		binaryHeap.Push(5);
		binaryHeap.Push(1);
		binaryHeap.Push(3);

		// 5
		Console.WriteLine(binaryHeap.Pop());
		// 4
		Console.WriteLine(binaryHeap.Pop());
	}
}