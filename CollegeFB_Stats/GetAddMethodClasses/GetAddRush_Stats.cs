using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeFB_Stats.Models;
using System.Data.Entity;

namespace CollegeFB_Stats.GetAddMethodClasses
{
    class GetAddRush_Stats
    {
        //static int uCAR;
        //static int uYDS_Rush;
        //static double uAVG_Rush;
        //static int uLONG_Rush;
        //static int uTD_Rush;

        public static List<float> uInput = new List<float>();

        /**********************************************
         * GetRUSHStats()
         ***********************************************/
        public static void GetRushStats(Player currentPlayer, Team currentTeam, int season)
        {
            bool valid = false;

            float value;
            List<string> rushStats = new List<string>()
            {
                "CAR",
                "YDS_Rush",
                "AVG_Rush",
                "LONG_Rush",
                "TD_Rush"
            };

            foreach (var stat in rushStats)
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

            AddRushStats(currentPlayer, currentTeam, season);
        }

        /**********************************************
        * AddRUSHStats()
        ***********************************************/
        private static void AddRushStats(Player currentPlayer, Team currentTeam, int season)
        {
            using (var db = new CFBStatsContext())
            {
                bool exists = db.Stats.Any(s => s.PlayerId == currentPlayer.Id && s.TeamId == currentTeam.Id && s.Season == season);

                if (exists)
                {
                    //Set Record
                    Stats record = db.Stats.First(s => s.PlayerId == currentPlayer.Id && s.TeamId == currentTeam.Id && s.Season == season);

                    //Update Record
                    record.CAR = (int)uInput[0];
                    record.YDS_Rush = (int)uInput[1];
                    record.AVG_Rush = (double)uInput[2];
                    record.LONG_Rush = (int)uInput[3];
                    record.TD_Rush = (int)uInput[4];

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

                        CAR = (int)uInput[0],
                        YDS_Rush = (int)uInput[1],
                        AVG_Rush = (double)uInput[2],
                        LONG_Rush = (int)uInput[3],
                        TD_Rush = (int)uInput[4]
                    };

                    db.Stats.Add(record);
                }
                db.SaveChanges();
            }
        }
    }
}
