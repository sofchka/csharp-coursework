namespace sol3;

public class DScore : BaseScore
{
    public DScore(int score) : base(score) {}

    public override bool ValidateScore()
    {
        return Score >= 60;
    }

    public override void PrintLog()
    {
        Console.WriteLine("Your Score is " + this.Score + " which is equal to [D]");
    }
}