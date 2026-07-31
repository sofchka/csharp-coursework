namespace sol3;

public class Process
{
    private readonly int _score;

    public Process()
    {
        Console.WriteLine("Enter you score (0-100): ...");
        _score = Convert.ToInt16(Console.ReadLine());
        Console.Beep();
        var scores = new List<BaseScore>
        {
            new AScore(_score),
            new BScore(_score),
            new CScore(_score),
            new DScore(_score),
            new FScore(_score)
        };
        foreach (var score in scores)
        {
            if (score.ValidateScore())
            {
                score.PrintLog();
                break;
            }
        }
    }
}