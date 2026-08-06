namespace sol3.Factories;
using sol3.Algorithms;

public class SelectionSortFactory<T> : ISortFactory<T> where T : IComparable<T>
{
    public string Type { get; } = "SelectionSort";
    
    public ISorter<T> Create(IEnumerable<T> collection, IComparer<T> comparer)
    {
        return new SelectionSort<T>(collection, comparer);
    }
}