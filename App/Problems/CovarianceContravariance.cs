namespace App.Problems;

public class CovarianceContravariance
{
	private interface IProducer<out T>
	{
		T Produce();
	}

	private class StringProducer : IProducer<string>
	{
		public string Produce() => "Hello World";
	}

	private interface IConsumer<in T>
	{
		void Consume(T item);
	}

	private class ObjectConsumer : IConsumer<object>
	{
		public void Consume(object item) => Console.WriteLine(item.ToString());
	}

	public static void Run()
	{
		// Ковариантность: IProducer<string> можно присвоить IProducer<object>
		IProducer<object> producer = new StringProducer();
		// "Hello World"
		object result = producer.Produce(); 
		Console.WriteLine(result);
		
		// Контравариантность: IConsumer<object> можно присвоить IConsumer<string>
		IConsumer<string> consumer = new ObjectConsumer();
		// "Test"
		consumer.Consume("Test");
	}
}