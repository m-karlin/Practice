namespace App.Structures;


public class MyBinaryHeap(int capacity, bool isMaxHeap = true)
{
	private readonly int[] _heap = new int[capacity];
	private int _size = 0;
	private bool _isMaxHeap = isMaxHeap;

	public void Push(int value)
	{
		if (_size >= _heap.Length)
			throw new InvalidOperationException("Куча переполнена");

		_heap[_size] = value;
		_size++;

		SiftUp(_size - 1);
	}

	public int Pop()
	{
		if (_size <= 0)
			throw new InvalidOperationException("Куча пуста");

		int root = _heap[0];

		_heap[0] = _heap[_size - 1];
		_size--;

		if (_size > 0)
			SiftDown(0);

		return root;
	}

	public void Print()
	{
		Console.WriteLine("Куча: " + string.Join(", ", _heap[0.._size]));
		Console.WriteLine("\nДерево:");
		PrintTree(0, 0);
	}

	private void PrintTree(int index, int level)
	{
		if (index >= _size) return;

		PrintTree(2 * index + 2, level + 1);
		Console.WriteLine(new string(' ', level * 4) + _heap[index]);
		PrintTree(2 * index + 1, level + 1);
	}

	private void SiftUp(int index)
	{
		while (index > 0)
		{
			int parentIndex = (index - 1) / 2;
			
			bool shouldSwap = _isMaxHeap ? 
				_heap[parentIndex] < _heap[index] : 
				_heap[parentIndex] > _heap[index];

			if (!shouldSwap)
				break;

			Swap(parentIndex, index);
			index = parentIndex;
		}
	}

	private void SiftDown(int index)
	{
		while (true)
		{
			int leftChildIndex = 2 * index + 1;
			int rightChildIndex = 2 * index + 2;
			int targetIndex = index;

			if (leftChildIndex < _size)
			{
				bool leftIsBetter = _isMaxHeap ?
					_heap[leftChildIndex] > _heap[targetIndex] :
					_heap[leftChildIndex] < _heap[targetIndex];
					
				if (leftIsBetter)
					targetIndex = leftChildIndex;
			}

			if (rightChildIndex < _size)
			{
				bool rightIsBetter = _isMaxHeap ?
					_heap[rightChildIndex] > _heap[targetIndex] :
					_heap[rightChildIndex] < _heap[targetIndex];
					
				if (rightIsBetter)
					targetIndex = rightChildIndex;
			}

			if (targetIndex == index)
				break;

			Swap(index, targetIndex);
			index = targetIndex;
		}
	}

	private void Swap(int i, int j)
	{
        (_heap[j], _heap[i]) = (_heap[i], _heap[j]);
    }

    public static void Run()
	{
		var binaryHeap = new MyBinaryHeap(10);

		binaryHeap.Push(1);
		binaryHeap.Push(4);
		binaryHeap.Push(5);
		binaryHeap.Push(1);
		binaryHeap.Push(3);

		Console.WriteLine(binaryHeap.Pop());
		Console.WriteLine(binaryHeap.Pop());
	}
}