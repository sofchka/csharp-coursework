namespace sol5.People;
using sol5.Menus;

public class Server
{
    public string Name { get; }
    
    public Server(string name)
    {
        Name = name;
    }

    public void TakeOrder(Guest guest)
    {
        
    }

    public void GiveOrder(Guest guest)
    {
        guest.Finished = true;
    }
}