namespace sol3.Factories;
using sol3.Algorithms;

public class QuickSortFactory<T> : ISortFactory<T> where T : IComparable<T>
{
    public string Type { get; } = "QuickSort";
    
    public ISorter<T> Create(IEnumerable<T> collection, IComparer<T> comparer)
    {
        return new QuickSort<T>(collection, comparer);
    }
}