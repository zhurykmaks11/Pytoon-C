using System;

class JaggedArrayTask
{
    static void Main()
    {
        Random random = new Random();
        
        Console.Write("Введіть кількість рядків (n): ");
        int n = int.Parse(Console.ReadLine());

   
        int[][] jaggedArray = new int[n][];
        
        Console.WriteLine("\nЗгенерований зубчастий масив:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введіть кількість елементів у рядку {i + 1}: ");
            int m = int.Parse(Console.ReadLine());
            jaggedArray[i] = new int[m];

            for (int j = 0; j < m; j++)
            {
                jaggedArray[i][j] = random.Next(-50, 50); 
            }

            Console.WriteLine($"Рядок {i + 1}: " + string.Join(" ", jaggedArray[i]));
        }
        
        Console.Write("\nВведіть порогове значення: ");
        int threshold = int.Parse(Console.ReadLine());

        // Масив для збереження кількості елементів, більших за порогове значення
        int[] countArray = new int[n];

        // Підрахунок кількості елеме що перевищують поріг
        for (int i = 0; i < n; i++)
        {
            int count = 0;
            foreach (int num in jaggedArray[i])
            {
                if (num > threshold)
                    count++;
            }
            countArray[i] = count;
        }

        // Вивід результату
        Console.WriteLine("\nКількість елементів, більших за " + threshold + ", у кожному рядку:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Рядок {i + 1}: {countArray[i]} елементів");
        }
    }
}