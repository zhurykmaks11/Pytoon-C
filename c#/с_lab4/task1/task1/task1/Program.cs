using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = "input.txt"; 
        string outputPath = "output.txt";
        int rows = 3;
        int cols = 11;
        string [,] data = new string[rows, cols];

        using (StreamReader reader = new StreamReader(inputPath))
        {
            for (int i = 0; i < rows; i++)
            {
                string line = reader.ReadLine() ;
                if (line != null)
                {
                    string[] parts = line.Split(' ');
                    for (int j = 0; j < cols; j++)
                    {
                       data[i, j] = parts[j]; 
                    }
                }
            }
        }

        using (StreamWriter writer = new StreamWriter(outputPath))
        {
            writer.WriteLine(" call phone,with start of 095");
            for (int i = 0; i < rows; i++)
            {
                string phoneNumber = data[i, 10];
                if (phoneNumber.StartsWith("095"))
                {
                    writer.WriteLine($"Прізвище: {data[i, 0]}, Ім'я: {data[i, 1]}, По-батькові: {data[i, 2]}");
                    writer.WriteLine($"Адреса: {data[i, 3]}, {data[i, 4]}, {data[i, 5]}, {data[i, 6]}, {data[i, 7]}, {data[i, 8]}");
                    writer.WriteLine($"Телефон: {phoneNumber}");
                    writer.WriteLine();
                }
            }
        }
        Console.WriteLine("Press any key to continue...");
        
    }
}
