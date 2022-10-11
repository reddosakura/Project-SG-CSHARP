
using System.Collections.ObjectModel;
using System.ComponentModel.Design;

namespace Pianinos_
{
    class Pianinos
    {
        public static bool IsSymAlreadyIn(string[,] mass, string sym)
        {
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                if (mass[i, 1] == sym)
                {
                    return true;
                }
            }
            return false;
        }

        public static string GetValue(string[,] matrix, string key)
        {
            // string value = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                // Console.WriteLine(matrix[i, 0]);
                if (matrix[i, 1] == key)
                {
                    // Console.WriteLine(matrix[i, 0]);
                    return matrix[i, 0];
                }
            }
            return "none";
        }

        static void PlayPianos()
        {
            Console.Clear();
            string[,] notes = new string[12, 2]
            {
                { "130", "C" }, { "139", "C#" }, { "147", "D" },
                { "156", "Eb" }, { "165", "E" }, { "175", "F" },
                { "185", "F#" }, { "196", "G" }, { "208", "G#" },
                { "220", "A" }, { "233", "Bb" }, { "247", "B" }
            };

            int[] octaves = new[] { 1, 2, 4, 8, 16, 32, 64, 128 };
            // Console.WriteLine(GetValue(notes, GetValue(matrix, "Oem7")));
            int currentOctave = 0;
            Console.WriteLine("Игра в пианино. Для переключения октав используйте клавиши F1-F8. Для выхода нажмите Delete");
            while (true)
            {
                
                ConsoleKeyInfo key = Console.ReadKey();
                
                if (key.Key == ConsoleKey.F1)
                {
                    currentOctave = 0;
                }
                else if (key.Key == ConsoleKey.F2)
                {
                    currentOctave = 1;
                }
                else if (key.Key == ConsoleKey.F3)
                {
                    currentOctave = 2;
                }
                else if (key.Key == ConsoleKey.F4)
                {
                    currentOctave = 3;
                }
                else if (key.Key == ConsoleKey.F5)
                {
                    currentOctave = 4;
                }
                else if (key.Key == ConsoleKey.F6)
                {
                    currentOctave = 5;
                }
                else if (key.Key == ConsoleKey.F7)
                {
                    currentOctave = 6;
                }
                else if (key.Key == ConsoleKey.F8)
                {
                    currentOctave = 7;
                }
                else if (GetValue(matrix, Convert.ToString(key.Key)) != "none")
                {
                    Console.Clear();
                    Console.WriteLine(GetValue(matrix, Convert.ToString(key.Key)) + $" Текущая октава: {currentOctave}");
                    Console.Beep(Convert.ToInt32(GetValue(notes, GetValue(matrix, Convert.ToString(key.Key)))) * octaves[currentOctave], 450);
                }
                else if (key.Key == ConsoleKey.Delete)
                {
                    break;
                }
                
                
            }
            
        }

        // public static string[,] CopyStringMatrix(string[,] matrix)
        // {
        //     string[,] copied = new string[matrix.GetLength(0), matrix.GetLength(1)];
        //     // List<string>
        //     for (int i = 0; i < matrix.GetLength(0); i++)
        //     {
        //         for (int j = 0; j < matrix.GetLength(1); j++)
        //         {
        //             copied[i, j] = new string(matrix[i, j]);
        //         }
        //     }
        //     
        //     return copied;
        // }
        
        static string[,] matrix = new string[12, 2] { { "C","A" }, { "C#", "W" }, { "D", "E" }, {"Eb", "F"}, {"E", "V"}, 
            {"F", "B"}, {"F#", "N"}, {"G", "M"}, {"G#", "K", }, {"A", "O"}, {"Bb", "P"}, {"B", "Oem7"}};
        
        // static string[,] matrix = new string[12, 3] { { "[ ] C"," - ", "A" }, { "[ ] C#", " - ", "W" }, { "[ ] D", " - ", "E" }, {"[ ] Eb", " - ", "F"}, {"[ ] E", " - ", "V"}, 
        //     {"[ ] F", " - ", "B"}, {"[ ] F#", " - ", "N"}, {"[ ] G", " - ", "M"}, {"[ ] G#", " - ", "K", }, {"[ ] A", " - ", "O"}, {"[ ] Bb", " - ", "P"}, {"[ ] B", " - ", "Oem7"}};
        // // static string[,] copy = CopyStringMatrix(matrix);

        static void Control()
        {
            Console.Clear();
            Console.WriteLine("Для перехода в режим редактирования нажмите сочетание CTRL+Y. Для выхода нажмите любую кнопку");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
        
                    Console.Write(($" -- [{matrix[i, j]}]"));
                }
                Console.WriteLine();
            }
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Modifiers.HasFlag(ConsoleModifiers.Control) && key.Key == ConsoleKey.Y)
            {
                Console.Clear();
                ChangeControlMode();
            }
        }
        
        static void ChangeControlMode()
        {
            string selector = ">";
            int current_coord = 1;
            string message =
                "Выберите клавишу которую хотите поменять с помощью стрелок, нажмите Enter и введите новое значение";


           while (true)
           {
               Console.WriteLine(message);
               for (int i = 0; i < matrix.GetLength(0); i++)
               {
                   Console.Write("[ ]");
                   for (int j = 0; j < matrix.GetLength(1); j++)
                   {
        
                       Console.Write($" - [{matrix[i, j]}]");
                   }
                   Console.WriteLine();
               }
               Console.WriteLine("[ ] Выход");
               Console.SetCursorPosition(1, current_coord);
               Console.WriteLine(selector);
               ConsoleKeyInfo key = Console.ReadKey();
               if (key.Key == ConsoleKey.UpArrow)
               {
                   if (current_coord - 1 >= 1)
                   {
                       selector = ">";
                       current_coord--;
                   }
               }
               else if (key.Key == ConsoleKey.DownArrow)
               {
                   if (current_coord + 1 <= matrix.GetLength(0) + 1)
                   {
                       selector = ">";
                       current_coord++;
                   }
               }
               // else if (key.Key == ConsoleKey.Backspace)
               // {
               //     matrix = copy;
               // }
               if (key.Key == ConsoleKey.Enter)
               {
                   selector = "$";
                   if (current_coord != matrix.GetLength(0) + 1)
                   {
                       
                       ConsoleKeyInfo nkey = Console.ReadKey();
                       if (nkey.Key == ConsoleKey.UpArrow)
                       {
                           message = "Стрелки не могут быть использованы в управлении";
                       }
                       else if (nkey.Key == ConsoleKey.DownArrow)
                       {
                           message = "Стрелки не могут быть использованы в управлении";
                       }
                       else if (nkey.Key == ConsoleKey.Enter)
                       {
                           message = "Enter не может быть использован как клавиша пианино";
                       }
                       else
                       {
                           if (IsSymAlreadyIn(matrix, Convert.ToString(nkey.Key)))
                           {
                               message = "Введенная клавиша уже используется, повторите операцию";
                               selector = ">";
                           }
                           else
                           {
                               message =
                                   "Выберите клавишу которую хотите поменять с помощью стрелок, нажмите Enter и введите новое значение";
                               matrix[current_coord - 1, 1] = Convert.ToString(nkey.Key);
                           }
                       }
                   }
                   else
                   {
                       Console.WriteLine("menu_option_exit");
                       break;
                   }
               }
               Console.Clear();
           }
        }
        
        static void CuiMenu()
        {
            int current_coord = 3;

            while (true)
            {

                Console.WriteLine("----------\n" +
                                  "===Меню===" +
                                  "\n----------");
                Console.WriteLine("[ ] - Играть\n[ ] - Управление\n[ ] - Выход");
                Console.SetCursorPosition(1, current_coord);
                Console.WriteLine("#");
                ConsoleKeyInfo key = Console.ReadKey();
                // key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (current_coord - 1 >= 3)
                    {
                        current_coord--;
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if ((current_coord + 1) <= 5)
                    {
                        current_coord++;
                    }
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    // Console.SetCursorPosition(0, 7);
                    if (current_coord == 3)
                    {
                        PlayPianos();
                        Console.WriteLine("menu_option_1");
                    }
                    else if (current_coord == 4)
                    {
                        Control();
                        Console.WriteLine("menu_option_2");
                    }
                    else if (current_coord == 5)
                    {
                        Console.WriteLine("\n------------------\nВыход из программы\n------------------\n");
                        break;
                    }
                }
                Console.Clear();
            }
        }

        public static void Main()
        {

            CuiMenu();

        }
    }
}
