namespace sol3.Algorithms;

public class SelectionSort<T> : ISorter<T> where T : IComparable<T> // to use CompareTo
{
    private IEnumerable<T> _collection;
    private IComparer<T>? _comparer; // ? to take nulls

    public SelectionSort(IEnumerable<T> collection)
    {
        _collection = collection;
        _comparer = null;
    }

    public SelectionSort(IEnumerable<T> collection, IComparer<T> comparer)
    {
        _collection = collection;
        _comparer = comparer;
    }

    public IEnumerable<T> Sort()
    {
        List<T> list = new List<T>(_collection);

        for (int i = 0; i < list.Count - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < list.Count; j++)
            {
                bool isSmaller =
                    (_comparer != null && _comparer.Compare(list[j], list[minIndex]) < 0) ||
                    (_comparer == null && list[j].CompareTo(list[minIndex]) < 0);

                if (isSmaller)
                {
                    minIndex = j;
                }
            }

            (list[i], list[minIndex]) = (list[minIndex], list[i]);
        }

        return list;
    }
}