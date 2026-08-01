namespace sol5.People;
using sol5.Menus;

public class Guest
{
    public int TableId { get; }
    public MenuComponent[] Order = [];
    public bool Finished { get; set; }

    public Guest(int tableId)
    {
        Finished = false;
        TableId = tableId;
    }
}