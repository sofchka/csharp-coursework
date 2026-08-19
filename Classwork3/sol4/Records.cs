namespace LINQ;

record Customer(int Id, string Name, string City, int Age);
record Product(int Id, string Title, string Category, decimal Price);
record Order(int Id, int CustomerId, DateTime Date);
record OrderItem(int OrderId, int ProductId, int Quantity);
