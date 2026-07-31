namespace sol2;

public class WinButton : IButton
{
    public int A { get; set; }
    public string Name { get; set; }

    public WinButton()
    {
        this.A = 10;
        this.Name = "Default";
    }
}