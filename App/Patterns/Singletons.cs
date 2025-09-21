namespace App.Patterns;

public class Singletons
{
	private sealed class Singleton
	{
		private static Singleton _instance;
		private static readonly object _lock = new object();
        
		private Singleton() { }
        
		public static Singleton Instance
		{
			get
			{
				lock (_lock)
				{
					return _instance ??= new Singleton();
				}
			}
		}
        
		public void DoSomething()
		{
			Console.WriteLine("Singleton is working!");
		}
	}

	public static void Run()
	{
		Console.WriteLine("1. Singleton:");
		var s1 = Singleton.Instance;
		var s2 = Singleton.Instance;
		Console.WriteLine($"s1 == s2: {s1 == s2}");
		s1.DoSomething();
	}
}