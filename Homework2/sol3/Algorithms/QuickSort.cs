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
        
        for (int i = 0; i < list.Count - 1; i++)
        {
            for (int j = 0; j < list.Count - i - 1; j++)
            {
                if ((_comparer != null && _comparer.Compare(list[j], list[j + 1]) > 0)
                    || (_comparer == null && list[j].CompareTo(list[j + 1]) > 0))
                {
                    (list[j], list[j + 1]) = (list[j + 1], list[j]);
                }
            }
        }
        return list;
    }
}