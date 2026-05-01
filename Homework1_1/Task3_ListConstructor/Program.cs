class Program
{
    static void Main()
    {
        MyList list = new MyList();

        list.Add(10);
        list.Add(20);
        list.Add(30);
        list.AddRange(new int[] { 40, 50 });

        Console.WriteLine(list.Count); // 5

        if (list.TryGet(0, out int value1))
            Console.WriteLine(value1); // 10

        if (list.TryGet(3, out int value2))
            Console.WriteLine(value2); // 40

        list.Remove(20);

        Console.WriteLine(list.Count);        // 4
        Console.WriteLine(list.Contains(20)); // False
        Console.WriteLine(list.IndexOf(40));  // 2

        list.Clear();

        Console.WriteLine(list.Count); // 0
    }
}