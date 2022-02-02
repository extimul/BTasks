using System.Collections.Concurrent;

namespace Task11;

public class Task13
{
    private readonly int[,] _field;

    private readonly Gardener _gardener1 = new("g1", 1);

    private readonly Gardener _gardener2 = new("g2", 2);

    private object locker = new object();

    private bool _IsRunning = true;

    public Task13(int[,] field)
    {
        _field = field;
    }

    public void Run()
    {
        var gardener1Thread = new Thread(Gardener1DoWork);
        var gardener2Thread = new Thread(Gardener2DoWork);
        // var displayFieldThread = new Thread(DisplayField);

        gardener1Thread.Start();
        gardener2Thread.Start();
        gardener1Thread.Join();
        gardener2Thread.Join();
        // displayFieldThread.Start();
        // gardener1.Start();
        // gardener2.Start();
        // Gardener1DoWork();
        // Gardener2DoWork();
        
        DisplayField();
    }

    private void Gardener1DoWork()
    {
        for (int i = 0; i < _field.GetLength(0); i++)
        {
            for (int j = 0; j < _field.GetLength(1); j++)
            {
                Fill(i,j, _gardener1, _gardener2);
            }
        }
    }

    private void Gardener2DoWork()
    {
        for (int i = _field.GetLength(0) - 1; i >= 0; i--)
        {
            for (int j = _field.GetLength(1) - 1; j >= 0; j--)
            {
                Fill(i, j, _gardener2, _gardener1);
            }
        }
    }

    private void DisplayField()
    {
        // while (_IsRunning)
        // {
            Console.Clear();
            for (int i = 0; i < _field.GetLength(0); i++)
            {
                for (int j = 0; j < _field.GetLength(1); j++)
                {
                    Console.Write($"{_field[i,j]}\t");
                    Thread.Sleep(1);
                }
                Console.WriteLine();
            }
        // }
    }
    
    private void Fill(int x, int y, Gardener currentGardener, Gardener anotherGardener)
    {
        lock (locker)
        {
            if (_field[x, y] == anotherGardener.Code)
                return;
            _field[x, y] = currentGardener.Code;
            Thread.Sleep(1);
        }
    }
}