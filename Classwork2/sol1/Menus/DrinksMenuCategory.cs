namespace sol5.Menus;

public class DrinksMenuCategory : IMenuCategory
{
    private readonly MenuComponent[] _list =
    {
        new MenuComponent("chay", 100),
        new MenuComponent("kofe", 40)
    };

    public MenuComponent[] List => _list; // uxordum a privat listis
}