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
            if (user.BirthDate.Year > 2007)
            {
                Console.WriteLine("=========================================");

                Console.WriteLine(
                    $"Fixing {user.Name}'s status => under the age"
                );

                Console.WriteLine($"Old status = {user.Status}");
                user.Status = "user.underAge";
                Console.WriteLine($"New status = {user.Status}");
                
                Console.WriteLine("=========================================");
            }
        }
    }
}