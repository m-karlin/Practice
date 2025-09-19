namespace Practice.Problems;

public class DepthFirstSearchTests
{
	private record Node<T>(Guid Id)
	{
		public readonly List<Node<T>> Children = [];

		public void AddChild(Node<T> child)
		{
			Children.Add(child);
		}

		public bool TryFindNode(Guid id, out Node<T>? node)
		{
			var visited = new HashSet<Guid>();
			var stack = new Stack<Node<T>>();

			stack.Push(this);

			while (stack.Count > 0)
			{
				var current = stack.Pop();

				if (!visited.Add(current.Id))
				{
					continue;
				}

				if (current.Id == id)
				{
					node = current;
					return true;
				}

				for (var index = current.Children.Count - 1; index >= 0; index--)
				{
					var children = current.Children[index];
					if (!visited.Contains(children.Id))
					{
						stack.Push(children);
					}
				}
			}

			node = null;
			return false;
		}
	}

	[Fact]
	public void Test1()
	{
		var root = new Node<int>(Guid.NewGuid());
		var node2 = new Node<int>(Guid.NewGuid());
		var node3 = new Node<int>(Guid.NewGuid());
		var node4 = new Node<int>(Guid.NewGuid());

		root.AddChild(node2);
		node2.AddChild(node3);
		root.AddChild(node4);

		Assert.True(root.TryFindNode(node3.Id, out var result));
		Assert.Equal(node3.Id, result!.Id);

		Assert.False(root.TryFindNode(Guid.NewGuid(), out _));

		Assert.True(root.TryFindNode(root.Id, out var rootResult));
		Assert.Equal(root.Id, rootResult!.Id);
	}

	[Fact]
	public void Test2()
	{
		var root = new Node<int>(Guid.NewGuid());
		var node2 = new Node<int>(Guid.NewGuid());

		root.AddChild(node2);
		node2.AddChild(root); // Cycle

		Assert.True(root.TryFindNode(node2.Id, out var result));
		Assert.Equal(node2.Id, result!.Id);
	}
}