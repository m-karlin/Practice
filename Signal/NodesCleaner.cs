using Xunit.Abstractions;

namespace Practice.Signal;

public class NodesCleanerTests(ITestOutputHelper output)
{
	private record Node(int Id, int? ParentId, bool Alive, List<Node> Children)
	{
		public Node CreateChild(bool alive)
		{
			var child = new Node(
				(Children.Count > 0 ? Children[^1].Id : Id * 10) + 1,
				Id,
				alive,
				[]
			);
			Children.Add(child);
			return child;
		}

		public static void Clean(Node node)
		{
		}

		public static string Stringify(Node node, int level = 0)
		{
			return $"{new string('-', level)}{node.Alive.ToString()[0]}{node.Id}"
			       + Environment.NewLine
			       + string.Join("", node.Children.Select(child => Stringify(child, level + 1)));
			/*return $"{new string(' ', level * 2)}Id:{node.Id} pId{(node.ParentId.HasValue ? node.ParentId : "R")}:{node.Alive}"
			    + Environment.NewLine
			    + string.Join("", node.Children.Select(child => Stringify(child, level + 1)));*/
		}
	};
	
	[Fact]
	public void Test()
	{
		var root = new Node(1, null, true, []);

		var l11 = root.CreateChild(false);
		var l12 = root.CreateChild(true);

		l11.CreateChild(false).CreateChild(true);
		l12.CreateChild(false).CreateChild(true);

		root.CreateChild(true).CreateChild(false);
		root.CreateChild(false).CreateChild(true);

		//visualize tree
		Print(root);

		Node.Clean(root);

		Assert.Equal(
			Node.Stringify(root).Trim(),
			"""
				T1
				-F11
				--F111
				---T1111
				-T12
				--F121
				---T1211
				-T13
				--F131
				-F14
				--T141
				""".Trim()
		);
	}

	[Fact]
	public void Test2()
	{
		var root = new Node(1, null, false, []);
		root.CreateChild(false).CreateChild(false).CreateChild(false);
		root.CreateChild(false).CreateChild(true).CreateChild(false);
		//visualize tree
		//Print(root);
		Node.Clean(root);
		Assert.Equal(
			Node.Stringify(root).Trim(),
			"""
				F1
				-F12
				--T121
				---F1211
				""".Trim()
		);
	}

	[Fact]
	public void Test3()
	{
		var root = new Node(1, null, false, []);
		root.CreateChild(false).CreateChild(false).CreateChild(true);
		root.CreateChild(false).CreateChild(true).CreateChild(true);
		root.CreateChild(true).CreateChild(true).CreateChild(true);
		root.CreateChild(false).CreateChild(true).CreateChild(true);
		root.CreateChild(false).CreateChild(false).CreateChild(true);
		root.CreateChild(false).CreateChild(false).CreateChild(false);
		var l11 = root.CreateChild(false);
		l11.CreateChild(false);
		l11.CreateChild(true);
		l11.CreateChild(false).CreateChild(false);
		l11.CreateChild(false).CreateChild(true);
		l11.CreateChild(true).CreateChild(false);
		l11.CreateChild(true).CreateChild(true);

		var l12 = root.CreateChild(true);
		l12.CreateChild(false);
		l12.CreateChild(true);
		l12.CreateChild(false).CreateChild(false);
		l12.CreateChild(false).CreateChild(true);
		l12.CreateChild(true).CreateChild(false);
		l12.CreateChild(true).CreateChild(true);

		//visualize tree
		//Print(root);
		Node.Clean(root);
		Assert.Equal(
			Node.Stringify(root).Trim(),
			"""
				F1
				-F11
				--F111
				---T1111
				-F12
				--T121
				---T1211
				-T13
				--T131
				---T1311
				-F14
				--T141
				---T1411
				-F15
				--F151
				---T1511
				-F17
				--T172
				--F174
				---T1741
				--T175
				---F1751
				--T176
				---T1761
				-T18
				--F181
				--T182
				--F183
				---F1831
				--F184
				---T1841
				--T185
				---F1851
				--T186
				---T1861
				""".Trim()
		);
	}

	private void Print(Node node)
	{
		output.WriteLine(Node.Stringify(node));
	}
}