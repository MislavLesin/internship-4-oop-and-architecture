using DUMP_Dungeon_Crawler.Data.Models;
using System;
using System.Collections.Generic;
using DUMP_Dungeon_Crawler.Data.Enums;
using DUMP_Dungeon_Crawler.Data.Helpers;
using System.Xml;

namespace DUMP_Dungeon_Crawler.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var roundCounter = 1;
            Enemy currentEnemy;
            Friendly player;
            bool gameWon = false;
            PrettyPrint.PrettyPrintStartScreen();
            PrettyPrint.PressAnyKeyToContinue();
            int userInput = 1;
            while(userInput != 0)
            {
                Console.Clear();
                LoadListWithEnemiesAndPrint(5);
                PrettyPrint.PressAnyKeyToContinue();
                player = PlayerInitialization();       
                if (player == null)
                    break;
                PrettyPrint.PrettyPrintCharracter(player);
                while(gameWon == false)
                {
                    if (Enemy.EnemiesList.Count != 0)
                        currentEnemy = Enemy.EnemiesList[0];  
                    else
                    {
                        gameWon = true;
                        Console.WriteLine("All enemies killed, you won");
                        break;
                    }
                    Console.WriteLine("Startting round [" + roundCounter + "] against " + currentEnemy.Name + "\n\n");
                    if (StartNewRound(player, currentEnemy) == false)     
                    {
                       
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("You Died!");
                        PrettyPrint.PressAnyKeyToContinue();
                        break;
                    }
                    else
                    {
                        player.EnemyKilled(currentEnemy);
                        PrettyPrint.PrettyPrintLevelUp(player, currentEnemy);
                        
                        PrettyPrint.PressAnyKeyToContinue();
                        roundCounter++;
                    }
                }
                if(gameWon == true)
                {
                    Console.WriteLine("Do you want to play again?");
                    userInput = UserInputVerificationInt(0, 1);
                    if (userInput == 1)
                    {
                        Enemy.EnemiesList.Clear();
                        continue;
                    }
                }
               
            }
            Console.WriteLine("Exitting...");
        }
        public static void LoadListWithEnemiesAndPrint(int numberOfENemies)
        {
            PrettyPrint.PrettyPrintMessage("\nThere are " + numberOfENemies + " Enemies standing before you!" + "\nCan you defeat them all?", ConsoleColor.Red);
            for (var i = 0; i < numberOfENemies; i++)
            {
                RandomGeneratorClass.RandomEnemyInitializationToEnemieList();
            }
            PrettyPrint.PrintEnemyList(Enemy.EnemiesList);
        }
        public static int ReturnRoundWinner(int userAction, int enemyAction)
        {
            
            
            if (((userAction == 0) && enemyAction == 1) ||
                ((userAction == 1) && enemyAction == 2) ||
                ((userAction == 2) && enemyAction ==  0))      
            {
                return 1;       
            }
            else if (enemyAction == userAction)
            {
                return 0;
            }
            else
                return -1;
        }
        public static bool StartNewRound(Friendly user, Enemy oponent)
        {
            int fightOucome;
            bool oponentKilled = false;
            while(oponentKilled == false)
            {
                PrettyPrint.PressAnyKeyToContinue();
                PrettyPrint.PrettyPrintRoundStatus(user, oponent);
                var action = UserSelectFightDecision();
                int enemyAction = RandomGeneratorClass.RandomEnemyTurn();
                PrettyPrint.PrettyPrintFightActionStatus(Enum.GetName(typeof(TurnEnum), action), Enum.GetName(typeof(TurnEnum), enemyAction), user, oponent);
                fightOucome = ReturnRoundWinner(action, enemyAction);
                if (fightOucome == 1)     
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nWon round!\n");
                    if (user.WonRound_CheckIfKilled(oponent) == true)
                    {
                        Console.ResetColor();
                        return true;
                    }
                }
                else if (fightOucome == -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nLost round...");
                    oponent.RoundWon(user);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("\nRound Draw");
                }
               
                if(user.isKilled == true)
                    return false;
            }
            

            return true;
        }
        public static int UserSelectFightDecision()
        {
            Console.WriteLine("\nSelect action: ");
            Console.WriteLine("1 - "+TurnEnum.Direct_Attack);
            Console.WriteLine("2 - " +TurnEnum.Flank_Attack);
            Console.WriteLine("3 - " + TurnEnum.Counter_Attack + "\n");
            var selected = UserInputVerificationInt(1, 3);
            return selected - 1;

        }
        public static void PrintEnemyList(List<Enemy> OponentsList)
        {
            foreach (var enemy in OponentsList)
            {
                PrettyPrint.PrettyPrintCharracter(enemy);
            }
        }
        static Friendly PlayerInitialization()
        {
            Friendly player;
            PrettyPrint.PrettyPrintMessage("Select your hero:", ConsoleColor.Yellow);
            PrettyPrint.PrettyPrintMessage("1 - Warrior", ConsoleColor.Red);
            PrettyPrint.PrettyPrintMessage("2 - Mage", ConsoleColor.Magenta);
            PrettyPrint.PrettyPrintMessage("3 - Ranger", ConsoleColor.Cyan);
            var userInput = UserInputVerificationInt(1, 3) - 1;
            if(userInput == -1)
            {
                Console.WriteLine("Canceling");
                return null;
            }
                
            else
            {
                Console.WriteLine($"{(CharactersEnum)userInput} Selected!\n");
                Console.Write("Enter your name: ");
                var heroName = UserInputVerification();
                player = HeroInitialization(userInput, heroName);
                return player;

            }
        }
        static Friendly HeroInitialization(int type, string name)
        {
            if (type == (int)CharactersEnum.Warrior)
            {
                var warrior = new Warrior(name);
                return warrior;
            }
            else if (type == (int)CharactersEnum.Mage)
            {
                var mage = new Mage(name);
                return mage;
            }
            else 
            {
                var ranger = new Ranger(name);
                return ranger;
            }

        }
        static string UserInputVerification()
        {
            string userInput = "";
            while (string.Compare(userInput, "") == 0)
            {
                try
                {
                    userInput = Console.ReadLine().Trim();
                }
                catch
                {
                    Console.WriteLine("\nTry again\n");
                }
            }
           

            return userInput;
        }
        static int UserInputVerificationInt(int min, int max)
        {
            int userInput = 0;
            bool verifiedFlag = false;
            do 
            {
                try
                {
                    
                    userInput = int.Parse(Console.ReadLine().Trim());
                }
                catch
                {
                    Console.WriteLine("Wrong input! \nTry again");
                }
                if (userInput <= max && userInput >= min)
                    verifiedFlag = true;
                else if (userInput == -1)
                    return userInput;
            } while (verifiedFlag == false);
            
           
            return userInput;
            
        }

        static void RandomEnemyInitializationToEnemieList(int monsterCounter)
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
    }
}