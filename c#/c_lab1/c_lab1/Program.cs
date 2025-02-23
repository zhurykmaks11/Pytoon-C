using System;

class ChessGame
{
    // Функція перевіряє, чи фігура може атакувати іншу
    static bool CanAttack(int x1, int y1, int x2, int y2, string piece)
    {
        switch (piece)
        {
            case "Ферзь":
                return (x1 == x2 || y1 == y2 || Math.Abs(x1 - x2) == Math.Abs(y1 - y2));
            case "Король":
                return (Math.Abs(x1 - x2) <= 1 && Math.Abs(y1 - y2) <= 1);
            default:
                return false;
        }
    }

    static void Main()
    {
        // Введення координат
        Console.Write("Введіть координати білого ферзя (x y): ");
        int[] whiteQueen = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        Console.Write("Введіть координати чорного короля (x y): ");
        int[] blackKing = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        Console.Write("Введіть координати чорного ферзя (x y): ");
        int[] blackQueen = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        // Перевірка коректності введених даних
        if (!IsValidPosition(whiteQueen) || !IsValidPosition(blackKing) || !IsValidPosition(blackQueen))
        {
            Console.WriteLine("Некоректне розташування фігур: координати мають бути від 1 до 8.");
            return;
        }

        if (AreSamePosition(whiteQueen, blackKing) || AreSamePosition(whiteQueen, blackQueen) || AreSamePosition(blackKing, blackQueen))
        {
            Console.WriteLine("Некоректне розташування: дві фігури не можуть стояти на одній клітинці.");
            return;
        }

        // Вибір першого ходу
        Console.Write("Введіть, яка фігура ходить першою (БФ, ЧК, ЧФ): ");
        string firstMove = Console.ReadLine();

        // Логіка ходів
        switch (firstMove)
        {
            case "БФ":
                if (CanAttack(whiteQueen[0], whiteQueen[1], blackKing[0], blackKing[1], "Ферзь"))
                    Console.WriteLine("Білий ферзь здійснює напад на чорного короля.");
                else if (CanAttack(whiteQueen[0], whiteQueen[1], blackQueen[0], blackQueen[1], "Ферзь"))
                    Console.WriteLine("Білий ферзь здійснює напад на чорного ферзя.");
                else
                    Console.WriteLine("Білий ферзь зробив простий хід.");
                break;

            case "ЧФ":
                if (CanAttack(blackQueen[0], blackQueen[1], whiteQueen[0], whiteQueen[1], "Ферзь"))
                    Console.WriteLine("Чорний ферзь здійснює напад на білого ферзя.");
                else
                    Console.WriteLine("Чорний ферзь зробив простий хід.");
                break;

            case "ЧК":
                if (CanAttack(blackKing[0], blackKing[1], whiteQueen[0], whiteQueen[1], "Король"))
                    Console.WriteLine("Чорний король здійснює напад на білого ферзя.");
                else
                    Console.WriteLine("Чорний король зробив простий хід.");
                break;

            default:
                Console.WriteLine("Некоректне введення. Введіть БФ, ЧК або ЧФ.");
                break;
        }
    }

    // Перевіряє, чи координати в межах шахівниці
    static bool IsValidPosition(int[] pos)
    {
        return pos[0] >= 1 && pos[0] <= 8 && pos[1] >= 1 && pos[1] <= 8;
    }

    // Перевіряє, чи дві фігури знаходяться на одній клітинці
    static bool AreSamePosition(int[] pos1, int[] pos2)
    {
        return pos1[0] == pos2[0] && pos1[1] == pos2[1];
    }
}
