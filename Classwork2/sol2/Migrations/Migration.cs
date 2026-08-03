using Classwork2.Model;
using Classwork2.Data;
namespace Classwork2.Migrations;

public class Migration
{
    private readonly string _fileName;
    
    private readonly string _csvFileName;

    private readonly UsersDataCollection _users;

    private readonly HashSet<int> _completed = [];

    private readonly MigrationTask[] _tasks;

    public Migration(string filename)
    {
        _csvFileName = filename;

        _fileName = Path.GetDirectoryName(Path.GetDirectoryName(filename)) + "/Cache/" + "migrations.txt";
        
        _users = new UsersDataCollection(filename);
        
        _tasks =
        [
            new CreateUsersMigrationTask(),
            new ValidateBirthDateMigration(_users),
            new CapitalMigrationTask(),
            new NullMigrationTask(),
            new DuplicateMigrationTask()
        ];
        
        Directory.CreateDirectory("Data");

        if (!File.Exists(_fileName))
            return;

        foreach (var line in File.ReadAllLines(_fileName))
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

            MigrationStorage(task);
        }
        
        MigrationSave();
    }

    public void OldRunsForget()
    {
        if (!File.Exists(_fileName))
            return;
        File.WriteAllText(_fileName, "");
    }

    private void MigrationStorage(MigrationTask task)
    {
        _completed.Add(task.Id);

        File.AppendAllText(
            _fileName,
            task.Id + Environment.NewLine);
    }

    private void MigrationSave()
    {
        string result =
            Path.GetDirectoryName(_csvFileName)! + "/"
            + Path.GetFileNameWithoutExtension(_csvFileName)
            + "_result"
            + Path.GetExtension(_csvFileName);
        
        _users.UsersDataSave(result);
    }
}