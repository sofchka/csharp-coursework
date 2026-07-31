namespace sol2;

public class MacOsFactory : IOsFactory
{
    public ICheckBox CreateCheckBox()
    {
        var res = new MacCheckBox();
        return res;
    }

    public IButton CreateButton()
    {
        var res = new MacButton();
        return res;
    }
}