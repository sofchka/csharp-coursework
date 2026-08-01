namespace sol5.Menus;

public class MenuComponent
{
    public readonly int Price;
    public readonly string Name;

    public MenuComponent(string name, int price)
    {
        Price = price;
        Name = name;
    }
}