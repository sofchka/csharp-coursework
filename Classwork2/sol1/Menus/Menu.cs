namespace sol5.Menus;

public class Menu
{
    public IMenuCategory[] Categories { get; }  =
    {
        new BreakfastMenuCategory(),
        new DrinksMenuCategory(),
        new HotMealsMenuCategory(),
        new SpecialsMenuCategory()
    };
}