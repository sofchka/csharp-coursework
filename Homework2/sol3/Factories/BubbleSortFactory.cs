namespace sol3.Factories;
using sol3.Algorithms;

public class BubbleSortFactory<T> : ISortFactory<T> where T : IComparable<T>
{
    public string Type { get; } = "BubbleSort";
    
    public ISorter<T> Create(IEnumerable<T> collection, IComparer<T> comparer)
    {
        return new BubbleSort<T>(collection, comparer);
    }
}