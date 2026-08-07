namespace sol3.Algorithms;

public class QuickSort<T> : ISorter<T> where T : IComparable<T> // to use CompareTo
{
    private IEnumerable<T> _collection;
    private IComparer<T>? _comparer; // ? to take nulls

    public QuickSort(IEnumerable<T> collection)
    {
        _collection = collection;
        _comparer = null;
    }

    public QuickSort(IEnumerable<T> collection, IComparer<T> comparer)
    {
        _collection = collection;
        _comparer = comparer;
    }

    public IEnumerable<T> Sort()
    {
        List<T> list = new List<T>(_collection);
        
        // soon -> alareci
        return list;
    }
}