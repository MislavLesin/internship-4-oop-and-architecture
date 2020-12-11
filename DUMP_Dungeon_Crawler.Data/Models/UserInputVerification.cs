using System;
using System.Collections.Generic;
using System.Text;

namespace DUMP_Dungeon_Crawler.Domain.Helpers
{
    public static class UserInputVerification
    {
        public static int UserInputVerificationInt(int min, int max)
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
                else
                    Console.WriteLine("Try again");
            } while (verifiedFlag == false);

            return userInput;

        }
    }
}
