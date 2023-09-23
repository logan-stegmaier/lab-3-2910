using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder
{
    public class Menu
    {
        public static void MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("========= MAIN MENU =========");
            Console.ResetColor();
            Console.WriteLine("Choose of the following options:\n");
            Console.WriteLine($"a. Start Sequence for Pokemon\n");
            Console.WriteLine($"b. Start Sequence for BannedGames\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Any other button - Exit Program\n");
            Console.ResetColor();
        }

        public static void LoadCSV<T>(T obj)
        {
            Console.Clear();
            Console.WriteLine($"========= LOAD CSV COLLECTION | {typeof(T).Name} =========\n");

        }

        public static void LoadOwn()
        {
            Console.Clear();
            Console.WriteLine($"========= YOUR ADDED ITEMS =========\n");  
        }

        public static void ErasedRecords()
        {
            Console.Clear();
            Console.WriteLine($"========= ERASED RECORDS =========\n");
        }

    }
}
