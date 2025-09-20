using System.Runtime.CompilerServices;

namespace App.Problems;

public class Tasks
{
	// Исходный код
	private async Task Method()
	{
		//Operation1();
		await Task.Delay(1000);
		//Operation2();
	}

// Преобразованный код (упрощенно)
	class StateMachine : IAsyncStateMachine
	{
		private int state;
		public void MoveNext()
		{
			if (state == 0)
			{
				//Operation1();
				var task = Task.Delay(1000);
				if (!task.IsCompleted)
				{
					// Подписка на продолжение
					state = 1;
					var context = SynchronizationContext.Current;
					task.ConfigureAwait(true).GetAwaiter()
						.OnCompleted(() => 
						{
							// Продолжение будет поставлено в очередь
							if (context != null)
								context.Post(o => MoveNext(), null);
							else
								MoveNext();
						});
				}
			}
			//Operation2(); // Выполняется синхронно или через продолжение
		}

		public void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//throw new NotImplementedException();
		}
	}

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