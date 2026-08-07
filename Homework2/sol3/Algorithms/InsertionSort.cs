namespace sol3.Algorithms;

public class InsertionSort<T> : ISorter<T> where T : IComparable<T> // to use CompareTo
{
    private IEnumerable<T> _collection;
    private IComparer<T>? _comparer; // ? to take nulls

    public InsertionSort(IEnumerable<T> collection)
    {
        _collection = collection;
        _comparer = null;
    }

    public InsertionSort(IEnumerable<T> collection, IComparer<T> comparer)
    {
        _collection = collection;
        _comparer = comparer;
    }

    public IEnumerable<T> Sort()
    {
        List<T> list = new List<T>(_collection);

        for (int i = 1; i < list.Count; i++)
        {
            T key = list[i];
            int j = i - 1;
            while (j >= 0 &&
                   ((_comparer != null && _comparer.Compare(list[j], key) > 0) ||
                    (_comparer == null && list[j].CompareTo(key) > 0)))
            {
                list[j + 1] = list[j];
                j--;
            }
            list[j + 1] = key;
        }

        return list;
    }
}