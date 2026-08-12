namespace sol3.States;

public class MoveState : State
{
    public override void ProcessRequest()
    {
        if (Elevator.Requests.Count > 0)
        {
            Console.WriteLine("Initial Floor: " + Elevator.Floor);
            Console.WriteLine("Moving to floor  =============>  " + Elevator.Requests[0]);
            Elevator.Floor = Elevator.Requests[0];
        }

        Elevator.ContinueProcess();
    }
    
    public override string ToString()
    {
        return "Move State";
    }
    
}