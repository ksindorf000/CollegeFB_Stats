using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFB_Stats.GetAddMethodClasses
{
    class GetAddRec_Stats
    {
        static int REC;
        static int YDS_Rec;
        static double AVG_Rec;
        static int LONG_Rec;


        /**********************************************
         * GetRECEIVINGStats()
         ***********************************************/
        private static void GetReceivingStats()
        {
            bool valid = false;

            while (!valid)
            {
                Console.WriteLine("REC: ");
                valid = int.TryParse(Console.ReadLine(), out REC);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("YDS: ");
                valid = int.TryParse(Console.ReadLine(), out YDS_Rec);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("AVG: ");
                valid = double.TryParse(Console.ReadLine(), out AVG_Rec);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("LONG: ");
                valid = int.TryParse(Console.ReadLine(), out LONG_Rec);
            };

            AddReceivingStats();

        }

    }
}
