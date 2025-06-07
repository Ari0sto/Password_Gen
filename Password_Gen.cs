using System;


/// <summary>
/// Класс содержит логику генерации пароля с учетом пользовательских настроек.
/// </summary>
class Password
{
    /// <summary>
    /// Entry point of the application. Generates a random password based on user-specified criteria,  including length
    /// and excluded characters.
    /// </summary>
    static void Main()
    {
        PasswordGeneration();
    }

    /// <summary>
    /// Генерирует случайный пароль на основе указанных пользователем критериев,
    /// включая длину и исключенные символы.
    /// </summary>
    static void PasswordGeneration()
    {
        /// <summary>
        /// Длина пароля по умолчанию.
        /// </summary>
        const int defaultLenght = 15;

        /// <summary>
        ///  Все возможные символы для генерации пароля.
        /// </summary>
        string allSymbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_=+[]{};:,.<>?/";

        Console.WriteLine("Вы хотите использовать длину по умолчанию (15)? (да/нет):");
        string useDefault = Console.ReadLine();

        int minLength, maxLength;

        if (useDefault == "да")
        {
            // Если выбрана длина по умолчанию
            minLength = maxLength = defaultLenght;
        }

        else
        {
            // Ввод минимальной и максимальной длины пароля
            Console.WriteLine("Введите минимальную длину пароля:");
            minLength = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите максимальную длину пароля:");
            maxLength = int.Parse(Console.ReadLine());

            // Проверка на корректность диапазона длины.
            if (minLength > maxLength)
            {
                Console.WriteLine("Минимальная длина не может быть больше максимальной");
                return;
            }
        }

        // Ввод символов которые будут исключены (без пробелов)
        Console.WriteLine("Введите символы, которые нужно исключить (в одну строчку, без пробелов):");
        string excluded = Console.ReadLine();

        string allowed_Symbols = "";

        /// <summary>
        /// Удаляем исключенные символы
        /// </summary>
        for (int i = 0; i < allSymbols.Length; i++)
        {
            char current_char = allSymbols[i];
            bool is_excluded = false;

            for (int j = 0; j < excluded.Length; j++)
            {
                if (current_char == excluded[j])
                {
                    is_excluded = true;
                    break;
                }
            }

            if (!is_excluded)
            {
                allowed_Symbols += current_char;
            }
        }

        // Проверка на случай, если все символы были исключены.
        if (allowed_Symbols.Length == 0)
        {
            Console.WriteLine("Вы исключили все возможные символы. Попробуйте снова.");
            return;
        }

        Random rand = new Random();

        /// <summary>
        /// Определяем случайную длину пароля в указанном диапазоне.
        /// </summary>
        int passwordLength = rand.Next(minLength, maxLength + 1);

        string password = "";

        /// <summary>
        /// Генерация пароля из разрешённых символов.
        /// </summary>
        for (int i = 0; i < passwordLength; i++)
        {
            int index = rand.Next(allowed_Symbols.Length);
            password += allowed_Symbols[index];
        }

        // Вывод результата в консоль 
        Console.Write("Сгенерированный пароль: ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(password);
        Console.ResetColor();
    }
}

        

    



    

