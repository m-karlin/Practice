namespace App.NetFeatures;

public class VirualOvveride
{
	private abstract class BaseClass
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

	private class ChildClass : BaseClass
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

	private static void LogInfo(BaseClass obj)
	{
		// ? Child (позднее связывание через VTable в объекте
		// (создается через new, в нем ссылка на область памяти где функция либо из базового, либо из наследника)
		obj.Method1();
		// ? Base
		obj.Method2();
	}

	public static void Run()
	{
		var child = new ChildClass();
		// ? Child
		child.Method1();
		// ? Child (new)
		child.Method2();
		LogInfo(child);
	}
}