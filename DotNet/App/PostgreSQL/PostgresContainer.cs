using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;

namespace App.PostgreSQL;

public class PostgresContainer : IAsyncDisposable
{
	private readonly PostgreSqlTestcontainer _container = new TestcontainersBuilder<PostgreSqlTestcontainer>()
		.WithDatabase(new PostgresContainerConfiguration
		{
			Database = "testdb",
			Username = "postgres",
			Password = "postgres",
		})
		.Build();

	public string ConnectionString => _container.ConnectionString;

	public async Task StartAsync()
	{
		await _container.StartAsync();
		Console.WriteLine("PostgreSQL контейнер запущен!");
	}

	public async Task StopAsync()
	{
		await _container.StopAsync();
		Console.WriteLine("PostgreSQL контейнер остановлен!");
	}

	public async ValueTask DisposeAsync()
	{
		await _container.DisposeAsync();
	}
}