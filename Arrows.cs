namespace Arrows;

public class Arrows
{
    public static int max;
    public static int min;
    public Arrows(int _min, int _max)
    {
        max = _max;
        min = _min;
    }

    public void ShowArrow(int mincoord, int step, string selector)
    {
        int coord = mincoord;
        while (true)
        {
            
            Console.SetCursorPosition(1, coord);
            Console.WriteLine(selector);
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow)
            {
                if (coord - step >= min)
                {
                    Console.SetCursorPosition(1, coord);
                    Console.WriteLine(" ");
                    coord -= step;
                    // Console.SetCursorPosition(1, coord);
                    // Console.WriteLine("~");
                    // continue;
                }
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                if (coord + step < max)
                {
                    Console.SetCursorPosition(1, coord);
                    Console.WriteLine(" ");
                    coord += step;
                    // Console.SetCursorPosition(1, coord);
                    // Console.WriteLine("~");
                    // continue;
                }
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                // Console.WriteLine(content);
            }
            // else if (key.Key == ConsoleKey.Escape)
            // {
            //     Console.Clear();
            //     Console.WriteLine("Выход из программы");
            //     break;
            // }
        }
    }
}