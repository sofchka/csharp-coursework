using LINQ;

namespace Program_Linq
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer> {
                new(1, "Анна", "Москва", 28),
                new(2, "Борис", "Казань", 41),
                new(3, "Вера", "Москва", 35),
                new(4, "Глеб", "Сочи", 22),
                new(5, "Дина", "Казань", 30),
            };
            
            List<Product> products = new List<Product> {
                new(1, "Ноутбук", "Электроника", 89990m),
                new(2, "Мышь", "Электроника", 1990m),
                new(3, "Кофе", "Продукты", 890m),
                new(4, "Чайник", "Быт", 3490m),
                new(5, "Монитор", "Электроника", 24990m),
                new(6, "Шоколад", "Продукты", 150m),
            };
            
            List<Order> orders = new List<Order> {
                new(101, 1, new DateTime(2025, 1, 15)),
                new(102, 1, new DateTime(2025, 3, 02)),
                new(103, 2, new DateTime(2025, 3, 18)),
                new(104, 3, new DateTime(2024, 11, 30)),
                new(105, 5, new DateTime(2025, 5, 09)),
                new(106, 5, new DateTime(2025, 5, 21)),
            };
            
            List<OrderItem> items = new List<OrderItem> {
                new(101, 1, 1), new(101, 2, 2),
                new(102, 3, 5),
                new(103, 5, 2), new(103, 2, 1),
                new(104, 4, 1), new(104, 6, 10),
                new(105, 1, 2), new(105, 5, 1),
                new(106, 3, 3),
            };

            // Task 1
            var moscowByAge = customers
                .Where(c => c.City is "Москва")
                .OrderByDescending(c => c.Age);
            
            
            foreach (var title in moscowByAge)
            {
                Console.WriteLine(title);
            }
            Console.Write("\n");

            // Task 2
            var expensiveProductTitles = products
                .Where(p => p.Price > 3000)
                .Select(p => p.Title);
            
            
            foreach (var title in expensiveProductTitles)
            {
                Console.WriteLine(title);
            }
            Console.Write("\n");
            
            // Task 3
            var averageAge = customers
                .Average(c => c.Age);

            var maxPriceProduct = products
                .MaxBy(c => c.Price);
            
            Console.WriteLine(averageAge);
            Console.WriteLine(maxPriceProduct);
            Console.Write("\n");

            var maxPriceProductAggregate = products // ujs
                .Aggregate(
                    (max, product) => product.Price > max.Price ? product : max
                );
            
            Console.WriteLine(maxPriceProductAggregate);
            Console.Write("\n");

            // Task 5
            var productsPerCategory = products
                .GroupBy(p => p.Category)
                .Select(g => new // anonim
                {
                    Category = g.Key,
                    Count = g.Count()
                })
                .ToList();
            
            Console.WriteLine(productsPerCategory.GetType()); // AnonymousType0

            
            foreach (var title in productsPerCategory)
            {
                Console.WriteLine(title);
            }
            Console.Write("\n");

            var averagePricePerCategory = products
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Average = g.Average(p => p.Price)
                })
                .ToList();

            Console.WriteLine(averagePricePerCategory.GetType()); // System.Collections.Generic.List`1[<>f__AnonymousType1`1[System.Decimal]]

            foreach (var title in averagePricePerCategory)
            {
                Console.WriteLine(title);
            }
            Console.Write("\n");
            
            // Task 6
            var namesByCity = customers
                .GroupBy(p => p.City)
                .Select(g => new
                {
                    City = g.Key,
                    Names = string.Join(",", g.Select(c => c.Name))
                })
                .ToList();

            foreach (var title in namesByCity)
            {
                Console.WriteLine(title);
            }
            Console.Write("\n");
            
            // Task 7
            var orderNames = orders
                .Join(
                    customers,
                    o => o.CustomerId,
                    c => c.Id,
                    (o, c) => new
                    {
                        OrderId = o.Id,
                        CustomerName = c.Name,
                        Date = o.Date
                    })
                .ToList();

            foreach (var order in orderNames)
            {
                Console.WriteLine(
                    $"{order.OrderId} | {order.CustomerName} | {order.Date:d}");
            }
            
            var orderNamesQuery =
                from o in orders
                join c in customers
                    on o.CustomerId equals c.Id
                select new
                {
                    OrderId = o.Id,
                    CustomerName = c.Name,
                    Date = o.Date
                };

            foreach (var order in orderNamesQuery)
            {
                Console.WriteLine(
                    $"{order.OrderId} | {order.CustomerName} | {order.Date:d}");
            }
        }
    }
}

