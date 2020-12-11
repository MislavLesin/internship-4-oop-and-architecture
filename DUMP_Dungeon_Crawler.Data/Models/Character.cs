using DUMP_Dungeon_Crawler.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DUMP_Dungeon_Crawler.Data.Models
{
    public class Character
    {
        public int HealthPoints { get; set; }

        public int HpLimit { get; set; }

        public int Damage { get; set; }

        public string Name { get; set; }

       public CharactersEnum Type { get; set; }
        public Character()
        {
            
        }
      
        
        public override string ToString()
        {
            return $"Name - {Name} \nType - {Type} \nDamage {Damage} \nHealth - {HealthPoints}/{HpLimit}";
        }
    }
}
