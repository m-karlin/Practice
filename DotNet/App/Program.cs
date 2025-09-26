using App.PostgreSQL;

namespace App;

internal static class Program
{
	public static void Main()
	{
		Runner.Run().GetAwaiter().GetResult();
		Console.WriteLine("Hello World");
	}
}