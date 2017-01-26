using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFB_Stats.GetAddMethodClasses
{
    class GetAddRush_Stats
    {
        static int CAR;
        static int YDS_Rush;
        static double AVG_Rush;
        static double LONG_Rush;
        static double TD_Rush;

        /**********************************************
         * GetRUSHINGStats()
         ***********************************************/
        private static void GetRushingStats()
        {
            bool valid = false;

            while (!valid)
            {
                Console.WriteLine("CAR: ");
                valid = int.TryParse(Console.ReadLine(), out CAR);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("YDS: ");
                valid = int.TryParse(Console.ReadLine(), out YDS_Rush);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("AVG: ");
                valid = double.TryParse(Console.ReadLine(), out AVG_Rush);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("LONG: ");
                valid = double.TryParse(Console.ReadLine(), out LONG_Rush);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("TD: ");
                valid = double.TryParse(Console.ReadLine(), out TD_Rush);
            };

            AddRushingStats();
        }

    }
}
