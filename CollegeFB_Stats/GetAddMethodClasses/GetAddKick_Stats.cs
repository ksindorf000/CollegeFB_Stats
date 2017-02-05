using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeFB_Stats.Models;
using System.Data.Entity;

namespace CollegeFB_Stats.GetAddMethodClasses
{
    class GetAddKick_Stats
    {
        //static int uXPM;
        //static int uXPA;
        //static double uXP_Percent;
        //static int uFGM;
        //static int uFGA;
        //static double uFG_Percent;
        //static int uUnderTwenty;
        //static int uTwentyToTwentyNine;
        //static int uThirtyToThirtyNine;
        //static int uFourtyToFourtyNine;
        //static int uFiftyUp;
        //static int uLNG;
        //static int uPTS;

        public static List<float> uInput = new List<float>();

        /**********************************************
         * GetKICKStats()
         ***********************************************/
        public static void GetKickStats(Player currentPlayer, Team currentTeam, int season)
        {
            bool valid = false;

            float value;
            List<string> kickStats = new List<string>()
            {
                "XMP",
                "XPA",
                "XP_Percent",
                "FGM",
                "FGA",
                "FG_Percent",
                "UnderTwenty",
                "TwentyToTwentyNine",
                "ThirtyToThirtyNine",
                "FourtyToFourtyNine",
                "FiftyUp",
                "LNG",
                "PTS"
            };

            foreach (var stat in kickStats)
            {
                while (!valid)
                {
                    Console.WriteLine($"{stat}: ");
                    valid = float.TryParse(Console.ReadLine(), out value);

                    if (valid)
                    {
                        uInput.Add(value);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid value.");
                    }
                }
                valid = false;
            }

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

                    record.XPA = (int)uInput[0];
                    record.XPM = (int)uInput[1];
                    record.XP_Percent = (double)uInput[2];
                    record.FGM = (int)uInput[3];
                    record.FGA = (int)uInput[4];
                    record.FG_Percent = (double)uInput[5];
                    record.UnderTwenty = (int)uInput[6];
                    record.TwentyToTwentyNine = (int)uInput[7];
                    record.ThirtyToThirtyNine = (int)uInput[8];
                    record.FourtyToFourtyNine = (int)uInput[9];
                    record.FiftyUp = (int)uInput[10];
                    record.LNG = (int)uInput[11];
                    record.PTS = (int)uInput[12];

                    db.Entry(record).State = EntityState.Modified;

                }
                else
                {
                    //Add new record
                    Stats record = new Stats()
                    {
                        PlayerId = currentPlayer.Id,
                        TeamId = currentTeam.Id,
                        Season = season,


                        XPA = (int)uInput[0],
                        XPM = (int)uInput[1],
                        XP_Percent = (double)uInput[2],
                        FGM = (int)uInput[3],
                        FGA = (int)uInput[4],
                        FG_Percent = (double)uInput[5],
                        UnderTwenty = (int)uInput[6],
                        TwentyToTwentyNine = (int)uInput[7],
                        ThirtyToThirtyNine = (int)uInput[8],
                        FourtyToFourtyNine = (int)uInput[9],
                        FiftyUp = (int)uInput[10],
                        LNG = (int)uInput[11],
                        PTS = (int)uInput[12]

                    };

                    db.Stats.Add(record);
                }
                db.SaveChanges();
            }

        }
    }
}

