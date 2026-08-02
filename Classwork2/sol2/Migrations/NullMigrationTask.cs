namespace Classwork2.Migrations;

public class NullMigrationTask : MigrationTask
{
    public NullMigrationTask() : base(4)
    {}

    public override void Run()
    {
        Console.WriteLine("4");
    }
}