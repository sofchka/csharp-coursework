namespace Classwork2.Migrations;

public class DuplicateMigrationTask : MigrationTask
{
    public DuplicateMigrationTask() : base(5)
    {
    }

    public override void Run()
    {
        Console.WriteLine("5");
    }
}