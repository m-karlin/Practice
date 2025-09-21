namespace App.Algorithms;

public class BreadthFistsSearch
{
	private record Node<T>(Guid Id)
	{
		private readonly List<Node<T>> _children = [];

		public void AddChild(Node<T> child)
		{
			_children.Add(child);
		}

		public bool TryFindNode(Guid id, out Node<T>? node)
		{
			var visited = new HashSet<Guid>();
			var queue = new Queue<Node<T>>();

			queue.Enqueue(this);

			while (queue.Count > 0)
			{
				var current = queue.Dequeue();

				if (!visited.Add(current.Id)) continue;

				if (current.Id == id)
				{
					node = current;
					return true;
				}

				foreach (var child in current._children)
				{
					if (!visited.Contains(child.Id))
					{
						queue.Enqueue(child);
					}
				}
			}

			node = null;
			return false;
		}
	}

	public static void Run()
	{
		WithoutCycle();
		WithCycle();
	}

	private static void WithCycle()
	{
		var root = new Node<int>(Guid.NewGuid());
		var node2 = new Node<int>(Guid.NewGuid());

		root.AddChild(node2);
		// Cycle
		node2.AddChild(root);

		var result = root.TryFindNode(node2.Id, out var resultNode);
		// true
		Console.WriteLine(result);
		// id2
		Console.WriteLine(resultNode?.Id);
	}

	private static void WithoutCycle()
	{
		var root = new Node<int>(Guid.NewGuid());
		var node2 = new Node<int>(Guid.NewGuid());
		var node3 = new Node<int>(Guid.NewGuid());
		var node4 = new Node<int>(Guid.NewGuid());

		root.AddChild(node2);
		node2.AddChild(node3);
		root.AddChild(node4);

		var result = root.TryFindNode(node3.Id, out var resultNode);
		// true
		Console.WriteLine(result);
		// id3
		Console.WriteLine(resultNode?.Id);

		var result2 = root.TryFindNode(Guid.NewGuid(), out _);
		// false
		Console.WriteLine(result2);

		var result3 = root.TryFindNode(root.Id, out var resultNode3);
		// true
		Console.WriteLine(result3);
		// rootId
		Console.WriteLine(resultNode3?.Id);
	}
}