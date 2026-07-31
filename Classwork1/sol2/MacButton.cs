namespace sol2;

public class MacButton : IButton
{
    public int A { get; set; }
    public string Name { get; set; }

    public MacButton()
    {
        this.A = 1;
        this.Name = "Default";
    }
}