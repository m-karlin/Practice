namespace App.Patterns;

public class Decorators
{
	private interface IComponent
	{
		string Operation();
	}

	private class ConcreteComponent : IComponent
	{
		public string Operation() => "ConcreteComponent";
	}

	private abstract class Decorator(IComponent component) : IComponent
	{
		protected IComponent _component = component;

		public virtual string Operation() => _component.Operation();
	}

	private class ConcreteDecoratorA(IComponent component) : Decorator(component)
	{
		public override string Operation() => $"ConcreteDecoratorA({base.Operation()})";
	}

	private class ConcreteDecoratorB(IComponent component) : Decorator(component)
	{
		public override string Operation() => $"ConcreteDecoratorB({base.Operation()})";
	}

	public static void Run()
	{
		Console.WriteLine("\n5. Decorator:");
		IComponent component = new ConcreteComponent();
		Console.WriteLine($"Basic: {component.Operation()}");

		IComponent decorated = new ConcreteDecoratorA(component);
		Console.WriteLine($"Decorated A: {decorated.Operation()}");

		IComponent doubleDecorated = new ConcreteDecoratorB(decorated);
		Console.WriteLine($"Decorated B: {doubleDecorated.Operation()}");
	}
}