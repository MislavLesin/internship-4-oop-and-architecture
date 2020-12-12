using System;
using System.Collections.Generic;
using System.Text;
using DUMP_Dungeon_Crawler.Data.Helpers;
namespace DUMP_Dungeon_Crawler.Data.Models
{
    public class Witch : Enemy
    {
        public int DjumbusMinHp { get; set; } = 10;

        public int DjumbusMaxHp { get; set; } = 230;
        public double DjumbusChance { get; set; }
        public Witch(double multiplyer)
        {
            {
                HealthPoints = (int)((double)95 * multiplyer);
                HpLimit = HealthPoints;
                Damage = (int)((double)30 * multiplyer);
                Name = "Witch";
                ExpirienceWorth = (int)((double)65 * multiplyer);
                Type = Enums.CharactersEnum.Witch;
                GeneratePossibilty = 0.1f;
                DjumbusChance = 0.35f;
            }
        }
        public override void Attack(Friendly userHero)
        {
            if (RandomGeneratorClass.RandomCriticalChance( DjumbusChance))
                Djumbus(userHero, RandomGeneratorClass.WitchDjumbusHp(DjumbusMinHp, DjumbusMaxHp));
            else
            {
                userHero.ReciveDamage(Damage);
                Console.WriteLine("Witch attacking standardly");
            }
        }
        public override void IsKilledBy(Friendly userHero)
        {
            userHero.EnemyKilled(this);
            EnemiesList.Remove(this);
            WitchScream();
            RandomGeneratorClass.RandomEnemyInitializationToEnemieList();
            RandomGeneratorClass.RandomEnemyInitializationToEnemieList();

        }

        public void WitchScream()
        {
            PrettyPrint.PrettyPrintMessage("The witch has been killed!!\n2 new monsters Spawned!", ConsoleColor.Red);
            PrettyPrint.PrintEnemyList(EnemiesList);
        }

        public void Djumbus( Friendly userHero, int hpToSet)
        {
            userHero.HealthPoints = hpToSet;
            foreach (var monster in EnemiesList)
                monster.HealthPoints = hpToSet;
            PrettyPrint.PrettyPrintMessage("Djumbus hahahahahhahahhahahaahah \nAll Charracters have " + hpToSet +
                " Hp", ConsoleColor.DarkMagenta);
        }
        public override string ToString()
        {
            return $"{base.ToString()}" +
                $"\nDjumbus Chance - {DjumbusChance * 100}%";
        }
    }
}
