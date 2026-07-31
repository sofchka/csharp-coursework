namespace Calculator;

public class Item
{
    private readonly string _name;
    private readonly int _price;
    
    public Item(MenuItem name)
    {
        this._name = name.Name;
        this._price = name.Price;
    }

    public override string ToString()
    {
        return "Your " + this._name + " is " + this._price;
    }
}
