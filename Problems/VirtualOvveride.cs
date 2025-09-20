namespace Practice.Problems;

public class Tas1Tests
{
	public abstract class BaseClass
	{
		public virtual void Method1()
		{
			Console.WriteLine("Base");
		}

		public void Method2()
		{
			Console.WriteLine("Base");
		}
	}
	
	public class ChildClass : BaseClass
	{
		public override void Method1()
		{
			Console.WriteLine("Child");
		}

		public new void Method2()
		{
			Console.WriteLine("Child");
		}
	}

	public void LogInfo(BaseClass obj)
	{
		obj.Method1(); // ? Child
		obj.Method2(); // ? Base
	}

	[Fact]
	public void Test()
	{
		var child = new ChildClass();
		child.Method1(); // ? Child
		child.Method2(); // ? Child (new)
		LogInfo(child);
	}
}