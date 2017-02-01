using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeFB_Stats.Models;

namespace CollegeFB_Stats.GetAddMethodClasses
{
    class GetAddKick_Stats
    {
        static int uXPM;
        static int uXPA;
        static double uXP_Percent;
        static int uFGM;
        static int uFGA;
        static double uFG_Percent;
        static int uUnderTwenty;
        static int uTwentyToTwentyNine;
        static int uThirtyToThirtyNine;
        static int uFourtyToFourtyNine;
        static int uFiftyUp;
        static int uLNG;
        static int uPTS;

        /**********************************************
         * GetKICKStats()
         ***********************************************/
        public static void GetKickStats(Player currentPlayer, Team currentTeam, int season)
        {
            bool valid = false;

            while (!valid)
            {
                Console.WriteLine("XPM: ");
                valid = int.TryParse(Console.ReadLine(), out uXPM);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("XPA: ");
                valid = int.TryParse(Console.ReadLine(), out uXPA);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("XP Percentage (45.0): ");
                valid = double.TryParse(Console.ReadLine(), out uXP_Percent);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("FGM: ");
                valid = int.TryParse(Console.ReadLine(), out uFGM);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("FGA: ");
                valid = int.TryParse(Console.ReadLine(), out uFGA);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("FG Percentage (45.0): ");
                valid = double.TryParse(Console.ReadLine(), out uFG_Percent);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("1-19: ");
                valid = int.TryParse(Console.ReadLine(), out uUnderTwenty);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("20-29: ");
                valid = int.TryParse(Console.ReadLine(), out uTwentyToTwentyNine);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("30-29: ");
                valid = int.TryParse(Console.ReadLine(), out uThirtyToThirtyNine);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("40-49: ");
                valid = int.TryParse(Console.ReadLine(), out uFourtyToFourtyNine);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("50+: ");
                valid = int.TryParse(Console.ReadLine(), out uFiftyUp);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("LNG: ");
                valid = int.TryParse(Console.ReadLine(), out uLNG);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("PTS: ");
                valid = int.TryParse(Console.ReadLine(), out uPTS);
            };

            AddKickStats(currentPlayer, currentTeam, season);
        }

        /***************************************************
         * AddKickStats()
         *      Checks to see if record with currentTeam
         *      && currentPlayer exists
         *      Creates or Updates record as needed
         **************************************************/
        private static void AddKickStats(Player currentPlayer, Team currentTeam, int season)
        {
            using (var db = new CFBStatsContext())
            {
                bool exists = db.Stats.Any(s => s.PlayerId == currentPlayer.Id && s.TeamId == currentTeam.Id && s.Season == season);

                if (exists)
                {
                    //Set Record
                    Stats record = db.Stats.First(s => s.PlayerId == currentPlayer.Id && s.TeamId == currentTeam.Id && s.Season == season);

                    record.XPA = uXPA;
                    record.XPM = uXPM;
                    record.XP_Percent = uXP_Percent;
                    record.FGM = uFGM;
                    record.FG_Percent = uFG_Percent;
                    record.UnderTwenty = uUnderTwenty;
                    record.TwentyToTwentyNine = uTwentyToTwentyNine;
                    record.ThirtyToThirtyNine = uThirtyToThirtyNine;
                    record.FourtyToFourtyNine = uFourtyToFourtyNine;
                    record.FiftyUp = uFiftyUp;
                    record.LNG = uLNG;
                    record.PTS = uPTS;

                }
                else
                {
                    //Add new record
                    Stats record = new Stats()
                    {
                        Player = currentPlayer,
                        Team = currentTeam,
                        Season = season,

                        XPA = uXPA,
                        XPM = uXPM,
                        XP_Percent = uXP_Percent,
                        FGM = uFGM,
                        FG_Percent = uFG_Percent,
                        UnderTwenty = uUnderTwenty,
                        TwentyToTwentyNine = uTwentyToTwentyNine,
                        ThirtyToThirtyNine = uThirtyToThirtyNine,
                        FourtyToFourtyNine = uFourtyToFourtyNine,
                        FiftyUp = uFiftyUp,
                        LNG = uLNG,
                        PTS = uPTS

                    };
                    db.Stats.Add(record);
                    db.SaveChanges();

                }
            }

        }
    }
}

