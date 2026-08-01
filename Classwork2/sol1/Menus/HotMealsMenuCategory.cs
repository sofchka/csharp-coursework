namespace sol5.Menus;

public class HotMealsMenuCategory : IMenuCategory
{
    private readonly MenuComponent[] _list =
    {
        new MenuComponent("Hac u chay", 1000)
    };
    
    public MenuComponent[] List => _list;
}