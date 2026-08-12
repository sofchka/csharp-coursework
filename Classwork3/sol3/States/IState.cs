namespace sol3.States;

public interface IState
{
    Elevator Elevator { get; }

    public void AddElev(Elevator elevator);
    public void ProcessRequest();
}