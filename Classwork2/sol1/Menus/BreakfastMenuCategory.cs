namespace sol5.Menus;

public class BreakfastMenuCategory : IMenuCategory
{
    private readonly MenuComponent[] _list =
    {
        new MenuComponent("Hac u panir", 500),
        new MenuComponent("Hac u chay", 100),
        new MenuComponent("Hac u kofe", 40),
        new MenuComponent("Hac u mexr", 50),
        new MenuComponent("Hac u karag", 5000)
    };
    
    public MenuComponent[] List => _list;
}