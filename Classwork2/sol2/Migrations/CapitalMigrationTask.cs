namespace Classwork2.Migrations;

public class CapitalMigrationTask : MigrationTask
{
    public CapitalMigrationTask() : base(3)
    {
    }

    public override void Run()
    {
        Console.WriteLine("3");
    }
}
