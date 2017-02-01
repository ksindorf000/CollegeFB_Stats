using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeFB_Stats.Models;

namespace CollegeFB_Stats.GetAddMethodClasses
{
    class GetAddRush_Stats
    {
        static int uCAR;
        static int uYDS_Rush;
        static double uAVG_Rush;
        static int uLONG_Rush;
        static int uTD_Rush;

        /**********************************************
         * GetRUSHStats()
         ***********************************************/
        public static void GetRushStats(Player currentPlayer, Team currentTeam, int season)
        {
            bool valid = false;

            while (!valid)
            {
                Console.WriteLine("CAR: ");
                valid = int.TryParse(Console.ReadLine(), out uCAR);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("YDS: ");
                valid = int.TryParse(Console.ReadLine(), out uYDS_Rush);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("AVG: ");
                valid = double.TryParse(Console.ReadLine(), out uAVG_Rush);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("LONG: ");
                valid = int.TryParse(Console.ReadLine(), out uLONG_Rush);
            };

            valid = false;
            while (!valid)
            {
                Console.WriteLine("TD: ");
                valid = int.TryParse(Console.ReadLine(), out uTD_Rush);
            };

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
                    record.CAR = uCAR;
                    record.YDS_Rush = uYDS_Rush;
                    record.AVG_Rush = uAVG_Rush;
                    record.LONG_Rush = uLONG_Rush;
                    record.TD_Rush = uTD_Rush;
                }
                else
                {
                    //Add new record
                    Stats record = new Stats()
                    {
                        Player = currentPlayer,
                        Team = currentTeam,
                        Season = season,

                        CAR = uCAR,
                        YDS_Rush = uYDS_Rush,
                        AVG_Rush = uAVG_Rush,
                        LONG_Rush = uLONG_Rush,
                        TD_Rush = uTD_Rush

                    };
                    db.Stats.Add(record);
                }
                db.SaveChanges();
            }
        }
    }
}
