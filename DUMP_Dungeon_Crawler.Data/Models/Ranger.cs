using DUMP_Dungeon_Crawler.Data.Enums;
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
            HealthPoints = 150;
            HpLimit = 150;
            Damage = 29;
            Type = CharactersEnum.Ranger;
            CritChance = 0.3;
            StunChance = 0.25;
        }

        public override bool WonRound(Enemy oponent)
        {
            Random rnd = new Random();
            if(rnd.NextDouble() <= CritChance)
            {
                if (oponent.ReciveDamage(Damage * 2, this) == true)
                    return true;
                Console.WriteLine("Crit Attack!");
                return false;
            }
            if (rnd.NextDouble() <= StunChance)
            {
                Console.WriteLine("Stun Attack!!!");
                if (oponent.ReciveDamage(Damage, this) == true)
                    return true;
                else
                {
                    if (this.WonRound(oponent) == true)
                        return true;
                    else
                        return false;
                }
                    
            }
            if (oponent.ReciveDamage(Damage, this) == true)
                return true;
            Console.WriteLine("Classic Attack");
            return false;
        }
        public override void LevelUp(int expirience)
        {
            Expirience += expirience;
            while (Expirience > XpLimit)
            {
                Expirience -= XpLimit;
                Level++;
                Damage = (int)((float)Damage * 1.3);
                XpLimit = (int)((float)XpLimit * 1.2);
                CritChance = CritChance * 1.2;
                StunChance = StunChance * 1.3;
                Console.WriteLine("\nLevel Up!");
                Console.WriteLine(Name + " is now level " + Level);
                Console.WriteLine($"\nCrit chance is now {CritChance}, Stun Chance is now {StunChance}");
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}" +
                $"\nCrit Chance - {CritChance}\n" +
                $"Stun Chance - {StunChance}";
        }
    }
}
