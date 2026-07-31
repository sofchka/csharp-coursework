namespace Calculator;

public class MenuItem
{
    public readonly string Name;
    public readonly int Price;

    public MenuItem(string name, int price) 
    {
        Name = name;
        Price = price;
    }
}
public class Store
{
    private readonly List<MenuItem> _types = new List<MenuItem>(2) {
        new MenuItem("sev kofe", 10),
        new MenuItem("tea", 20),
        new MenuItem("cappuccino", 15),
        new MenuItem("dolce gusto", 25)
    };
    
    public Item Create(string coffee)
    {
        foreach (var type in _types)
        {
            if (string.Equals(coffee.ToLower(), type.Name))
            {
                // we have 
                var order = new Item(type);
                return order;
            }
        }

        Console.WriteLine("NONE");
        return null;
    }
}