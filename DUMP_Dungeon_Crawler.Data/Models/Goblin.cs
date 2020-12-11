using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DUMP_Dungeon_Crawler.Data.Models
{
   public class Goblin : Enemy
    {
        public Goblin(double multiplyer)
        {
            HealthPoints = (int)((double)30 * multiplyer);
            HpLimit = HealthPoints;
            Damage = (int)((double)9 * multiplyer);
            Name = "Goblin";
            ExpirienceWorth = (int)((double)25 * multiplyer);
            Type = Enums.CharactersEnum.Goblin;
            GeneratePossibilty = 0.6f;
        }
    }
}
