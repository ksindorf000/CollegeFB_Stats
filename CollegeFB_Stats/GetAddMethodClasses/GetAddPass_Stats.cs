using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeFB_Stats.Models;

namespace CollegeFB_Stats.GetAddMethodClasses
{
    class GetAddPass_Stats : InitialGet_Stats
    {
        public static int uCMP;
        public static int uATT;
        public static int uYDS_Pass;
        public static double uCMP_Percent;
        public static double uYDS_A;
        public static int uTD_Pass;
        public static int uINT;
        public static int uRAT;

        /**********************************************
         * GetPASSINGStats()
         ***********************************************/
        public static void GetPassingStats(Player currentPlayer, Team currentTeam, string season)
        {
            bool valid = false;

            while (!valid)
            {
                Console.Write("CMP: ");
                valid = int.TryParse(Console.ReadLine(), out uCMP);
            };

            valid = false;
            while (!valid)
            {
                Console.Write("ATT: ");
                valid = int.TryParse(Console.ReadLine(), out uATT);
            };

            valid = false;
            while (!valid)
            {
                Console.Write("YDS: ");
                valid = int.TryParse(Console.ReadLine(), out uYDS_Pass);
            };

            valid = false;
            while (!valid)
            {
                Console.Write("CMP Percentage (45.0): ");
                valid = double.TryParse(Console.ReadLine(), out uCMP_Percent);
            };

            valid = false;
            while (!valid)
            {
                Console.Write("YDS Attempted: ");
                valid = double.TryParse(Console.ReadLine(), out uYDS_A);
            };

            valid = false;
            while (!valid)
            {
                Console.Write("TD: ");
                valid = int.TryParse(Console.ReadLine(), out uTD_Pass);
            };

            valid = false;
            while (!valid)
            {
                Console.Write("INT: ");
                valid = int.TryParse(Console.ReadLine(), out uINT);
            };

            valid = false;
            while (!valid)
            {
                Console.Write("RAT: ");
                valid = int.TryParse(Console.ReadLine(), out uRAT);
            };

            AddPassingStats(currentPlayer, currentTeam, season);

        }


        /*****************************************
         * AddPassingStats()
         *      Adds user input to the Stats table
         *****************************************/
        private static void AddPassingStats(Player currentPlayer, Team currentTeam, string season)
        {
            using (var db = new CFBStatsContext())
            {
                bool exists = db.Stats.Any(s => s.PlayerId == currentPlayer.Id && s.TeamId == currentTeam.Id && s.Season == season);

                if (exists)
                {
                    //Set Record
                    Stats record = db.Stats.First(s => s.PlayerId == currentPlayer.Id && s.TeamId == currentTeam.Id && s.Season == season);

                    //Update Record
                    record.CMP = uCMP;
                    record.ATT = uATT;
                    record.YDS_Pass = uYDS_Pass;
                    record.CMP_Percent = uCMP_Percent;
                    record.YDS_A = uYDS_A;
                    record.TD_Pass = uTD_Pass;
                    record.INT = uINT;
                    record.RAT = uRAT;
                }

                else
                {
                    //Add new record
                    Stats record = new Stats()
                    {
                        Player = currentPlayer,
                        Team = currentTeam,
                        Season = season,

                        CMP = uCMP,
                        ATT = uATT,
                        YDS_Pass = uYDS_Pass,
                        CMP_Percent = uCMP_Percent,
                        YDS_A = uYDS_A,
                        TD_Pass = uTD_Pass,
                        INT = uINT,
                        RAT = uRAT
                    };

                    db.Stats.Add(record);

                }

                db.SaveChanges();

            }
        }

    }
}
