using System;

class Program
{
    static string CheckPoint(double x, double y, double R)
    {
        double distance = x * x + y * y;
        bool insideCircle = distance < R * R;
        bool onCircle = distance == R * R;

        bool inShadedArea = (x <= 0 && y >= 0) || (x >= 0 && y <= 0);

        if (onCircle && inShadedArea)
            return "На межі";
        else if (insideCircle && inShadedArea)
            return "Так";
        else
            return "Ні";
    }

    static void Main()
    {
        Console.Write("Введіть радіус кола (R): ");
        double R = double.Parse(Console.ReadLine());

        Console.Write("Введіть координату x: ");
        double x = double.Parse(Console.ReadLine());

        Console.Write("Введіть координату y: ");
        double y = double.Parse(Console.ReadLine());

        string result = CheckPoint(x, y, R);
        Console.WriteLine(result);
    }
}