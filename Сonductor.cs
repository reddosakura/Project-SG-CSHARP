using System.Globalization;
using Arrows;
namespace Arrows;

public static class RepeatSomeValue
{
    public static string Repeat(this string value, int count) => string.Concat(Enumerable.Repeat(value, count));
}

public class Сonductor
{
    public static void ShowDirConstent(string path)
    {
        Console.Clear();
        // List<List<string>> table = new List<List<string>>();
        string[] allDirectories = Directory.GetDirectories(path);
        string[] allFiles = Directory.GetFiles(path);
        
        
        foreach (var dir in allDirectories)
        {
            // List<string> dirinfo = new List<string>();
            var creation_date = Directory.GetCreationTime(dir).ToString();
            var name = new DirectoryInfo(dir).Name;
            try
            {
                var str = $"|- Количество фалов внутри: {Directory.GetFiles(dir).Length}";
                Console.WriteLine($"( ) Имя папки: {name}\n" +
                                  $"   |- Дата создания: {creation_date}\n" +
                                  $"   |- Количество файлов внутри: {Directory.GetFiles(dir).Length}\n   {"-".Repeat(str.Length + 2)}");
            }
            catch (System.UnauthorizedAccessException)
            {
                Console.WriteLine($"( ) Папка: {name}\n" +
                                  $"   |- Дата создания: {creation_date}\n" +
                                  $"   |- Невозможно получить информацию о файлах внутри директории\n" +
                                  $"   {"-".Repeat("|- Невозможно получить информацию о файлах внутри директории".Length)}");
                // throw;
            }
        }

        foreach (var f in allFiles)
        {
            // List<string> fileinfo = new List<string>();
            var ext = Path.GetExtension(f);
            var name = Path.GetFileName(f);
            var namewithoutext = name.Split(".");
            var creation_date = File.GetCreationTime(f).ToString();
            Console.WriteLine($"( ) Имя файла: {namewithoutext[0]}\n" +
                              $"   |- Расширение файла: {ext}\n" +
                              $"   |- Дата создания: {creation_date}\n" +
                              $"   {"-".Repeat($"|- Дата создания: {creation_date}".Length)}");
            
        }
    }
    public static void init()
    {
        Arrows arr = new Arrows(0, 15);
        arr.ShowArrow(0, 4, "~");
        // ConsoleKeyInfo k = Console.ReadKey();
        // if (k.Key == ConsoleKey.Enter)
        // {
            // Console.Clear();
            // k = Console.ReadKey();
            // Console.WriteLine("1111111111111111111");
        // }
        // DriveInfo[] allDrives = DriveInfo.GetDrives();
        // // Console.WriteLine(allDrives.Length);
        //
        // foreach (DriveInfo d in allDrives)
        // {
        //     Console.Write("( ) Диск {0}", d.Name);
        //     // Console.WriteLine(" Drive type: {0}", d.DriveType);
        //     if (d.IsReady)
        //     {
        //         string msg1 = $"  |- Файловая система: {d.DriveFormat}";
        //         string msg2 = $"  |- Общий объем: {Math.Round(d.TotalSize / Math.Pow(2, 30), 2)} Gb";
        //         string msg3 = $"  |- Объем свободного места: {Math.Round(d.TotalFreeSpace / Math.Pow(2, 30), 2)} Gb";
        //         Console.WriteLine($"\n{msg1}\n{msg2}\n{msg3}\n  {"-".Repeat(msg3.Length)}");
        //     }
        // }
    }
    public static void Main()
    {
        // ShowDirConstent(@"C:\");
        init();
        // DriveInfo[] allDrives = DriveInfo.GetDrives();
        // string[] allDirectories = Directory.GetDirectories(allDrives[0].Name);

        // // Console.WriteLine();
        // foreach (var d in allDirectories)
        // {
        //     // Console.WriteLine(Path.GetDirectoryName(d));
        // }
        //
        // foreach (var f in allFiles)
        // {
        //     // Console.Write(Path.GetExtension(Path.));
        //     Console.WriteLine($"{f}{Path.GetFileName(f)}{Path.GetExtension(f)}");
        // }
    }
}