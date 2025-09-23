using Npgsql;

namespace App.PostgreSQL.Queries;

public class Users
{
	private class User
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
	}
	
	public static async Task Run(string connectionString)
	{
		await using var connection = new NpgsqlConnection(connectionString);
		await connection.OpenAsync();

		await CreateTable(connection);
		await InsertUser(connection, "mihar33");

		Console.WriteLine("Таблица Test создана");
	}

	private static async Task InsertUser(NpgsqlConnection connection, string name)
	{
		const string sql = "INSERT INTO Users (Name) VALUES (@name) RETURNING Id";
		await using var command = new NpgsqlCommand(sql, connection);
		command.Parameters.AddWithValue("@name", name);
		await command.ExecuteScalarAsync();
	}

	private static async Task CreateTable(NpgsqlConnection connection)
	{
		const string sql = "CREATE TABLE Users (Id SERIAL PRIMARY KEY, Name TEXT)";
		await using var command = new NpgsqlCommand(sql, connection);
		await command.ExecuteNonQueryAsync();
	}
	
	private async Task<List<User>> GetUsers(NpgsqlConnection connection)
	{
		var records = new List<User>();
		const string sql = "SELECT * FROM Test";
		await using var command = new NpgsqlCommand(sql, connection);
		await using var reader = await command.ExecuteReaderAsync();

		while (await reader.ReadAsync())
		{
			records.Add(new User
			{
				Id = reader.GetInt32(0),
				Name = reader.GetString(1)
			});
		}

		return records;
	}
}