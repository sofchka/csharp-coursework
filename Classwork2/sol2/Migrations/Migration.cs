using Classwork2.Model;
namespace Classwork2.Migrations;

public class Migration
{
    private const string FileName = "Data/migrations.txt";

    private readonly HashSet<int> _completed = [];

    private readonly MigrationTask[] _tasks;

    public Migration()
    {
        UsersDataCollection users = new UsersDataCollection();
        
        _tasks =
        [
            new CreateUsersMigrationTask(),
            new ValidateBirthDateMigration(users),
            new CapitalMigrationTask(),
            new NullMigrationTask(),
            new DuplicateMigrationTask()
        ];
        
        Directory.CreateDirectory("Data");

        if (!File.Exists(FileName))
            return;

        foreach (var line in File.ReadAllLines(FileName))
            _completed.Add(int.Parse(line));
    }

    public void Run()
    {
        foreach (var task in _tasks)
        {
            if (_completed.Contains(task.Id))
                continue;

            Console.WriteLine($"Running migration {task.Id}");

            task.Run();

            _completed.Add(task.Id);

            File.AppendAllText(
                FileName,
                task.Id + Environment.NewLine);
        }
    }

    public void OldRunsForget()
    {
        if (!File.Exists(FileName))
            return;
        File.WriteAllText(FileName, "");
    }
    
}