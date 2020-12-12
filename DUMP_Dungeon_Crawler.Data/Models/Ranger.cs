using DUMP_Dungeon_Crawler.Data.Enums;
using DUMP_Dungeon_Crawler.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DUMP_Dungeon_Crawler.Data.Models
{
    public class Ranger : Friendly
    {

        double CritChance { get; set; }

        double StunChance { get; set; }

        public Ranger(string playerName)
        {
            Name = playerName;
            HealthPoints = 125;
            HpLimit = 125;
            Damage = 23;
            Type = CharactersEnum.Ranger;
            CritChance = 0.25;
            StunChance = 0.25;
        }

        public override bool WonRound_CheckIfKilled(Enemy oponent)
        {
            if(RandomGeneratorClass.RandomCriticalChance(CritChance))
            {
                PrettyPrint.PrettyPrintMessage("Crit Attack!",ConsoleColor.DarkGreen);
                if (oponent.ReciveDamage(Damage * 2, this) == true)
                    return true;
                else
                    return false;
            }
            if (RandomGeneratorClass.RandomCriticalChance( StunChance))
            {
                PrettyPrint.PrettyPrintMessage("Stun Attack!!!",ConsoleColor.Red);
                if (oponent.ReciveDamage(Damage, this) == true)
                {
                    return true;
                }

                else
                {
                    PrettyPrint.PrettyPrintMessage("\nEnemy is Stunned! \nNext Round is guaranteed win!! \n", ConsoleColor.Yellow);
                    if (this.WonRound_CheckIfKilled(oponent) == true)
                    {
                        Console.WriteLine();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine();
                        return false;
                    }
                }
               
            }
            if (oponent.ReciveDamage(Damage, this) == true)
                return true;
            Console.WriteLine("Classic Attack\n");
            return false;
        }
        public override void LevelUp(int expirience)
        {
            Expirience += expirience;
            while (Expirience > XpLimit)
            {
                HpLimit = (int)(HpLimit * 1.2);
                HealthPoints = HpLimit;
                Expirience -= XpLimit;
                Level++;
                Damage = (int)((float)Damage * 1.3);
                XpLimit = (int)((float)XpLimit * 1.2);
                CritChance = CritChance * 1.2;
                StunChance = StunChance * 1.3;
                Console.WriteLine("\nLevel Up!");
                Console.WriteLine(Name + " is now level " + Level);
                Console.WriteLine($"\nCrit chance is now {(int) (CritChance * 100)}% , Stun Chance is now {(int) (StunChance * 100) / 2}%");
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}" +
                $"\nCrit Chance - {(int)(CritChance * 100)}%\n" +
                $"Stun Chance - {(int) (StunChance * 100) / 2}%";
        }
    }
}
