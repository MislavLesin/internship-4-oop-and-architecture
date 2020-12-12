using DUMP_Dungeon_Crawler.Data.Enums;
using DUMP_Dungeon_Crawler.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DUMP_Dungeon_Crawler.Data.Models
{
    public class Friendly : Character
    {
        public bool isKilled { get; set; } = false;
        public int Expirience { get; set; } = 0;

        public int XpLimit { get; set; } = 80;

       
        public int Level { get; set; } = 1;


        public void EnemyKilled(Enemy oponent)
        {
            LevelUp(oponent.ExpirienceWorth);
            RegenHealtAfterKill();
            Enemy.EnemiesList.Remove(oponent);
        }

        public void RegenHealtAfterKill()
        {
            int hpIncrease = (int)((float)HpLimit * 0.25);
            if (HealthPoints > (HpLimit - hpIncrease))
                HealthPoints = HpLimit;
            else
            {
                HealthPoints += hpIncrease;
            }
        }

        public Friendly()
        {
            XpLimit = 80;
        }
        public virtual void LevelUp(int expirience)
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
                Console.WriteLine("\nLevel Up!");
                Console.WriteLine(Name + " is now level " + Level);
            }
        }
        public virtual void ReciveDamage(int dmgRecived)        
        {
            HealthPoints -= dmgRecived;
            Console.WriteLine(Name+" - "+ dmgRecived+ " Hp");
            if (HealthPoints <= 0)
                isKilled = true;
        }
        public virtual bool WonRound_CheckIfKilled(Enemy oponent)   
        {
            if (oponent.ReciveDamage(Damage, this) == true)
                return true;
            return false;

        }
        public override string ToString()
        {
            return $"{base.ToString()} \nExpirience - {Expirience}/ {XpLimit}\nLevel - {Level}";
        }
    }
}
