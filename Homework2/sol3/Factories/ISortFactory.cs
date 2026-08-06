namespace sol3.Factories;
using sol3.Algorithms;

public interface ISortFactory<T>
{
    string Type { get; }
    
    ISorter<T> Create(IEnumerable<T> collection, IComparer<T> comparer);
}