using System;

class Program
{
    static void Main()
    {
        int rows = 5, cols = 4;
        int[,] matrix = new int[rows, cols];
        Random rand = new Random();
        Console.WriteLine("Початкова матриця:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = rand.Next(-50, 50);
                Console.Write($"{matrix[i, j],4}");
            }
            Console.WriteLine();
        }
        
        Console.WriteLine("\nВведіть порогове значення: ");
        int thershold = int.Parse(Console.ReadLine());
        
        int replacedCount = 0;
        int replacedSum = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] < thershold)
                {
                    replacedSum += matrix[i, j];
                    matrix[i, j] = 0;
                    replacedCount++;
                }
            }
        }
        Console.WriteLine("\nМодифікована матриця: ");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
               Console.Write($"{matrix[i, j],4}"); 
            }
            Console.WriteLine();
        }
        
        Console.WriteLine($"\nКількість замінених елементів: {replacedCount}");
        Console.WriteLine($"Сума замінених елементів: {replacedSum}");
    }
}