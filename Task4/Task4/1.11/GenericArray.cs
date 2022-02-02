namespace Task4._1._11;

public class GenericArray<T>
    where T : struct
{
    private T[] _array;

    private int _lastIndex = 0;

    public T this[int index] => _array[index];

    public GenericArray(int length)
    {
        _array = new T[length];
    }

    public void Add(T value)
    {
        GetLastIndex();
        _array[_lastIndex] = value;
    }

    public void Delete(int index)
    {
        _array[index] = default(T);
    }

    public int GetLength() => _array.Length;

    private void GetLastIndex()
    {
        for (int i = 0; i < _array.Length; i++)
        {
            if (!EqualityComparer<T>.Default.Equals(_array[i], default(T))) 
                continue;
            
            _lastIndex = i;
            break;
        }
    }
}