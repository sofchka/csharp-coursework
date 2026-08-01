namespace sol5.Menus;

public class SpecialsMenuCategory : IMenuCategory
{
    private readonly MenuComponent[] _list =
    {
        new MenuComponent("Hac", 50000)
    };
    
    public MenuComponent[] List => _list;
}