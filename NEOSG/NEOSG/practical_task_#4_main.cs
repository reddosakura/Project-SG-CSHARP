using NEONOTE;
namespace NEOSG;


public class practical_task__4_main
{
    public static DateTime date_now = DateTime.Now;
    private static int day_step = 0;

    static void GetNoteInfo()
    {
        
    }
    static void Menu()
    {
        Console.WriteLine($"\n----------------\n {date_now.AddDays(day_step)} \n----------------\n");
    }
    static void Main()
    {
        // Note note = new Note();
    }
}