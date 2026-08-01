namespace Classwork2.Migrations;

public class NullMigrationTask : IMigrationTask
{
    public void Start()
    {
        Console.WriteLine("1");
    }
}