using App.PostgreSQL.Queries;

namespace App.PostgreSQL;

public class Runner
{
	public static async Task Run()
	{
		await using var container = new PostgresContainer();
		await container.StartAsync();
		try
		{
			// Queries
			await Users.Run(container.ConnectionString);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Ошибка: {ex.Message}");
		}
		finally
		{
			Console.WriteLine("Готово!");
		}
	}
}