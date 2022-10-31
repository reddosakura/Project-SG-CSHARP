using OrderNames;
using MenuOptions;
using Microsoft.VisualBasic;

namespace Orders;

public class order_main
{
    private static List<string> temporary_order_list = new List<String>();
    private static int price = 0;

    static void Menu()
    {
        int coord = 3;

        List<string> first_options_list = new List<string>()
            { "Тессеракт - 500", "Гексагональная сигония - 673", "Усечённый октаэдр - 957" };
        List<string> second_options_list = new List<string>()
            { "Маленький - 10", "3 в степени числа π - 314", "Размером с небольшую планету - 8756" };
        
        List<string> third_options_list = new List<string>()
            { "Вкусный вкус - 1000", "Очень вкусный вкус - 1111", "Шоколадный - 8000" };
        
        List<string> fourth_options_list = new List<string>()
            { "Один - 10", "На один по-больше - 176", "Несколько - 856" };
        
        List<string> fifth_options_list = new List<string>()
            { "Какая-то глазурь №1 - 120", "Какая-то глазурь №2 - 454", "Какая-то глазурь №3 - 875" };
        
        List<string> sixth_options_list = new List<string>()
            { "Декор в стиле лофт - 103", "Декор в стиле барокко - 647", "Декор в стиле сталинского ампира - бесценно" };
        
        while (true)
        {
            Console.WriteLine("Заказ тортов\nСоздайте свой собственный торт\n=====================");
            Console.WriteLine("( ) Форма коржей\n( ) Размер\n( ) Вкус\n( ) Количество коржей\n( ) Глазурь\n( ) Декор\n");
            Console.WriteLine($"Цена заказа: {String.Join( ", ", temporary_order_list)}");
            Console.WriteLine($"Ваш заказ: {price}");
            Console.SetCursorPosition(1, coord);
            Console.WriteLine("@");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow)
            {
                if ((coord - 1) > 2)
                {
                    coord--;
                }
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                if (coord + 1 < 9)
                {
                    coord++;
                }
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                if (coord == 3)
                {
                    Console.Clear();
                    MenuOption first_menu = new MenuOption(first_options_list, "#", temporary_order_list);
                    first_menu.ShowMenu();
                    if (first_menu.op_coord == 0  && temporary_order_list.Count > 0)
                    {
                        price += 500;
                    }
                    else if (first_menu.op_coord == 1  && temporary_order_list.Count > 0)
                    {
                        price += 673;
                    }
                    else if (first_menu.op_coord == 2  && temporary_order_list.Count > 0)
                    {
                        price += 957;
                    }
                }
                else if (coord == 4)
                {
                    Console.Clear();
                    MenuOption second_menu = new MenuOption(second_options_list, "&", temporary_order_list);
                    second_menu.ShowMenu();
                    if (second_menu.op_coord == 0  && temporary_order_list.Count > 0)
                    {
                        price += 10;
                    }
                    else if (second_menu.op_coord == 1  && temporary_order_list.Count > 0)
                    {
                        price += 314;
                    }
                    else if (second_menu.op_coord == 2  && temporary_order_list.Count > 0)
                    {
                        price += 8756;
                    }
                }
                else if (coord == 5)
                {
                    Console.Clear();
                    MenuOption third_menu = new MenuOption(third_options_list, "$", temporary_order_list);
                    third_menu.ShowMenu();
                    if (third_menu.op_coord == 0  && temporary_order_list.Count > 0)
                    {
                        price += 1000;
                    }
                    else if (third_menu.op_coord == 1  && temporary_order_list.Count > 0)
                    {
                        price += 1111;
                    }
                    else if (third_menu.op_coord == 2  && temporary_order_list.Count > 0)
                    {
                        price += 8000;
                    }
                }
                else if (coord == 6)
                {
                    Console.Clear();
                    MenuOption fourth_menu = new MenuOption(fourth_options_list, "?", temporary_order_list);
                    fourth_menu.ShowMenu();
                    if (fourth_menu.op_coord == 0  && temporary_order_list.Count > 0)
                    {
                        price += 10;
                    }
                    else if (fourth_menu.op_coord == 1  && temporary_order_list.Count > 0)
                    {
                        price += 176;
                    }
                    else if (fourth_menu.op_coord == 2  && temporary_order_list.Count > 0)
                    {
                        price += 856;
                    }
                }
                else if (coord == 7)
                {
                    Console.Clear();
                    MenuOption fifth_menu = new MenuOption(fifth_options_list, "<", temporary_order_list);
                    fifth_menu.ShowMenu();
                    if (fifth_menu.op_coord == 0  && temporary_order_list.Count > 0)
                    {
                        price += 120;
                    }
                    else if (fifth_menu.op_coord == 1  && temporary_order_list.Count > 0)
                    {
                        price += 454;
                    }
                    else if (fifth_menu.op_coord == 2  && temporary_order_list.Count > 0)
                    {
                        price += 875;
                    }
                }
                else if (coord == 8)
                {
                    Console.Clear();
                    MenuOption sixth_menu = new MenuOption(sixth_options_list, "~", temporary_order_list);
                    sixth_menu.ShowMenu();
                    if (sixth_menu.op_coord == 0  && temporary_order_list.Count > 0)
                    {
                        price += 103;
                    }
                    else if (sixth_menu.op_coord == 1  && temporary_order_list.Count > 0)
                    {
                        price += 647;
                    }
                    else if (sixth_menu.op_coord == 2  && temporary_order_list.Count > 0)
                    {
                        price += 0;
                    }
                }
            }//
            else if (key.Key ==ConsoleKey.End)
            {
                Console.Clear();
                Tort total_cake = new Tort(temporary_order_list);
                string total_order = $"Заказ от {DateTime.Now.Date.ToLongDateString()}\nЗаказ: {String.Join("\n", temporary_order_list)}\nЦена заказа: {price}";
                total_cake.SaveOrderToFile(@"C:\Users\alexa\Desktop\История заказов.txt", total_order);
                // Console.WriteLine(total_order);
                Console.WriteLine("Спасибо за ваш заказ.");
                break;
            }
            Console.Clear();
        }
    }
    public static void Main()
    {
        Menu();
    }
}