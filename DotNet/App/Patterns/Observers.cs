namespace App.Patterns;

public class Observers
{
	private interface IObserver
	{
		void Update(ISubject subject);
	}

	private interface ISubject
	{
		void Attach(IObserver observer);
		void Detach(IObserver observer);
		void Notify();
	}

	private class ConcreteSubject : ISubject
	{
		private readonly List<IObserver> _observers = new();
		private string _state;

		public string State
		{
			get => _state;
			set
			{
				_state = value;
				Notify();
			}
		}

		public void Attach(IObserver observer) => _observers.Add(observer);
		public void Detach(IObserver observer) => _observers.Remove(observer);

		public void Notify()
		{
			foreach (var observer in _observers)
			{
				observer.Update(this);
			}
		}
	}

	private class ConcreteObserver(string name) : IObserver
	{
		public void Update(ISubject subject)
		{
			if (subject is ConcreteSubject concreteSubject)
			{
				Console.WriteLine($"{name} received update: {concreteSubject.State}");
			}
		}
	}

	public static void Run()
	{
		Console.WriteLine("\n3. Observer:");
		var subject = new ConcreteSubject();
		var observer1 = new ConcreteObserver("Observer 1");
		var observer2 = new ConcreteObserver("Observer 2");

		subject.Attach(observer1);
		subject.Attach(observer2);

		subject.State = "New State!";
	}
}