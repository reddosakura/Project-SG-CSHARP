namespace MenuOptions;

public class MenuOption
{
    private List<string> options;
    private string selector;
    private List<string> order_list = new List<string>();
    public int op_coord = 0;

    public MenuOption(List<string> _options, string _selector, List<string> _order_list)
    {
        options = _options;
        selector = _selector;
        order_list = _order_list;
    }
//
    public void ShowMenu()
    {
        while (true)
        {
            // Console.WriteLine($"( ){String.Join("\n", options)}");
            foreach (var op in options)
            {
                Console.WriteLine($"( ) {op}");
            }
            Console.WriteLine("Выберите пункт меню и нажмите Enter. Для выхода нажмите End.");
            Console.SetCursorPosition(1, op_coord);
            Console.WriteLine(selector);
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow)
            {
                if (op_coord - 1 >= 0)
                {
                    op_coord--;
                }
            }
            else if (key.Key ==ConsoleKey.DownArrow)
            {
                if (op_coord + 1 < 3)
                {
                    op_coord++;
                }
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                order_list.Add(options[op_coord]);
                // op_coord = 0;
                break;
            }
            else if (key.Key == ConsoleKey.End)
            {
                // op_coord = 0;
                break;
            }
            Console.Clear();
        }
    }
}