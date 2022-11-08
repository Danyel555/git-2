Random RandomClass = new Random();
int x = RandomClass.Next(1, 100);
Console.WriteLine("Число от 1 до 100, угадай какое?");
int guess = 0;
while (guess != x)
{
    guess = Convert.ToInt32(Console.ReadLine()); 
    if (guess == x)
    {
        Console.WriteLine("Вы угадали!");
        Console.ReadLine(); 
    }
    else if (guess != x)
    {
        if (guess < x)
        {
            Console.WriteLine("Число меньше");
            Console.ReadLine(); 
        }
        else if (guess > x)
        {
            Console.WriteLine("Число больше");
            Console.ReadLine(); 
        }
    }
    Console.ReadLine(); 
}

test();

void table()
{
throw new NotImplementedException();
}
static void test(int[] numbers)
{
    var Table = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    for (var i = 0; i < numbers.Length; i++)
        numbers[i] = numbers[i] * numbers[i];
}
