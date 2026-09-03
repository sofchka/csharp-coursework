using app.DB;
using app.Models;
using Microsoft.Data.Sqlite;

namespace app.Services;

public class UserService
{
    private readonly Database _database;

    public UserService(Database database)
    {
        _database = database;
    }

    public bool Register(string name, string surname, string email, string password)
    {
        const string sql = """
            INSERT INTO Users (Email, FullName, Password)
            VALUES ($email, $fullName, $password);
            """;

        try
        {
            using var connection = _database.GetConnection();
            using var command = new SqliteCommand(sql, connection);

            command.Parameters.AddWithValue("$email", email);
            command.Parameters.AddWithValue("$fullName", $"{name} {surname}");
            command.Parameters.AddWithValue("$password", password);

            command.ExecuteNonQuery();

            return true;
        }
        catch (SqliteException)
        {
            return false;
        }
    }

    public User? Login(string email, string password)
    {
        const string sql = """
            SELECT UserId, Email, FullName
            FROM Users
            WHERE Email = $email
              AND Password = $password;
            """;

        using var connection = _database.GetConnection();
        using var command = new SqliteCommand(sql, connection);

        command.Parameters.AddWithValue("$email", email);
        command.Parameters.AddWithValue("$password", password);

        using var reader = command.ExecuteReader();

        if (!reader.Read())
            return null;

        return new User
        {
            UserId = reader.GetInt32(0),
            Email = reader.GetString(1),
            FullName = reader.GetString(2)
        };
    }

    public bool ChangePassword(
        int userId,
        string currentPassword,
        string newPassword)
    {
        const string sql = """
            UPDATE Users
            SET Password = $newPassword
            WHERE UserId = $userId
              AND Password = $currentPassword;
            """;

        using var connection = _database.GetConnection();
        using var command = new SqliteCommand(sql, connection);

        command.Parameters.AddWithValue("$userId", userId);
        command.Parameters.AddWithValue("$currentPassword", currentPassword);
        command.Parameters.AddWithValue("$newPassword", newPassword);

        return command.ExecuteNonQuery() > 0;
    }

    // Print all users using pages.
    public List<User> GetUsers(int page, int pageSize)
    {
        const string sql = """
            SELECT UserId, Email, FullName
            FROM Users
            ORDER BY UserId
            LIMIT $pageSize OFFSET $offset;
            """;

        using var connection = _database.GetConnection();
        using var command = new SqliteCommand(sql, connection);

        command.Parameters.AddWithValue("$pageSize", pageSize);
        command.Parameters.AddWithValue("$offset", (page - 1) * pageSize);

        using var reader = command.ExecuteReader();

        var users = new List<User>();

        while (reader.Read())
        {
            users.Add(new User
            {
                UserId = reader.GetInt32(0),
                Email = reader.GetString(1),
                FullName = reader.GetString(2)
            });
        }

        return users;
    }

    // Print the friend list of a user.
    public List<User> GetFriends(int userId)
    {
        const string sql = """
            SELECT u.UserId, u.Email, u.FullName
            FROM Users u
            INNER JOIN Friends f ON u.UserId = f.FriendId
            WHERE f.UserId = $userId
            ORDER BY u.FullName;
            """;

        using var connection = _database.GetConnection();
        using var command = new SqliteCommand(sql, connection);

        command.Parameters.AddWithValue("$userId", userId);

        using var reader = command.ExecuteReader();

        var friends = new List<User>();

        while (reader.Read())
        {
            friends.Add(new User
            {
                UserId = reader.GetInt32(0),
                Email = reader.GetString(1),
                FullName = reader.GetString(2)
            });
        }

        return friends;
    }

    // Send a friend request inside a transaction.
    public bool RequestFriend(int userId, int friendId)
    {
        if (userId == friendId)
            return false;

        using var connection = _database.GetConnection();
        using var transaction = connection.BeginTransaction(); // wow

        try
        {
            const string checkUserSql = """
                SELECT COUNT(*)
                FROM Users
                WHERE UserId = $friendId;
                """;

            using var checkUserCommand = new SqliteCommand(
                checkUserSql,
                connection,
                transaction);

            checkUserCommand.Parameters.AddWithValue("$friendId", friendId);

            var userExists = Convert.ToInt32(
                checkUserCommand.ExecuteScalar());

            if (userExists == 0)
            {
                transaction.Rollback();
                return false;
            }

            const string insertSql = """
                INSERT INTO Friends (UserId, FriendId)
                VALUES ($userId, $friendId);
                """;

            using var insertCommand = new SqliteCommand(
                insertSql,
                connection,
                transaction);

            insertCommand.Parameters.AddWithValue("$userId", userId);
            insertCommand.Parameters.AddWithValue("$friendId", friendId);

            insertCommand.ExecuteNonQuery();

            transaction.Commit();

            return true;
        }
        catch (SqliteException)
        {
            transaction.Rollback();
            return false;
        }
    }
}