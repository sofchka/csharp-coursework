namespace sol3;

public abstract class BaseScore : IScore
{
    protected int Score; // to inherit
    
    protected BaseScore(int score) // petq chi override anel, inherit a arel
    {
        this.Score = score;
    }

    public abstract bool ValidateScore(); // musr override

    public abstract void PrintLog();
}