namespace sol3;

public class Process
{
    private int _score;

    public void ReadInfo()
    {
        Console.WriteLine("Enter you score (0-100): ...");
        _score = Convert.ToInt16(Console.ReadLine());
        Console.Beep();
    }

    public void Validate()
    {
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