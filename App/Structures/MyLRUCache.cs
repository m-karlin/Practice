namespace App.Structures;

public class MyLRUCache(int capacity)
{
	private class Node(int key, int value, Node? next, Node? prev)
	{
		public int Value { get; set; } = value;
		public int Key { get; set; } = key;
		public Node? Next { get; set; } = next;
		public Node? Prev { get; set; } = prev;
	}

	private readonly Dictionary<int, Node> _dictionary = new(capacity);
	private Node? _head;
	private Node? _tail;
	private int _count = 0;

	public int Get(int key)
	{
		if (!_dictionary.TryGetValue(key, out var node)) return -1;
		MoveToHead(node);
		return node.Value;
	}

	public void Put(int key, int value)
	{
		if (_dictionary.TryGetValue(key, out var node))
		{
			node.Value = value;
			MoveToHead(node);
			return;
		}

		if (_count >= capacity)
		{
			RemoveTail();
		}

		var newNode = new Node(key, value, null, _head);
		_dictionary.Add(key, newNode);
		AddToHead(newNode);
		_count++;
	}

	private void MoveToHead(Node node)
	{
		if (node == _head) return;
		RemoveNode(node);
		AddToHead(node);
	}

	private void RemoveNode(Node node)
	{
		if (node.Prev != null)
			node.Prev.Next = node.Next;
		if (node.Next != null)
			node.Next.Prev = node.Prev;

		if (node == _tail)
			_tail = node.Prev;

		if (node == _head)
			_head = node.Next;

		node.Prev = null;
		node.Next = null;
	}

	private void AddToHead(Node node)
	{
		if (_head != null)
		{
			node.Next = _head;
			_head.Prev = node;
			_head = node;
		}
		else
		{
			_head = node;
			_tail = node;
		}
	}

	private void RemoveTail()
	{
		if (_tail == null) return;

		_dictionary.Remove(_tail.Key);

		if (_tail == _head)
		{
			_head = null;
			_tail = null;
		}
		else
		{
			_tail = _tail.Prev;
			_tail!.Next = null;
		}

		_count--;
	}
}