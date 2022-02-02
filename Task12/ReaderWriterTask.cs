namespace Task12;

public class ReaderWriterTask
{
    private readonly int _readersCount = 6;

    private readonly int _writersCount = 5;

    private static readonly ReaderWriterLockSlim _rwLockSlim = new();
    
    private readonly List<int> _buffer = new();

    public ReaderWriterTask()
    {
        var threads = new List<Thread>();
        for (int i = 0; i < _readersCount; i++)
        {
            var readerThread = new Thread(Read)
            {
                Name = $"Читатель #{i}"
            };
            threads.Add(readerThread);
        }
        
        for (int i = 0; i < _writersCount; i++)
        {
            var writerThread = new Thread(Write)
            {
                Name = $"Писатель #{i}"
            };
            threads.Add(writerThread);
        }
        
        foreach (var thread in threads)
            thread.Start();
    }

    private void Read()
    {
        if (_rwLockSlim.TryEnterReadLock(100))
        {
            try
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} зашел и начал чтение");
                if (_buffer.Any())
                    Console.WriteLine(
                        $"{Thread.CurrentThread.Name} прочитал: {_buffer[new Random().Next(0, _buffer.Count - 1)]}");
                Console.WriteLine($"{Thread.CurrentThread.Name} закончил чтение и вышел");
            }
            finally
            {
                _rwLockSlim.ExitReadLock();
            }
        }
    }

    private void Write()
    {
        if (_rwLockSlim.TryEnterWriteLock(100))
        {
            try
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} вошел и начал запись");
                _buffer.Add(new Random().Next(0, 999999));
                Console.WriteLine($"{Thread.CurrentThread.Name} записал значение в буффер");
                Console.WriteLine($"{Thread.CurrentThread.Name} закончил запись и вышел");
            }
            finally
            {
                _rwLockSlim.ExitWriteLock();
            }
        }
        
    }
}