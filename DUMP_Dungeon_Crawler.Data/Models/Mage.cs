using DUMP_Dungeon_Crawler.Data.Enums;
using DUMP_Dungeon_Crawler.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DUMP_Dungeon_Crawler.Data.Models
{
    public class Mage : Friendly
    {
        public int Mana { get; set; }

        int manaLimit { get; set; }

        public bool ResurrectionUsed { get; set; } = false;

        public Mage (string playerName)
        {
            Name = playerName;
            HealthPoints = 75;
            HpLimit = 75;
            Damage = 32;
            Type = CharactersEnum.Mage;
            Mana = 4;
            manaLimit = 4;
        }
        public override bool WonRound_CheckIfKilled(Enemy oponent)
        {
            if(Mana > 0)
            {
                Console.WriteLine("Current mana = "+ Mana);
                Console.WriteLine("\nMage attacking, select 1 to attack, or 2 to heal: ");
                var attackDecision = UserInputVerification.UserInputVerificationInt(1, 2);
                if(attackDecision == 2)
                {
                    Mana--;
                    HealthPoints += HpLimit / 3;
                    if (HealthPoints > HpLimit)
                        HealthPoints = HpLimit;
                    return false;
                }
                else
                {
                    Mana--;
                    if (oponent.ReciveDamage(Damage, this) == true)
                        return true;
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Recharging Mana");
                Mana = manaLimit;
                return false;
            }
           
        }
        public override void LevelUp(int xpEarned)
        {
            Expirience += xpEarned;
            while (Expirience > XpLimit)
            {
                HpLimit = (int)(HpLimit * 1.2);
                HealthPoints += 25;
                if (HealthPoints > HpLimit)
                    HealthPoints = HpLimit;
                Expirience -= XpLimit;
                Level++;
                Damage = (int)((float)Damage * 1.3);
                manaLimit++;
                XpLimit = (int)((float)XpLimit * 1.2);
                Console.WriteLine("\nLevel Up!");
                Console.WriteLine(Name + " is now level " + Level);
            }
        }
        public void Resurrect()
        {
            Console.WriteLine(Name+ "Has been Resurrected!");
            Console.WriteLine("All stats reset!");
            ResurrectionUsed = true;

            HealthPoints = 100;
            HpLimit = 100;
            Damage = 32;
            Mana = 5;
            manaLimit = 5;

        }
        public override void ReciveDamage(int dmgRecived)
        {
            HealthPoints -= dmgRecived;
            if (HealthPoints <= 0)
            {
                if(ResurrectionUsed == false)
                {
                    Resurrect();
                }
                else
                    isKilled = true;
            }
        }


        public override string ToString()
        {
            return $"{base.ToString()}" +
                $"\nMana - {Mana}/{manaLimit}";
        }
    }
}
