namespace Classwork2.Migrations;

public interface IMigrationTask
{
   int Id { get; }
    
    public void Run();
}