namespace App.Problems;

public class Tasks
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
	private static string _message;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
	
	static async Task<string> SaySomething()
	{
		await Task.Delay(5);
		_message = "Hello world!";
		return "Something";
	}
	
	public static void Run()
	{
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
		SaySomething();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
		// null
		Console.WriteLine(_message);
	}
}