using sol3;
using System.Collections;

namespace sol3;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>
        {
            64, 25, 12, 22, 11
        };

        Sorter<int> sorter = new Sorter<int>();

        Console.WriteLine("Original:");
        Print(numbers);

        Console.WriteLine("\nBubble Sort:");
        var bubble = sorter.Sort(numbers, "BubbleSort", Comparer<int>.Default);
        Print(bubble);

        Console.WriteLine("\nInsertion Sort:");
        var insertion = sorter.Sort(numbers, "InsertionSort", Comparer<int>.Default);
        Print(insertion);

        Console.WriteLine("\nSelection Sort:");
        var selection = sorter.Sort(numbers, "SelectionSort", Comparer<int>.Default);
        Print(selection);

        Console.WriteLine("\nQuick Sort:");
        var quick = sorter.Sort(numbers, "QuickSort", Comparer<int>.Default);
        Print(quick);
    }


    static void Print(IEnumerable<int>? collection)
    {
        if (collection == null)
        {
            Console.WriteLine("null");
            return;
        }

        foreach (var item in collection)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine();
    }
}