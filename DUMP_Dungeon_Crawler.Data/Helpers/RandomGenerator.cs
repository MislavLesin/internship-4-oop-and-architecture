using DUMP_Dungeon_Crawler.Data.Models;
using DUMP_Dungeon_Crawler.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DUMP_Dungeon_Crawler.Data.Helpers
{
    public static class RandomGeneratorClass
    {
        public static int WitchDjumbusHp(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }
        public static void RandomEnemyInitializationToEnemieList()
        {
            var heroMultiplyer = RandomGeneratorClass.EnemyHpAndDamageMultiplayer();
            var type = RandomGeneratorClass.GetRandomEnemyType();
            if (type == (int)CharactersEnum.Goblin)
            {
                var goblin = new Goblin(heroMultiplyer); 

            }
            else if (type == (int)CharactersEnum.Brute)
            {
                var brute = new Brute(heroMultiplyer);

            }
            else if (type == (int)CharactersEnum.Witch)
            {
                var witch = new Witch(heroMultiplyer);

            }
            else
                Console.WriteLine("Error while iniatlizing enemy");
        }
        public static bool RandomCriticalChance(double characterCritChance)
        {
            Random rnd = new Random();
            var value = rnd.NextDouble();
            if (characterCritChance <= value)
                return true;
            return false;
        }
        public static int GetRandomEnemyType()
        {
          
            Random rnd = new Random();
            var value = rnd.NextDouble();
            if (value <= 0.6)
                return (int)CharactersEnum.Goblin;
            else if (value <= 0.9)
                return (int)CharactersEnum.Brute;
            else
                return (int)CharactersEnum.Witch;
            
        }
        public static double EnemyHpAndDamageMultiplayer()
        {
            Random rnd = new Random();
            double multiplyer = 1;
            while(multiplyer > 0.4 || multiplyer < 0)
            {
                multiplyer = rnd.NextDouble();
            }
            return (multiplyer + 1);
        }

        public static int RandomEnemyTurn()
        {
            Random rnd = new Random();
            int enemyDecision = rnd.Next(1, 3);
            return enemyDecision - 1;
        }
    }
}
