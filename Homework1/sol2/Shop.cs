namespace sol2;

public class Shop
{
    private string _productName;
    private int _price;
    private int _quantity;

    public Shop()
    {
        _productName = "";
    }
    
    public void ReadInfo()
    {
        Console.WriteLine("Enter your desired Product Name: ...");
        _productName = Console.ReadLine() ?? "";
        
        Console.WriteLine("Enter The Price: ...");
        while (!int.TryParse(Console.ReadLine(), out _price))
            Console.WriteLine("Enter Valid Price: ...");
        
        Console.WriteLine("Enter Quantity you want: ...");
        while (!int.TryParse(Console.ReadLine(), out _quantity))
            Console.WriteLine("Enter Valid number: ...");
    }

    public void FinalPrice()
    {
        double subtotal = _price * _quantity;
        
        if (subtotal > 100)
        {
            double discount = subtotal * 0.1;
            double finalPrice = subtotal - discount;
            Console.WriteLine("--------------------\n" + _productName + "\nSubtotal: " + subtotal + "\nDiscount: " 
                              + discount + "\nFinal Price: " + finalPrice + "\n--------------------");
            return ;
        }
        Console.WriteLine("--------------------\n" + _productName + "\nSubtotal: " + subtotal
                          + "\nDiscount: 0\nFinal Price: " + subtotal + "\n--------------------");
    }
}