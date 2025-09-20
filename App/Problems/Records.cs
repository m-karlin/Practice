namespace App.Problems;

public class Records
{
	private record A(int Value);

	public static void Run()
	{
		var a = new A(1);
		Console.WriteLine(a.GetHashCode());
		Some(a);
	}

	private static void Some(A a)
	{
		Console.WriteLine(a.GetHashCode());
	}
}