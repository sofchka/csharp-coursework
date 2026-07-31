namespace sol3;

public class CScore : BaseScore
{
    public CScore(int score) : base(score) {}

    public override bool ValidateScore()
    {
        return Score >= 70;
    }

    public override void PrintLog()
    {
        Console.WriteLine("Your Score is " + this.Score + " which is equal to [C]");
    }
}