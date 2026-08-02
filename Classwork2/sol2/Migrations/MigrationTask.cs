namespace Classwork2.Migrations;

public abstract class MigrationTask : IMigrationTask
{
    public int Id { get; }

    protected MigrationTask(int id)
    {
        Id = id;
    }

    public abstract void Run();
}