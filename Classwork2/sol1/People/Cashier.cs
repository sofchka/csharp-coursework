namespace sol5.People;
using sol5.Menus;

public class Cashier
{
    public string Name { get; }

    public Cashier(string name)
    {
        Name = name;
    }

    public int BillEval(Guest person)
    {
        int sum = 0;

        foreach (var item in person.Order)
            sum += item.Price;

        return sum;
        
    }
}