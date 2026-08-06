using sol3.Factories;

namespace sol3;

// after where T : 
// we can write 
// <Base class> -> T must be that class or its inherited children
// <Interface> -> T must implement that
// class -> must be reference type (string, array, interface ...)
// struct -> must be value type (int, double, ...)
// new() -> must have a public parameterless constructor

//!!!
// class Factory<T> where T : new()
// {
//     public T Create(){
//         return new T();
//     }
// }
//Factory<Person> factory = new Factory<Person>();
// Person person = factory.Create();
// IEnumerable<>
// this type says everything that has separate members(arr, list, set...)

public class Sorter<T> where T : IComparable<T> // this means we accept only type that already know how to compare to each other
{
    private ISortFactory<T>[] _arrSortTypes =
    [
        new BubbleSortFactory<T>(),
        new InsertionSortFactory<T>(),
        new SelectionSortFactory<T>(),
        new QuickSortFactory<T>()
    ];
    
    public IEnumerable<T>? Sort(IEnumerable<T> collection, string sortType, Comparer<T> comparer)
    {
        foreach (var type in _arrSortTypes)
        {
            if (Equals(type.Type, sortType))
            {
                var sorter = type.Create(collection, comparer);
                return sorter.Sort();
            }
        }
        return null;
    }
}