using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeFB_Stats.Models;
using System.Data.Entity;

namespace CollegeFB_Stats.GetAddMethodClasses
{
    class GetAddRec_Stats
    {
        //static int uREC;
        //static int uYDS_Rec;
        //static double uAVG_Rec;
        //static int uLONG_Rec;

        public static List<float> uInput = new List<float>();

        /**********************************************
         * GetRECStats()
         ***********************************************/
        public static void GetRecStats(Player currentPlayer, Team currentTeam, int season)
        {
            bool valid = false;

            float value;
            List<string> recStats = new List<string>()
            {
                "REC",
                "YDS_Rec",
                "AVG_Rec",
                "LONG_Rec"
            };

            foreach (var stat in recStats)
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


            AddRecStats(currentPlayer, currentTeam, season);

        }

        /**********************************************
        * AddRECStats()
        ***********************************************/
        private static void AddRecStats(Player currentPlayer, Team currentTeam, int season)
        {
            using (var db = new CFBStatsContext())
            {
                bool exists = db.Stats.Any(s => s.PlayerId == currentPlayer.Id && s.TeamId == currentTeam.Id && s.Season == season);

                if (exists)
                {
                    //Set Record
                    Stats record = db.Stats.First(s => s.PlayerId == currentPlayer.Id && s.TeamId == currentTeam.Id && s.Season == season);

                    //Update Record
                    record.REC = (int)uInput[0];
                    record.YDS_Rec = (int)uInput[1];
                    record.AVG_Rec = (double)uInput[2];
                    record.LONG_Rec = (int)uInput[3];

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

                        REC = (int)uInput[0],
                        YDS_Rec = (int)uInput[1],
                        AVG_Rec = (double)uInput[2],
                        LONG_Rec = (int)uInput[3]
                    };

                    db.Stats.Add(record);
                }

                db.SaveChanges();
            }
        }
    }
}
