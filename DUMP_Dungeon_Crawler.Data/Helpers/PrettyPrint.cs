using DUMP_Dungeon_Crawler.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DUMP_Dungeon_Crawler.Data.Helpers
{
    public class PrettyPrint
    {
        public static void PrettyPrintMessage(string message, ConsoleColor collour)
        {
            Console.ForegroundColor = collour;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void PrettyPrintStartScreen()
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n ================================");
            Console.WriteLine(" -= Welcome to Dungeon Crawler =-");
            Console.WriteLine(" ================================");
            Console.ResetColor();
        }
        public static void PrettyPrintRoundStatus(Friendly user, Enemy oponent)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=========================");
            Console.WriteLine(user);
            Console.WriteLine("=========================");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=========================");
            Console.WriteLine(oponent);
            Console.WriteLine("=========================");
            Console.ResetColor();
        }
        public static void PrettyPrintFightActionStatus(string userDecision, string oponentDecision,Friendly userHero, Enemy oponent)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{userHero.Name} - has sellected - {userDecision} \n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{oponent.Name} - has sellected - {oponentDecision}");

            Console.ResetColor();
        }
        public static void PressAnyKeyToContinue()
        {
            Console.WriteLine("\nPress Any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public static void PrettyPrintLevelUp(Friendly userHero, Enemy oponent)
        {
            PressAnyKeyToContinue();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You Won!");
            Console.WriteLine("Recived +" + oponent.ExpirienceWorth + " Xp");
            Console.WriteLine(userHero);
            Console.ResetColor();
        }

        public static void PrintEnemyList(List<Enemy> OponentsList)
        {
            foreach (var enemy in OponentsList)
            {
                PrettyPrint.PrettyPrintCharracter(enemy);
            }
        }
        public static void PrettyPrintCharracter(Character charracter)
        {
            if (charracter.Type == Data.Enums.CharactersEnum.Goblin)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("================================================");
                Console.WriteLine(charracter);
                Console.WriteLine("================================================");
                Console.ResetColor();
            }
            else if (charracter.Type == Data.Enums.CharactersEnum.Brute)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("================================================");
                Console.WriteLine(charracter);
                Console.WriteLine("================================================");
                Console.ResetColor();
            }
            else if (charracter.Type == Data.Enums.CharactersEnum.Witch)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("================================================");
                Console.WriteLine(charracter);
                Console.WriteLine("================================================");
                Console.ResetColor();
            }
            else if (charracter is Friendly)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("================================================");
                Console.WriteLine(charracter);
                Console.WriteLine("================================================");
                Console.ResetColor();
            }
        }
    }
}
