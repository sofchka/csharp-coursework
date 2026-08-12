namespace sol3.States;

public class IdleState : State
{
    public override void ProcessRequest()
    {
        Console.WriteLine("Now in Idle state!\n");
    }

    public override string ToString()
    {
        return "Idle State";
    }
}