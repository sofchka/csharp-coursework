namespace sol3;

public class BScore : BaseScore
{
    public BScore(int score) : base(score) {}

    public override bool ValidateScore()
    {
        return Score >= 80;
    }

    public override void PrintLog()
    {
        Console.WriteLine("Your Score is " + this.Score + " which is equal to [B]");
    }
}