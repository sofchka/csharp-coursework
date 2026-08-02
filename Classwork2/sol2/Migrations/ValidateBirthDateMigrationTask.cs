using Classwork2.Model;
namespace Classwork2.Migrations;


public class ValidateBirthDateMigration : MigrationTask
{
    private readonly UsersDataCollection _users;


    public ValidateBirthDateMigration(
        UsersDataCollection users
    ) : base(2)
    {
        _users = users;
    }


    public override void Run()
    {
        foreach (var user in _users.Users)
        {
            if (user.BirthDate.Year < 2025)
            {
                Console.WriteLine(
                    $"Fixing {user.Name}"
                );

                user.BirthDate =
                    new DateTime(2025, 1, 1);
            }
        }
    }
}