using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFB_Stats.GetAddMethodClasses
{
    class GetAddPass_Stats : InitialGet_Stats
    {
        int CMP;
        int ATT;
        int YDS_Pass;
        double CMP_Percent;
        double YDS_A;
        int TD_Pass;
        int INT;
        int RAT;

        /**********************************************
         * GetPASSINGStats()
         ***********************************************/
        private void GetPassingStats()
        {
            bool valid = false;

            while (!valid)
            {
                Console.Write("CMP: ");
                valid = int.TryParse(Console.ReadLine(), out CMP);
            };

            valid = false;
            while (!valid)
            {
                Console.Write("ATT: ");
                valid = int.TryParse(Console.ReadLine(), out ATT);
            };

            valid = false;
            while (!valid)
            {
                Console.Write("YDS: ");
                valid = int.TryParse(Console.ReadLine(), out YDS_Pass);
            };

            valid = false;
            while (!valid)
            {
                Console.Write("CMP Percentage (45.0): ");
                valid = double.TryParse(Console.ReadLine(), out CMP_Percent);
            };

            valid = false;
            while (!valid)
            {
                Console.Write("YDS Attempted: ");
                valid = double.TryParse(Console.ReadLine(), out YDS_A);
            };

            valid = false;
            while (!valid)
            {
                Console.Write("TD: ");
                valid = int.TryParse(Console.ReadLine(), out TD_Pass);
            };

            valid = false;
            while (!valid)
            {
                Console.Write("INT: ");
                valid = int.TryParse(Console.ReadLine(), out INT);
            };

            valid = false;
            while (!valid)
            {
                Console.Write("RAT: ");
                valid = int.TryParse(Console.ReadLine(), out RAT);
            };

            //AddPassingStats();

        }
    }
}
