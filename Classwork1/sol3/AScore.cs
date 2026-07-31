namespace sol3;

public class AScore : BaseScore
{
    public AScore(int score) : base(score) {}

    public override bool ValidateScore()
    {
        return Score >= 90;
    }

    public override void PrintLog()
    {
        Console.WriteLine("Your Score is " + this.Score + " which is equal to [A]");
    }
}