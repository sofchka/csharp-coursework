namespace Classwork2.Migrations;

public class CreateUsersMigrationTask : MigrationTask
{
    public CreateUsersMigrationTask() : base(1)
    {
    }

    public override void Run()
    {
        Console.WriteLine("Creating users table...");
    }
}