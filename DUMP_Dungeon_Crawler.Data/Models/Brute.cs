using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using DUMP_Dungeon_Crawler.Data.Helpers;
using DUMP_Dungeon_Crawler.Domain.Helpers;

namespace DUMP_Dungeon_Crawler.Data.Models
{
    public class Brute : Enemy
    {
        public double CritticalChance { get; set; }

        public double CritticalDamagePercentage { get; set; } = 0.15;
        public Brute(double multiplyer)
        {
            {
                HealthPoints = (int)((double)55 * multiplyer);
                HpLimit = HealthPoints;
                Damage = (int)((double)20 * multiplyer);
                Name = "Brute";
                ExpirienceWorth = (int)((double)45 * multiplyer);
                Type = Enums.CharactersEnum.Brute;
                GeneratePossibilty = 0.3f;
                CritticalChance = 0.25;
            }
        }

        public override void Attack(Friendly user)
        {
            int modifiedDamage = (int)(user.HealthPoints * CritticalDamagePercentage);
            if (RandomGeneratorClass.RandomCriticalChance(CritticalChance))
            {
                Console.WriteLine("\n"+ Name + " has Crittical Damage!");
                user.ReciveDamage(modifiedDamage);
            }
            else
                user.ReciveDamage(Damage);
        }
        public override string ToString()
        {
            return $"{base.ToString()}" +
                $"\nCrittical Chance - {CritticalDamagePercentage * 100}%";
        }
    }
}
