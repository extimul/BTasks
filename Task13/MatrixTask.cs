namespace Task13;

public class MatrixTask
{
    private readonly Random _random = new();
    
    public void Start()
    {
        int[,] _matrix1 = new int[1000, 1000];
        int[,] _matrix2 = new int[1000, 1000];
        Console.WriteLine("Матрица А");
        FillMatrix(ref _matrix1);
        Console.WriteLine("Матрица B");
        FillMatrix(ref _matrix2);

        var resultMatrix = MultiplyMatrix(_matrix1, _matrix2);
        Console.WriteLine("Произведение матриц:");
        DisplayMatrix(resultMatrix);
    }

    private void FillMatrix(ref int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = _random.Next(0, 999);
            }
        }
        DisplayMatrix(matrix);
    }

    private static int[,] MultiplyMatrix(int[,] matrixA, int[,] matrixB)
    {
        int[,] result = new int[1000,1000];
        int matACols = matrixA.GetLength(1);
        int matBCols = matrixB.GetLength(1);
        int matARows = matrixA.GetLength(0);
        
        Parallel.For(0, matARows, i =>
        {
            for (int j = 0; j < matBCols; j++)
            {
                var temp = 0;
                for (int k = 0; k < matACols; k++)
                {
                    temp += matrixA[i, k] * matrixB[k, j];
                }
                result[i, j] = temp;
            }
        });

        return result;
    }

    private void DisplayMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i,j]}\t");
            }
            Console.WriteLine();
        }
    }
}