namespace sol3;

public class FScore : BaseScore
{
    public FScore(int score) : base(score) {}

    public override bool ValidateScore()
    {
        return Score <= 59;
    }

    public override void PrintLog()
    {
        Console.WriteLine("Your Score is " + this.Score + " which is equal to [F]");
    }
}