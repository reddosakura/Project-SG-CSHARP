/* Программа калькулятор для выполнения математических операций.
 Принцип работы:
 - Пользователь вводит команду математической операции
 - Далее вводятся число(о) над которым(и) будет произведена выбранная математическая операция
 */

while (true) // пока истина. бесконечный цикл, далее сделано условие для выхода из него
{
    Console.WriteLine("\n------------------------------------\n" +
                      "Введите команду:" +
                      "\n1. Сложить 2 числа\n" +
                      "2. Вычесть первое из второго\n" +
                      "3. Перемножить два числа\n" +
                      "4. Разделить первое на второе\n" +
                      "5. Возвести в степень N первое число\n" +
                      "6. Найти квадратный корень из числа\n" +
                      "7. Найти 1 процент от числа\n" +
                      "8. Найти факториал из числа\n" +
                      "9. Выйти из программы" +
                      "\n------------------------------------\n");
    int command = Convert.ToInt32(Console.ReadLine());
    
    

    if (command == 1)
    {
        Console.WriteLine("Введите первое число");
        int num1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите второе число");
        int num2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("\n###################\n" +
                          $"Результат: {num1 + num2}" +
                          "\n###################\n"); // Вывод результата с
                                                       // использованием форматирования строки $

    }
    else if (command == 2)
    {    
        Console.WriteLine("Введите первое число");
        int num1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите второе число");
        int num2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("\n###################\n" +
                          $"Результат: {num1 - num2}" +
                          "\n###################\n"); 

    }
    else if (command == 3)
    {
        Console.WriteLine("Введите первое число");
        int num1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите второе число");
        int num2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("\n###################\n" +
                          $"Результат: {num1 * num2}" +
                          "\n###################\n");

    }
    else if (command == 4)
    {
        Console.WriteLine("Введите первое число");
        double num1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите второе число");
        double num2 = Convert.ToInt32(Console.ReadLine());
        if (num2 == 0) // исключение деления на ноль
        {
            Console.WriteLine("----------------------------\n" +
                              "Деление на ноль невозможно" +
                              "\n----------------------------");

        }
        else
        {
            Console.WriteLine("\n###################\n" +
                              $"Результат: {Math.Round(num1 / num2, 5)}" +
                              "\n###################\n"); // Math.Round использован для округления числа
                                                           // до пяти знаков после запятой
        }
    }
    else if (command == 5)
    {
        Console.WriteLine("Введите число");
        int num1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите целую степень N, в которую будет возведено число");
        int num2 = Convert.ToInt32(Console.ReadLine());
        int i = 0; // счетчик итерация
        int result = 1; // переменная результата
        do // цикл с постусловием
        {
            if (num2 < 0) // если введена отрицательная степень
            {
                i--; // декремент
                result *= num1;
            }
            else 
            {
                result *= num1;
                i++; // инкремент
            }
        } 
        while (i != num2); // пока количество итераций не будет равно введенной степени

        if (i < 0) // если была введена отрицательная степень, то счетчик итераций будет отрицательным
        {
            Console.WriteLine("\n###################\n" +
                              $"Результат: {(double)1 / result}" + // вывод результата для отрицательнйо степени
                              "\n###################\n"); // double использован для вывода вещественного результата
        }
        else
        {
            Console.WriteLine("\n###################\n" +
                              $"Результат: {result}" + // вывод для положительной
                              "\n###################\n");
        }

    }
    else if (command == 6)
    {
        Console.WriteLine("Введите число");
        int num1 = Convert.ToInt32(Console.ReadLine());
        if (num1 < 0)
        {
            Console.WriteLine("--------------------------------------------------------------\n" +
                              "Введено отрицательное число. Операция не может быть выполнена" +
                              "\n--------------------------------------------------------------");

        }
        else
        {
            Console.WriteLine("\n###################\n" +
                              $"Результат: {Math.Round(Math.Sqrt(num1), 5)}" +
                              "\n###################\n"); // метод извлечения квадратного корня и метод округления

        }
    }
    else if (command == 7)
    {
        Console.WriteLine("Введите число");
        int num1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("\n###################\n" +
                          $"Результат: {(double)num1 / 100}" + // вывод вещественного значения для процентов
                          "\n###################\n");
        // continue;
    }
    else if (command == 8)
    {
        Console.WriteLine("Введите число");
        int num1 = Convert.ToInt32(Console.ReadLine());
        
        int result = 1;
        for (int i = 1; i <= num1; i++) // цикл с преусловием. считает факториал
        {

            result *= i;
        }
        Console.WriteLine("\n###################\n" +
                          $"Результат: {result}" +
                          "\n###################\n");

    }
    else if (command == 9)
    {
        Console.WriteLine("---------------------------\n" +
                          "Программа завершила работу" +
                          "\n---------------------------");
        break; // операция выхода из цикла
    }
    else
    {
        Console.WriteLine("-----------------------------\n" +
                          "Введена некорректная команда" +
                          "\n-----------------------------");

    }
}


