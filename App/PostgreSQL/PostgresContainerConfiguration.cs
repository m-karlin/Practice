using DotNet.Testcontainers.Configurations;

namespace App.PostgreSQL;

public class PostgresContainerConfiguration() : TestcontainerDatabaseConfiguration("postgres:15", 5432)
{
	public override string Username
	{
		get => Environments["POSTGRES_USER"];
		set => Environments["POSTGRES_USER"] = value;
	}

	public override string Password
	{
		get => Environments["POSTGRES_PASSWORD"];
		set => Environments["POSTGRES_PASSWORD"] = value;
	}

	public override string Database
	{
		get => Environments["POSTGRES_DB"];
		set => Environments["POSTGRES_DB"] = value;
	}
}