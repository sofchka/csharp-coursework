namespace sol3.Factories;
using sol3.Algorithms;

public class InsertionSortFactory<T> : ISortFactory<T> where T : IComparable<T>
{
    public string Type { get; } = "InsertionSort";
    
    public ISorter<T> Create(IEnumerable<T> collection, IComparer<T> comparer)
    {
        return new InsertionSort<T>(collection, comparer);
    }
}