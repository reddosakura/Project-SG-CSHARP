
using NEONOTE;

namespace NoteBook
{
    class NoteBook
    {
        private static int day_step = 0;
        private static DateTime date = DateTime.Now;
        private static List<List<string>> main_notes = new List<List<string>>();
        public static List<string> GetDiscriptionValues(List<List<string>> list, string value)
        {
            List<string> discriptions = new List<string>();
            foreach (var d in list)
            {
                if (d[0] == value)
                {
                    discriptions.Add(d[2]);
                }
            }

            return discriptions;
        }
        public static List<string> GetPreviewsValues(List<List<string>> list, string value)
        {
            List<string> previews = new List<string>();
            foreach (var l in list)
            {

                if (l[0] == value)
                {
            
                    previews.Add(l[1]);
                }
            }

            return previews;
        }

        static void Menu()
        {
            int coord = 4;

            // string currdate;


            while (true)
            {
                string selector = "";
                int border = 0;
                List<string> curr_preview_list = GetPreviewsValues(main_notes, date.AddDays(day_step).ToLongDateString());
                Console.WriteLine("Для добавления новой заметки нажмите tab для выхода из программы нажмите End");
                Console.WriteLine($"---------------------\n {date.AddDays(day_step).ToLongDateString()} \n---------------------");

                if ((curr_preview_list.Count > 0))
                {
                    foreach (var prvw in curr_preview_list)
                    {
                        Console.WriteLine($" [{prvw}]");
                    }

                    border = curr_preview_list.Count + 3;
                    selector = ">";

                }
                else
                {
                    Console.WriteLine("Нет заметок на данную дату");
                    border = 0;
                    selector = "";
                }
                Console.SetCursorPosition(0, coord);
                Console.WriteLine(selector);

                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (coord - 1 >= 4)
                    {
                        coord--;
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (coord + 1 <= border)
                    {
                        coord++;
                    }
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    day_step++;

                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    day_step--;

                }
                else if (key.Key == ConsoleKey.Tab)
                {
                    Console.Clear();
                    Console.WriteLine("Введите заголовок");
                    string preview = Console.ReadLine();
                    Console.WriteLine("Введите описание");
                    string discpription = Console.ReadLine();
                    Note note = new Note(date.AddDays(day_step), preview, discpription);
                    main_notes = note.AddNote(main_notes);

                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    if (curr_preview_list.Count > 0)
                    {
                        string dis = GetDiscriptionValues(main_notes, date.AddDays(day_step).ToLongDateString())[coord - 4];
                        Console.WriteLine($"Дата создания: {date.AddDays(day_step).ToLongDateString()}\n------------------------" +
                                          $"\nЗаголовок: {curr_preview_list[coord - 4]}" +
                                          $"\n------------------------\nОписание:\n{dis}\n------------------------");
                        ConsoleKeyInfo k = Console.ReadKey();
                    }
                }
                else if (key.Key == ConsoleKey.End)
                {
                    break;
                }

                Console.Clear();
            }

        }

        public static void Main() //
        {
            
            for (int i = 0; i <= 6; i++)
            {
                Note n = new Note(date.AddDays(i), $"Заметка #{i}", "Описание Описание Описание");
                main_notes = n.AddNote(main_notes);
            }
            Menu();
        }

    }
}
