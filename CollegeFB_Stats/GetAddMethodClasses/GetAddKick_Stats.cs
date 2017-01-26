using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFB_Stats.GetAddMethodClasses
{
    class GetAddKick_Stats
    {
        static int XPM;
        static int XPA;
        static double XP_Percent;
        static int FGM;
        static int FGA;
        static double FG_Percent;
        static int UnderTwenty;
        static double TwentyToTwentyNine;
        static int ThirtyToThirtyNine;
        static int FourtyToFourtyNine;
        static int FiftyUp;
        static int LNG;
        static int PTS;

        /**********************************************
         * GetKICKINGStats()
         ***********************************************/
        private static void GetKickingStats()
        {
            bool valid = false;

            while (!valid)
            {
                Console.WriteLine("XPM: ");
                valid = int.TryParse(Console.ReadLine(), out XPM);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("XPA: ");
                valid = int.TryParse(Console.ReadLine(), out XPA);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("XP Percentage (45.0): ");
                valid = double.TryParse(Console.ReadLine(), out XP_Percent);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("FGM: ");
                valid = int.TryParse(Console.ReadLine(), out FGM);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("FGA: ");
                valid = int.TryParse(Console.ReadLine(), out FGA);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("FG Percentage (45.0): ");
                valid = double.TryParse(Console.ReadLine(), out FG_Percent);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("1-19: ");
                valid = int.TryParse(Console.ReadLine(), out UnderTwenty);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("20-29: ");
                valid = double.TryParse(Console.ReadLine(), out TwentyToTwentyNine);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("30-29: ");
                valid = int.TryParse(Console.ReadLine(), out ThirtyToThirtyNine);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("40-49: ");
                valid = int.TryParse(Console.ReadLine(), out FourtyToFourtyNine);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("50+: ");
                valid = int.TryParse(Console.ReadLine(), out FiftyUp);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("LNG: ");
                valid = int.TryParse(Console.ReadLine(), out LNG);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("PTS: ");
                valid = int.TryParse(Console.ReadLine(), out PTS);
            };

            AddKickingStats();

        }
    }
}

