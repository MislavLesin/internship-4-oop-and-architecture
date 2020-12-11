using DUMP_Dungeon_Crawler.Data.Enums;
using DUMP_Dungeon_Crawler.Domain.Helpers;
using System;
using System.Runtime.CompilerServices;

namespace DUMP_Dungeon_Crawler.Data.Models
{
    public class Warrior : Friendly
    {
        public void RageAttack ()
        {
            Console.WriteLine("Attacking in Rage mode!! \n");
        }
        
        public Warrior(string PlayerName)
        {
            Name = PlayerName;
            HealthPoints = 200;
            HpLimit = 200;
            Damage = 17;
            Type = CharactersEnum.Warrior;
        }
        public override bool WonRound(Enemy oponent)
        {
            Console.WriteLine("0 - Classic Attack");
            Console.WriteLine("1- Rage Atack");
            var decision = UserInputVerification.UserInputVerificationInt(0, 1);
            if(decision == 0)
            {
                if (oponent.ReciveDamage(Damage, this) == true)
                    return true;
                return false;
            }
            else
            {
                if (HealthPoints <= (int)(HpLimit * 0.15))
                {
                    Console.WriteLine("Health too low");
                    Console.WriteLine("Classic attack: ");
                    if (oponent.ReciveDamage(Damage, this) == true)
                        return true;
                    return false;
                }
                else
                    HealthPoints -= (int)(HpLimit * 0.15);
                if (oponent.ReciveDamage(Damage * 2, this) == true)
                    return true;
                return false;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}" +
                $"\nDamage - {Damage}";
        }

    }
}
