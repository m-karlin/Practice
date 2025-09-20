namespace App.Problems;

public class BinaryHeap
{
	// log(n) вставка
	// log(n) извлечение максимального
	private class Heap(int capacity, bool isMaxHeap = true)
	{
		private int[] heap = new int[capacity];
		private int size = 0;
		private bool isMaxHeap = isMaxHeap; // true для max-heap, false для min-heap

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
			Console.WriteLine("Куча: " + string.Join(", ", heap[0..size]));
			Console.WriteLine("\nДерево:");
			PrintTree(0, 0);
		}

		private void PrintTree(int index, int level)
		{
			if (index >= size) return;

			PrintTree(2 * index + 2, level + 1); // Правый ребенок
			Console.WriteLine(new string(' ', level * 4) + heap[index]);
			PrintTree(2 * index + 1, level + 1); // Левый ребенок
		}
	}

	public static void Run()
	{
		var binaryHeap = new Heap(10);

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