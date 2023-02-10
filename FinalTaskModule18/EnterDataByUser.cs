class EnterDataByUser
{

    public static string URLSet()
    {
        Console.WriteLine("Введите URL видео с которым будете работать");
        Console.WriteLine("");
        return Console.ReadLine();
    }

    public static int UserSelectInput()
    {
        Console.WriteLine("");
        Console.WriteLine("Выберите действие, введя число, где:");
        Console.WriteLine("1 - Показать описание к видео, 2 - Скачать видеоролик в память ПК.");
        Console.WriteLine("");
        int i = UserSelectCheck(Console.ReadLine());
        return i;
    }
    public static int UserSelectCheck(string input)
    {
        if (Int32.TryParse(input, out int a))
        {
            switch (a)
            {
                case 1:
                    return a;
                case 2:
                    return a;
                default:
                    Console.WriteLine("Вы ввели неверное число");
                    UserSelectInput();
                    break;
            }
        }

        else
        {
            Console.WriteLine("Вы ввели не число!");
            UserSelectInput();
        }
        return 1;
    }
}