using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeFB_Stats.Models;

namespace CollegeFB_Stats.GetAddMethodClasses
{
    class GetAddRec_Stats
    {
        static int uREC;
        static int uYDS_Rec;
        static double uAVG_Rec;
        static int uLONG_Rec;


        /**********************************************
         * GetRECStats()
         ***********************************************/
        public static void GetRecStats(Player currentPlayer, Team currentTeam, int season)
        {
            bool valid = false;

            while (!valid)
            {
                Console.WriteLine("REC: ");
                valid = int.TryParse(Console.ReadLine(), out uREC);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("YDS: ");
                valid = int.TryParse(Console.ReadLine(), out uYDS_Rec);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("AVG: ");
                valid = double.TryParse(Console.ReadLine(), out uAVG_Rec);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("LONG: ");
                valid = int.TryParse(Console.ReadLine(), out uLONG_Rec);
            };

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
                    record.REC = uREC;
                    record.YDS_Rec = uYDS_Rec;
                    record.AVG_Rec = uAVG_Rec;
                    record.LONG_Rec = uLONG_Rec;
                }
                else
                {
                    //Add new record
                    Stats record = new Stats()
                    {
                        Player = currentPlayer,
                        Team = currentTeam,
                        Season = season,

                        REC = uREC,
                        YDS_Rec = uYDS_Rec,
                        AVG_Rec = uAVG_Rec,
                        LONG_Rec = uLONG_Rec
                    };

                    db.Stats.Add(record);
                }

                db.SaveChanges();
            }
        }
    }
}
