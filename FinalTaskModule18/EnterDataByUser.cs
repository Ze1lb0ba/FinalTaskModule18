class EnterDataByUser
{

    public static List<string> URLSet()
    {
        List<string> list = new List<string>();
        bool resume = true;

        while (resume)
        {
            Console.WriteLine("");
            Console.WriteLine("Введите URL видео с которым будете работать, либо введите: 0 для перехода к следующему шагу.");
            Console.WriteLine("Сейчас в очереди {0} файла(-ов)", list.Count);
            Console.WriteLine("");
            string enter = Console.ReadLine();
            if (Int32.TryParse(enter, out int ent) && ent == 0)
            {
                resume = false;
            }
            else
            {
                list.Add(enter);
            }
        }
        
        return list;
    }

    public static int UserSelectInput()
    {
        Console.WriteLine("");
        Console.WriteLine("Выберите действие, введя число, где:");
        Console.WriteLine("1 - Показать описание к видео, 2 - Скачать видеоролик в память ПК, 3 - скачать только аудиодорожку из видео.");
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
                case 3:
                    return a;
                default:
                    Console.WriteLine("Вы ввели неверное число.");
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

    // Удаляет все недопустимые символы
    public static string RemoveInvalidChars(string input)
    {
        foreach (Char invalid_char in Path.GetInvalidFileNameChars())
        {
            input = input.Replace(oldValue: invalid_char.ToString(), newValue: "");
        }
        return input;
    }
}