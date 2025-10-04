//1
using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите x: ");
        double x = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите точность e (<0.01): ");
        double eps = Convert.ToDouble(Console.ReadLine());
        if (eps <= 0 || eps >= 0.01)
        {
            Console.WriteLine("Ошибка: точность должна быть больше 0 и меньше 0.01.");
            eps = 0.001;
        }

        double sum = 1;
        int n = 1;
        double term = 0;
        int i;

        for (i = 1; ; i++)
        {
            term = Math.Pow(-1, i) * Math.Pow(x, 2 * i) / Factorial(2 * i);
            if (Math.Abs(term) <= eps) break;
            sum += term;
        }

        Console.WriteLine($"cos({x}) ≈ {sum}");

        Console.Write("Введите n для n-го члена ряда: ");
        int N = Convert.ToInt32(Console.ReadLine());

        if (N <= 0)
        {
            Console.WriteLine("Ошибка: n должно быть положительным.");
        }
        else
        {
            int index = N - 1;
            double nth = Math.Pow(-1, index) * Math.Pow(x, 2 * index) / Factorial(2 * index);
            Console.WriteLine($"{N}-й член ряда = {nth}");
        }
    }

    static double Factorial(int n)
    {
        double res = 1;
        for (int i = 1; i <= n; i++) res *= i;
        return res;
    }
}
//2
using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите 6-значный номер билета: ");
        int ticket = int.Parse(Console.ReadLine());

        int leftSum = 0, rightSum = 0;

        for (int i = 0; i < 6; i++)
        {
            int digit = ticket % 10;
            ticket /= 10;

            if (i < 3) rightSum += digit;
            else leftSum += digit;
        }

        Console.WriteLine(leftSum == rightSum);
    }
}
//3
using System;

class Program
{
    static void Main()
    {

        Console.WriteLine("Загадайте число от 0 до 63.");
        int low = 0, high = 63;

        for (int i = 0; i < 6; i++)
        {
            int mid = (low + high) / 2;
            Console.Write($"Ваше число больше {mid}? (1 - да, 0 - нет): ");
            int ans = int.Parse(Console.ReadLine());
            if (ans == 1) low = mid + 1;
            else high = mid;
        }

        Console.WriteLine($"Ваше число: {low}");
    }
}
//4
using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество бактерий: ");
        int N = int.Parse(Console.ReadLine());
        Console.Write("Введите количество антибиотика: ");
        int X = int.Parse(Console.ReadLine());

        int hour = 0;

        while (N > 0 && hour < 10)
        {
            hour++;
            N *= 2;

            int kill = X * (11 - hour); 

            N -= kill;

            if (N <= 0)
            {
                Console.WriteLine($"После {hour} часа бактерий осталось 0");
                Console.WriteLine("Эксперимент завершён.");
                return;
            }

            Console.WriteLine($"После {hour} часа бактерий осталось {N}");
        }

        if (hour == 10)
            Console.WriteLine("Антибиотик перестал действовать.");
    }
}
//5
using System;

class Program
{
    private const int AmericanoWater = 300;
    private const int AmericanoPrice = 150;
    private const int LatteWater = 30;
    private const int LatteMilk = 270;
    private const int LattePrice = 170;

    static void Main()
    {
        Console.Write("Введите количество воды (мл): ");
        if (!int.TryParse(Console.ReadLine(), out int water) || water < 0)
        {
            Console.WriteLine("Некорректное количество воды.");
            return;
        }

        Console.Write("Введите количество молока (мл): ");
        if (!int.TryParse(Console.ReadLine(), out int milk) || milk < 0)
        {
            Console.WriteLine("Некорректное количество молока.");
            return;
        }

        int americanoCount = 0;
        int latteCount = 0;
        int money = 0;

        while (CanMakeAnyDrink(water, milk))
        {
            Console.Write("Выберите напиток (1 — американо, 2 — латте, 0 — выход): ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    PrintReport(water, milk, americanoCount, latteCount, money);
                    return;

                case "1":
                    if (water >= AmericanoWater)
                    {
                        water -= AmericanoWater;
                        americanoCount++;
                        money += AmericanoPrice;
                        Console.WriteLine("Ваш американо готов.");
                    }
                    else
                    {
                        Console.WriteLine("Не хватает воды для американо.");
                    }
                    break;

                case "2":
                    if (water >= LatteWater && milk >= LatteMilk)
                    {
                        water -= LatteWater;
                        milk -= LatteMilk;
                        latteCount++;
                        money += LattePrice;
                        Console.WriteLine("Ваш латте готов.");
                    }
                    else
                    {
                        Console.WriteLine(water < LatteWater ? "Не хватает воды для латте." : "Не хватает молока для латте.");
                    }
                    break;

                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, выберите 1, 2 или 0.");
                    break;
            }
        }

        PrintReport(water, milk, americanoCount, latteCount, money);
    }

    private static bool CanMakeAnyDrink(int water, int milk)
    {
        return water >= AmericanoWater || (water >= LatteWater && milk >= LatteMilk);
    }

    private static void PrintReport(int water, int milk, int americanoCount, int latteCount, int money)
    {
        Console.WriteLine("\n*Отчёт*");
        Console.WriteLine("Ингредиенты подошли к концу");
        Console.WriteLine($"Вода: {water} мл");
        Console.WriteLine($"Молоко: {milk} мл");
        Console.WriteLine($"Кружек американо: {americanoCount}");
        Console.WriteLine($"Кружек латте: {latteCount}");
        Console.WriteLine($"Итого: {money} руб.");
    }
}
