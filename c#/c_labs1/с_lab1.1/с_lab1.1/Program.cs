using System;

class Program
{
    static string CheckPoint(double x, double y, double R)
    {
        double distance = x * x + y * y;
        bool insideCircle = distance < R * R;
        bool onCircle = distance == R * R;

        bool inShadedArea = (x <= 0 && y >= 0) || (x <= 0 && y <= 0 || (x > 0 && y > 0)); 

        if (onCircle)
        {
            if (inShadedArea)
            {
                return "На межі";
            }
            else
            {
                return "Ні";
            }
        }
        else if (insideCircle)
        {
            if (inShadedArea)
            {
                return "Так";
            }
            else
            {
                return "Ні";
            }
        }
        else
        {
            return "Ні";
        }
    }

    static double ReadDouble(string message)
    {
        double result;
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            
            if (double.TryParse(input, out result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Помилка! Введіть число ще раз.");
            }
        }
    }

    static void Main()
    {
        Console.WriteLine("Програма перевіряє чи знаходиться точка у заштрихованій області.");

        double R;
        do
        {
            R = ReadDouble("Введіть радіус кола (R > 0): ");
            if (R <= 0)
            {
                Console.WriteLine("Помилка! Радіус повинен бути більше 0.");
            }
        } while (R <= 0);

        double x = ReadDouble("Введіть координату x: ");
        double y = ReadDouble("Введіть координату y: ");

        string result = CheckPoint(x, y, R);
        Console.WriteLine($"Результат: {result}");
    }
}