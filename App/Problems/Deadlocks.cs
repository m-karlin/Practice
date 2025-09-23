namespace App.Problems;

public class Deadlocks
{
	private static readonly Lock Lock1 = new();
	private static readonly Lock Lock2 = new();

	public static void Run()
	{
		var t1 = new Thread(Thread1);
		var t2 = new Thread(Thread2);
		t1.Start();
		t2.Start();
		t1.Join();
		t2.Join();
	}

	private static void Thread1()
	{
		lock (Lock1)
		{
			Console.WriteLine("Thread1 захватил lock1");
			Thread.Sleep(100);

			lock (Lock2)
			{
				Console.WriteLine("Thread1 захватил lock2");
			}
		}
	}

	private static void Thread2()
	{
		lock (Lock2)
		{
			Console.WriteLine("Thread2 захватил lock2");
			Thread.Sleep(100);

			lock (Lock1)
			{
				Console.WriteLine("Thread2 захватил lock1");
			}
		}
	}
}