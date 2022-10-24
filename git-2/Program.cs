using System.Reflection;

abstract class Option {
    public string name;
    public string desc;
    abstract public void exec();
}

class GuessingGame: Option {
    Random randomize;
    int secret;
    public GuessingGame() {
        this.name = "Игра \"Угадай число\"";
        this.desc = @"
        Рандомайзер выбирает любое число от 0 до 100.
        Вы вводите число до тех пор, пока введенное вами число не будет равно рандомному.
        Чтобы выйти, введите '-5'";
        this.randomize = new Random();
    }
    public override void exec() {
        this.secret = this.randomize.Next(100);
        int guess;
        Console.WriteLine(this.desc);
        while (true) {
            Console.Write("Введите число: ");
            try {
                guess = Convert.ToInt32(Console.ReadLine());
                if (guess == this.secret) {
                    Console.WriteLine("В точку!"); break;
                } else if (guess == -1) {
                    Console.WriteLine("До свидание!"); break;
                } else if (guess < this.secret) {
                    Console.WriteLine("Ответ меньше загаданного числа");
                } else {
                    Console.WriteLine("Ответ больше загаданного числа");
                }
            }
            catch {
                Console.WriteLine("Пожалуйста, введите число");
            }
        }
    }
}

class PrintMultiplicationTable: Option {
    public PrintMultiplicationTable() {
        this.name = "Таблица умножения";
        this.desc = "Вывод таблицы умножения до числа lastValue";
    }
    public override void exec() {
        Console.WriteLine(this.desc);
        try {
            Console.Write("Введите число с которого вы хотите просчитать таблц. умножения: ");
            int lastValue = Convert.ToInt32(Console.ReadLine());
            int[,] multiplicationTable = new int[lastValue, firstValue];
            for (int i = firstValue - 1; i < lastValue; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    multiplicationTable[i, j] = (i + 1) * (j + 1);
                }
            }
            for (int i = firstValue -1; i < lastValue; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write("{0} * {1} = {2}\t", (i + 1), (j + 1), multiplicationTable[i, j]);
                }
                Console.WriteLine();
            }
        }
        catch {
            Console.WriteLine("Пожалуйста, введите число");
        }
    }
}

class PrintNumberDividers: Option {
    public PrintNumberDividers() {
        this.name = "Вывод делителей числа";
        this.desc = @"
        Вы вводите число в консоль.
        Выводятся все числа, которые делят это число нацело.
        Чтобы выйти, введите '-5'";
    }
    public override void exec() {
        int number;
        Console.WriteLine(this.desc);
        while (true) {
            Console.Write("Введите число: ");
            try
            {
                number = Convert.ToInt32(Console.ReadLine());
                if (number == -1)
                    break;
                Console.Write("Число {0} имеет следующие делители: ", number);
                for (int i = 1; i <= number; i++)
                {
                    if (number % i == 0)
                        Console.Write("{0} ", i);
                }
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("Пожалуйста, введите число");
            }
        }
    }
}

class Menu {
    string menu = "Менюшка должна заполняться динамически. Если вы видете это, то что-то пошло не так.";
    Dictionary<int, Option> options = new Dictionary<int, Option>();
    public Menu() {
        menu = ""; menu += "-1. Выйти\n";
        var subclassess = typeof(Option).Assembly
                                        .GetTypes()
                                        .Where(t => t.IsSubclassOf(typeof(Option)) && !t.IsAbstract)
                                        .Select(t => (Option)Activator.CreateInstance(t));
        int i = 1;
        foreach(var subclass in subclassess.AsEnumerable()) {
            if (subclass != null) {
                this.options.Add(i, subclass);
                menu += Convert.ToString(i) + ". " + subclass.name + "\n";
                i++;
            }
        }
    }
    public void Process(int option) {
        if (this.options.Keys.Contains(option)) {
            this.options[option].exec();
        } else if (option == -1) {
            Environment.Exit(0);
        } else {
            Console.WriteLine("Такая операция не найдена");
        }
    }
    public void ShowMenu() {
        Console.WriteLine(this.menu);
        Console.Write("Номер операции: ");
    }
    public void Clear() {
        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
        Console.ReadKey();
        Console.Clear();
    }
}

class EntryPoint
{
    static void Main()
    {
        Menu menu = new Menu();
        int option;
        while (true)
        {
            menu.ShowMenu();
            try {
                option = Convert.ToInt32(Console.ReadLine());
                menu.Process(option);
            }
            catch {
                Console.WriteLine("Пожалуйста, введите число");
            }
            menu.Clear();
        }
    }
}
