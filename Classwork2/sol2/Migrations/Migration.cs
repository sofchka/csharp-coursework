namespace Classwork2.Migrations;

public class Migration
{
    private int _id;
    private readonly IMigrationTask[] _list =
    {
        new NullMigrationTask(),
        new DuplicateMigrationTask(),
        new CapitalMigrationTask()
    };

    public Migration()
    {
        _id = 0;
        try
        {
            Directory.CreateDirectory("Cache");
            if (File.Exists("Cache/counter.txt"))
                _id = int.Parse(File.ReadAllText("Cache/counter.txt"));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public void Start()
    {
        while (_id < _list.Length)
        {
            _list[_id].Start();
            _id++;
            File.WriteAllText("Cache/counter.txt", _id.ToString());
        }
    }
}