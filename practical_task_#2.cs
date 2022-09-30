namespace names_
{
    class MersenneTwist // класс алгоритма генерации псевдослучайных чисел
    {
        static int w = 32;
        static int n = 624;
        static int m = 397;
        static int r = 31;
        static uint a = 0x9908B0DF;
        static int u = 11;
        static uint d = 0xFFFFFFFF;
        static int s = 7;
        static uint b = 0x9D2C5680;
        static int t = 15;
        static uint c = 0xEFC60000;
        static int l = 18;
        static int f = 1812433253;
        
        static List<int> nums = Enumerable.Range(1, n).Select(i => i * 0).ToList();
        static int index = n + 1;

        static uint lower_mask = 0x7FFFFFFF;
        static uint upper_mask = 0x80000000;
        // public static int bitmask_1 = Convert.ToInt32(Math.Pow(2, 8) - 1);
        // public static int bitmask_2 = Convert.ToInt32(Math.Pow(2, 8));
        // public static int bitmask_3 = Convert.ToInt32(Math.Pow(2, 8) - 1);

        static void mt_seed(int seed)
        {
            nums[0] = seed;
            for (int i = 1; i < n; i++)
            {
                int temp = f * (nums[i - 1] ^ (nums[i - 1] >> (w - 2))) + i;
                nums[i] = temp & 0xfffff;
            }
        }

        static long extract_number() // метод генерации псевдослучайных чисел
        {
            mt_seed(DateTime.Now.Millisecond * DateTime.Now.Minute * DateTime.Now.Hour);  // генерирование числа на основе произведения
                                                                                          // миллисекунд, минут и часов в момент выполенния программы
            if (index >= n)
            {
                twist();
                index = 0;
            }

            Int64 y = nums[index];
            y = y ^ ((y >> u) & d);
            y = y ^ ((y << s) & b);
            y = y ^ ((y << t) & c);
            y = y ^ (y >> l);
            return (y & 0xffffffff);
        }
        static void twist()
        {
            for (int i = 0; i < n; i++)
            {
                Int64 x = (nums[i] & Convert.ToInt64(upper_mask)) + (nums[(i + 1) % n] & Convert.ToInt64(lower_mask));
                Int64 xA = x >> 1;
                if ((x % 2) != 0)
                {
                    xA ^= a;
                }

                nums[i] = nums[(i + m) % n] ^ (int)xA;
            }
        }

        public static int randomint(int x, int y)
            /*Метод для случайного выбора случайного числа. Базируется на основе алгоритма генерации
             псевдослучайных чисел"Вихрь Мерсенна" 
             */
        {
            double coeff = (double)extract_number() / 4294967296;
            double fa = y - x + x;
            double sa = 1 / fa;
            return Convert.ToInt32(Math.Round(coeff / sa));
            
        }
        //
        // public static void Main()
        // {
        //     Console.WriteLine(randint(1, 90));
        // }
    }

    class MainProgramm
    {
        static void RandoMizer()
        {
            Console.WriteLine("\n--------------\n" +
                              "Введите число:" + 
                              "\n--------------\n");
            int num;
            int rand_int = MersenneTwist.randomint(0, 100);
            while (true)
            {
                num = Convert.ToInt32(Console.ReadLine());
                if (num > rand_int)
                {
                    Console.WriteLine("\n-----------------------\n" +
                                      "Загаданное число меньше" + 
                                      "\n-----------------------\n");
                }
                else if (num < rand_int)
                {
                    Console.WriteLine("\n-----------------------\n" +
                                      "Загаданное число больше" + 
                                      "\n-----------------------\n");
                }
                else
                {
                    Console.WriteLine("\n-----------------------------\n" +
                                      "Вы отгадали загаданное число !" + 
                                      "\n-----------------------------\n");
                    break;
                }
            }
        }

        static void MultiplicationTable()
        {
            int rows = 10;
            int cols = 10;
            int[,] mass = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    mass[i, j] = (i + 1) * (j + 1);

                }
            }

            for (int k = 0; k < mass.GetLength(0); k++)
            {
                Console.Write(Convert.ToString(k + 1) + "\t");
                for (int l = 0; l < mass.GetLength(1); l++)
                {
                    Console.Write($"|{k+1} * {l + 1} = " + mass[k, l] + "|" + "\t");
                }
                Console.WriteLine();
            }
        }
        //
            // int tmp;
            // for (int i = 0; i < 9; i++)
            // {
            //     for (int j = 0; j < 9; j++)
            //     {
            //         tmp = mass[i, j];
            //         mass[i, j] = mass[j, i];
            //         mass[j, i] = tmp;
            //     }
            // }
            

            static void Divisors()
        {
            while (true)
            {
                Console.WriteLine("\n-----------------------------------------------\n" +
                                  "Введите число. Для выхода из программы введите 0" + 
                                  "\n-----------------------------------------------\n");
                int num = Convert.ToInt32(Console.ReadLine());
                List<int> num_mass = new List<int>() { };
                
                if (num == 0)
                {
                    Console.WriteLine("\n-------------------\n" +
                                      "Выход из инструмента" + 
                                      "\n-------------------\n");
                    break;
                }
                else
                {
                    for (int i = 1; i <= num; i++)
                    {
                        if ((num % i) == 0)
                        {
                            num_mass.Add(i);
                        }
                    }

                    foreach (int elem in num_mass)
                    {
                        Console.Write(elem);
                    }
                }

            }
        }
        static void Menu()
        {
            // string[,] cuimenu = new [3, 7]{{"#", "#", "#", "#", "#", "#", "#" }, 
            //     {"################", "1", "5", "3", "#", "#", "#"}, {"#", "#", "#", "#", "#", "#", "#"}};
            while (true)
            {
                Console.WriteLine("\n------------------------------------\n" +
                                  "Введите номер команды:" +
                                  "\n1. Игра Угадай число\n" +
                                  "2. Таблица умножения\n" +
                                  "3. Вывод делителей числа\n" +
                                  "4. Выход из программы\n" +
                                  "\n------------------------------------\n");
                int command = Convert.ToInt32(Console.ReadLine());
                if (command == 1)
                {
                    RandoMizer();
                }
                else if (command == 2)
                {
                    MultiplicationTable();
                }
                else if (command == 3)
                {
                    Divisors();
                }
                else if (command == 4)
                {
                    Console.WriteLine("\n------------------\n" +
                                      "Выход из программы" + 
                                      "\n------------------\n");
                    break;
                }
                else
                {
                    Console.WriteLine("\n#########\n" +
                                      " Ошибка !  " + 
                                      "\n#########\n");
                }
            }

        }
        static void Main()
        {

            Menu();
        }
    }
}
