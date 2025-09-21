namespace App.Patterns;

public class Commands
{
	private interface ICommand
	{
		void Execute();
	}

	private class Receiver
	{
		public void Action() => Console.WriteLine("Receiver is performing action");
	}

	private class ConcreteCommand(Receiver receiver) : ICommand
	{
		private Receiver _receiver = receiver;

		public void Execute() => _receiver.Action();
	}

	private class Invoker
	{
		private ICommand _command;

		public void SetCommand(ICommand command) => _command = command;

		public void ExecuteCommand() => _command?.Execute();
	}

	public static void Run()
	{
		Console.WriteLine("\n6. Command:");
		var receiver = new Receiver();
		var command = new ConcreteCommand(receiver);
		var invoker = new Invoker();
            
		invoker.SetCommand(command);
		invoker.ExecuteCommand();
	}
}