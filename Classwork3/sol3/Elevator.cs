using sol3.States;

namespace sol3;

public class Elevator
{
    private readonly List<IState> _arrState = [];

    private IState? _state;
    public int Floor { get; set; } = 1;
    public List<int> Requests { get; } = [];

    public void Start()
    {
        Console.WriteLine("\n\n|========================== Elevator electricity is now on =========================|\n");
        if (Requests.Count > 0)
            ChangeState<MoveState>();
        else
            ChangeState<IdleState>();
    }

    public void MakeRequest(int floor)
    {
        if (floor < 1)
            throw new ArgumentException("~~~~~Invalid floor~~~~~ " + floor);
        
        Console.WriteLine("Pressing button at floor : " + floor);
        
        Requests.Add(floor);
        
        if (_state is IdleState)
            ChangeState<MoveState>();
    }

    public void ContinueProcess()
    {
        RemoveRequest();
        if (Requests.Count <= 0)
        {
            ChangeState<IdleState>();
        }
        else
        {
            _state.ProcessRequest();
        }
    }
    
    private void RemoveRequest()
    {
        Requests.RemoveAll(item => item == Floor);
    }
    
    private void ChangeState<T>() where T : State, new()
    {
        var cachedState = _arrState.FirstOrDefault(item => item is T); // LINQ
        if (cachedState is null)
        {
            cachedState = new T();
            cachedState.AddElev(this);
            _arrState.Add(cachedState);
        }

        Console.WriteLine("\nChanged elevator state to: " + cachedState);
        _state = cachedState;
        _state.ProcessRequest();
    }
}