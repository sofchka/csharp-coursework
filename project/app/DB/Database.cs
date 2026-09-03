using Microsoft.Data.Sqlite;

namespace app.DB;

public class Database
{
    private readonly string _connectionString;
    
    public Database()
    {
        Directory.CreateDirectory("Database");

        var csb = new SqliteConnectionStringBuilder
        {
            DataSource = "Database/app.db",
            ForeignKeys = true
        };

        _connectionString = csb.ConnectionString;
    }

    public SqliteConnection GetConnection()
    {
        var connection = new SqliteConnection(_connectionString);
        connection.Open();

        return connection;
    }

    public void Initialize()
    {
        using var connection = GetConnection();

        const string sql = """
                           CREATE TABLE IF NOT EXISTS Users
                           (
                               UserId INTEGER PRIMARY KEY AUTOINCREMENT,
                               Email TEXT NOT NULL UNIQUE,
                               FullName TEXT NOT NULL,
                               Password TEXT NOT NULL
                           );

                           CREATE TABLE IF NOT EXISTS Friends
                           (
                               UserId INTEGER NOT NULL,
                               FriendId INTEGER NOT NULL,
                               CreatedAt TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,

                               PRIMARY KEY (UserId, FriendId),

                               FOREIGN KEY (UserId) REFERENCES Users(UserId),
                               FOREIGN KEY (FriendId) REFERENCES Users(UserId)
                           );
                           """;

        using var command = new SqliteCommand(sql, connection);
        command.ExecuteNonQuery();
    }
}
