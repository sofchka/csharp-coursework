using System;

class MyList
{
    private int[] _items;
    private int _count;

    public MyList()
    {
        _items = new int[4];
        _count = 0;
    }

    public int Count
    {
        get { return _count; }
    }

    public void Add(int item)
    {
        EnsureCapacity();

        _items[_count] = item;
        _count++;
    }

    public void AddRange(int[] items)
    {
        if (items == null)
            return;

        for (int i = 0; i < items.Length; i++)
            Add(items[i]);
    }

    public bool Remove(int item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_items[i] == item)
            {
                for (int j = i; j < _count - 1; j++)
                    _items[j] = _items[j + 1];

                _count--;
                return true;
            }
        }

        return false;
    }

    public bool TryGet(int index, out int value)
    {
        if (index < 0 || index >= _count)
        {
            value = 0;
            return false;
        }

        value = _items[index];
        return true;
    }

    public int IndexOf(int item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_items[i] == item)
                return i;
        }

        return -1;
    }

    public bool Contains(int item)
    {
        return IndexOf(item) != -1;
    }

    public void Clear()
    {
        _count = 0;
    }

    private void EnsureCapacity()
    {
        if (_count < _items.Length)
            return;

        int[] biggerItems = new int[_items.Length * 2];

        for (int i = 0; i < _count; i++)
            biggerItems[i] = _items[i];

        _items = biggerItems;
    }
}