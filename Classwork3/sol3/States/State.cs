namespace sol3.States;

public abstract class State : IState
{
    public Elevator Elevator { get; private set; }

    public void AddElev(Elevator elevator)
    {
        Elevator = elevator;
    }

    public abstract void ProcessRequest();
}