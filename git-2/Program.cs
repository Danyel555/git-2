int fag;
while (true)
{
    Console.WriteLine("Меню\n" +
        "1-Угадай число\n" +
        "2-Таблица умножения\n" +
        "3-Вывод делителей числа\n" +
        "4-Выход из программы\n");
    Console.WriteLine("Выберите пункт меню: ");
    fag = Convert.ToInt32(Console.ReadLine());
    switch (fag)
    {
        case 1:
            Random r = new Random();
            int rn = r.Next(0, 100);
            while (true)
            {
                Console.WriteLine("Введите число: ");
                string t = Console.ReadLine();
                int mn = Convert.ToInt32(t);
                if (rn > mn)
                {
                    Console.WriteLine("Больше");
                }
                if (rn < mn)
                {
                    Console.WriteLine("Меньше");
                }
                if (rn == mn)
                {
                    Console.WriteLine("Вы выиграли!");
                    break;
                }
            }
            break;
        case 2:
            var table = new int[10, 10];
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    table[i, j] = i * j;
                }
            }
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    Console.Write("{0, 3}", table[i, j]);
                }
                Console.WriteLine();
            }
            break;
        case 3:
            Console.Write("Введите число: ");
            int num = int.Parse(Console.ReadLine());
            for (int i = 1; i <= num; i++)
                if (num % i == 0)
                    Console.WriteLine("{0}/{1}", num, i);
            break;
        case 4:
            Environment.Exit(0);
            break;
    }
}
