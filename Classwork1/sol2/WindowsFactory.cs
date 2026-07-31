namespace sol2;

public class WindowsFactory : IOsFactory
{
    public ICheckBox CreateCheckBox()
    {
        var res = new WinCheckBox();
        return res;
    }

    public IButton CreateButton()
    {
        var res = new WinButton();
        return res;
    }
}