namespace Task12;

public class SemaphoreReader
{
    private readonly Thread _thread;
    
    private static Semaphore _semaphore = new Semaphore(3,3);

    private int count = 3;
    
    public SemaphoreReader(int readerNum)
    {
        _thread = new Thread(Read);
        _thread.Name = $"Читатель {readerNum.ToString()}";
        _thread.Start();
    }

    public void Read()
    {
        while (count > 0)
        {
            _semaphore.WaitOne();
            
            Console.WriteLine($"{Thread.CurrentThread.Name} входит в библиотеку");
 
            Console.WriteLine($"{Thread.CurrentThread.Name} читает");
            Thread.Sleep(1000);
 
            Console.WriteLine($"{Thread.CurrentThread.Name} покидает библиотеку");

            _semaphore.Release();
            count--;
            Thread.Sleep(1000);
        }
    }
}