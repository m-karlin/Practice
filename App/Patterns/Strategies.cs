namespace App.Patterns;

public class Strategies
{
	private interface IStrategy
	{
		void Execute();
	}

	private class ConcreteStrategyA : IStrategy
	{
		public void Execute() => Console.WriteLine("Executing Strategy A");
	}

	private class ConcreteStrategyB : IStrategy
	{
		public void Execute() => Console.WriteLine("Executing Strategy B");
	}

	private class Context
	{
		private IStrategy _strategy;

		public void SetStrategy(IStrategy strategy) => _strategy = strategy;

		public void ExecuteStrategy() => _strategy?.Execute();
	}

	public static void Run()
	{
		Console.WriteLine("\n4. Strategy:");
		var context = new Context();

		context.SetStrategy(new ConcreteStrategyA());
		context.ExecuteStrategy();

		context.SetStrategy(new ConcreteStrategyB());
		context.ExecuteStrategy();
	}
}