using System.Collections.Concurrent;

namespace Task12;

public class ConsumerProducerTask
{
    private int _lastIndex = 0;
    
    private BlockingCollection<int> buffer = new();

    public ConsumerProducerTask()
    {
        var producerThread = new Thread(Write);
        var consumerThread = new Thread(Read);

        try
        {
            producerThread.Start();
            consumerThread.Start();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        Console.ReadKey();
    }

    private void Read()
    {
        Console.WriteLine($"{Thread.CurrentThread.Name} зашёл");
        int i;
        while (!buffer.IsCompleted)
        {
            if (buffer.TryTake(out i))
            {
                Console.WriteLine($"Потребитель прочитал данные: {i}");
            }
            else
            {
                Console.WriteLine($"Потребитель, ждет...");
            }
        }
        Console.WriteLine($"Потребитель вышел");
    }

    private void Write()
    {
        Console.WriteLine($"Производитель зашел");
        for (int i = 0; i < 100; i++)
        {
            buffer.Add(i * i);
            Console.WriteLine("Производитель производит число " + i * i);
        }
        buffer.CompleteAdding();
        Console.WriteLine("Производитель окончил производство");
    }
}