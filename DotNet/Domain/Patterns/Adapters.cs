namespace App.Patterns;

public class Adapters
{
	private interface ITarget
	{
		string GetRequest();
	}

	private class Adaptee
	{
		public string GetSpecificRequest() => "Specific request from Adaptee";
	}

	private class Adapter(Adaptee adaptee) : ITarget
	{
		private Adaptee _adaptee = adaptee;

		public string GetRequest() => $"Adapter: {_adaptee.GetSpecificRequest()}";
	}

	public static void Run()
	{
		Console.WriteLine("\n7. Adapter:");
		var adaptee = new Adaptee();
		ITarget target = new Adapter(adaptee);
		Console.WriteLine(target.GetRequest());
	}
}