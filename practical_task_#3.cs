
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
                if (mass[i, 2] == sym)
                {
                    return true;
                }
            }
            return false;
        }

        static void PlayPianos()
        {
            
        }

        static void Notes()
        {
            Console.Clear();
            
            int current_coord = 1;
            
            while (true)
            {
                Console.WriteLine("Выберите таблицу:\n[ ] Таблица частот звучаний нот в Гц\n[ ] Обозначение нот\n[ ] Назад");
                Console.SetCursorPosition(1, current_coord);
                Console.WriteLine("#");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (current_coord - 1 >= 1)
                    {
                        current_coord--;
                    }
                }
                
                else if (key.Key ==ConsoleKey.DownArrow)
                {
                    if (current_coord + 1 <= 3)
                    {
                        current_coord++;
                    }    
                }
                
                if (key.Key == ConsoleKey.Enter)
                {
                    if (current_coord == 1)
                    {
                        Console.WriteLine("1");
                    }
                    else if (current_coord == 2)
                    {
                        Console.WriteLine("2");
                    }
                    else if (current_coord == 3)
                    {
                        break;
                    }
                }
                Console.Clear();
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
        
        static string[,] matrix = new string[12, 3] { { "[ ] C"," - ", "A" }, { "[ ] C#", " - ", "W" }, { "[ ] D", " - ", "E" }, {"[ ] Eb", " - ", "F"}, {"[ ] E", " - ", "V"}, 
            {"[ ] F", " - ", "B"}, {"[ ] F#", " - ", "N"}, {"[ ] G", " - ", "M"}, {"[ ] G#", " - ", "K", }, {"[ ] A", " - ", "O"}, {"[ ] Bb", " - ", "P"}, {"[ ] B", " - ", "Oem7"}};
        // static string[,] copy = CopyStringMatrix(matrix);

        static void Control()
        {
            Console.Clear();
            Console.WriteLine("Для перехода в режим редактирования нажмите сочетание CTRL+Y. Для выхода нажмите любую кнопку");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
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
            // ConsoleKeyInfo key = Console.ReadKey();

           while (true)
           {
               Console.WriteLine(message);
               for (int i = 0; i < matrix.GetLength(0); i++)
               {
                   for (int j = 0; j < matrix.GetLength(1); j++)
                   {
                       Console.Write(matrix[i, j]);
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
                               matrix[current_coord - 1, 2] = Convert.ToString(nkey.Key);
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
                Console.WriteLine("[ ] - Играть\n[ ] - Управление\n[ ] - Ноты\n[ ] - Выход");
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
                    if ((current_coord + 1) <= 6)
                    {
                        current_coord++;
                    }
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    // Console.SetCursorPosition(0, 7);
                    if (current_coord == 3)
                    {
                         
                        Console.WriteLine("menu_option_1");
                    }
                    else if (current_coord == 4)
                    {
                        Control();
                        Console.WriteLine("menu_option_2");
                    }
                    else if (current_coord == 5)
                    {
                        Notes();
                        Console.WriteLine("menu_option_3");
                    }
                    else if (current_coord == 6)
                    {
                        Console.WriteLine("exit_option");
                        break;
                    }
                }
                Console.Clear();
            }
        }

        public static void Main()
        {
            // print();
            // Control();
            CuiMenu();
        }
    }
}
// Console.Beep(130 * (int)Math.Pow(2, 4), 400);
