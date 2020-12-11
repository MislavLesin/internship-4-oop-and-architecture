
using DUMP_Dungeon_Crawler.Data.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DUMP_Dungeon_Crawler.Data.Models
{
    public class Enemy : Character
    {
        public Enemy()    
        {
            EnemiesList.Add(this);
        }
       

        public virtual void IsKilled(Friendly userHero) 
        {
            userHero.EnemyKilled(this);
            EnemiesList.Remove(this);
        }
        public virtual void Attack(Friendly user)
        {
            user.ReciveDamage(Damage);
        }
        public static List<Enemy> EnemiesList { get; } = new List<Enemy>();
        public int ExpirienceWorth { get; set; }

        public float GeneratePossibilty { get; set; }

       

        public bool ReciveDamage(int dmgRecived, Friendly userHero) 
        {
            HealthPoints -= dmgRecived;
            Console.WriteLine(Name + " -" + dmgRecived + " Hp");
            if (HealthPoints <= 0)
            {
                IsKilled(userHero);
                return true;
            }
            else
                return false;
                
           
        }
        public virtual void RoundWon(Friendly user)
        {
            user.ReciveDamage(Damage);
        }
        public override string ToString()
        {
            return $"Type - {Type} \nDamage {Damage} \nHealth - {HealthPoints}/{HpLimit}" +
                $"\nXp Worth - {ExpirienceWorth}";
        }
    }
}
