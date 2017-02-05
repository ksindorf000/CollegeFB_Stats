using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeFB_Stats.Models;
using System.Data.Entity;

namespace CollegeFB_Stats.GetAddMethodClasses
{
    class GetAddPass_Stats : InitialGet_Stats
    {
        public static List<float> uInput = new List<float>();
        
        /**********************************************
         * GetPASSINGStats()
         ***********************************************/
        public static void GetPassingStats(Player currentPlayer, Team currentTeam, int season)
        {
            bool valid = false;

            float value;
            List<string> passStats = new List<string>()
            {
                "CMP",
                "ATT",
                "YDS_Pass",
                "CMP_Percent",
                "YDS_A",
                "TD_Pass",
                "INT",
                "RAT"
            };
            
            foreach (var stat in passStats)
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
            

            AddPassingStats(currentPlayer, currentTeam, season);

        }


        /*****************************************
         * AddPassingStats()
         *      Adds user input to the Stats table
         *****************************************/
        private static void AddPassingStats(Player currentPlayer, Team currentTeam, int season)
        {
            using (var db = new CFBStatsContext())
            {
                bool exists = db.Stats.Any(s => s.PlayerId == currentPlayer.Id && s.TeamId == currentTeam.Id && s.Season == season);

                if (exists)
                {
                    //Set Record
                    Stats record = db.Stats.First(s => s.PlayerId == currentPlayer.Id && s.TeamId == currentTeam.Id && s.Season == season);

                    //Update Record
                    record.CMP = (int)uInput[0];
                    record.ATT = (int)uInput[1];
                    record.YDS_Pass = (int)uInput[2];
                    record.CMP_Percent = (double)uInput[3];
                    record.YDS_A = (double)uInput[4];
                    record.TD_Pass = (int)uInput[5];
                    record.INT = (int)uInput[6];
                    record.RAT = (int)uInput[7];

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

                        CMP = (int)uInput[0],
                        ATT = (int)uInput[1],
                        YDS_Pass = (int)uInput[2],
                        CMP_Percent = (double)uInput[3],
                        YDS_A = (double)uInput[4],
                        TD_Pass = (int)uInput[5],
                        INT = (int)uInput[6],
                        RAT = (int)uInput[7]
                    };

                    db.Stats.Add(record);
                }
                db.SaveChanges();
            }
        }

    }
}
