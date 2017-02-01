using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeFB_Stats.Models;

namespace CollegeFB_Stats.GetAddMethodClasses
{
    class InitialGet_Stats
    {
        public static Player currentPlayer = new Player();

        /**************************************************
         * InitialInfo()
         *      New or Existing Player?
         *      New or Existing Team?
         *      Stats category?
         *      
         **************************************************/
        public static Player InitialInfo()
        {
            currentPlayer = NewOrExistingPlayer();

            // NewOrExistingTeam();

            //GetStatsCategory();

            return currentPlayer;
        }

        /**************************************************
         * NewOrExistingPlayer()
         *      Asks user if they want to create a new
         *      team of use an existing one
         *      Calls UseExistingPlayer() if existing
         *      Calls GetPlayerInfo() if new
         **************************************************/
        public static Player NewOrExistingPlayer()
        {
            bool validSelection = false;
            int addOrCreatePlayer = 0;

            GetAddPlayer.DisplayPlayers();

            while (!validSelection)
            {
                Console.WriteLine("Do you want to (1)Add to current Player (2)Create new Player? ");
                validSelection = int.TryParse(Console.ReadLine(), out addOrCreatePlayer);
                
                if (validSelection)
                {
                    switch (addOrCreatePlayer)
                    {
                        case 1:
                            currentPlayer = GetAddPlayer.UseExistingPlayer();
                            validSelection = true;
                            break;

                        case 2:
                            GetAddPlayer.GetPlayerInfo();
                            validSelection = true;
                            break;
                        default:
                            Console.WriteLine("That is not a valid option.");
                            validSelection = false;
                            break;
                    }
                }
            }
            return currentPlayer;
        }

        /**********************************************
         * NewOrExistingTeam()
         *      Asks user if they want to create a new
         *      team of use an existing one
         *      Calls UseExistingTeam() if existing
         *      Calls GetTeamInfo() if new
         ***********************************************/
        public void NewOrExistingTeam()
        {
            int addOrCreateTeam = 0;

            bool validSelection = false;
            GetAddTeam.DisplayTeams();

            while (!validSelection)
            {
                Console.WriteLine("Are these stats for an (1)Existing Team or would you like to (2)Create new Team? ");
                validSelection = int.TryParse(Console.ReadLine(), out addOrCreateTeam);

                switch (addOrCreateTeam)
                {
                    case 1:
                        GetAddTeam.UseExistingTeam();
                        break;
                    case 2:
                        GetAddTeam.GetTeamInfo();
                        break;
                    default:
                        break;
                }

            }
        }
        

        /**********************************************
         * GetStatsCategory()
         *      Gets category of stats to be entered
         *      Calls [Category]Stats()
         ***********************************************/
        public static void GetStatsCategory()
        {
            int category;
            bool valid = false;

            while (!valid)
            {
                Console.WriteLine("Which type of stats would you like to add? " +
                    "Your options are: \n \t \t " +
                    "(1)Passing, (2)Rushing, (3)Receiving, (4)Kicking");

                valid = int.TryParse(Console.ReadLine(), out category);

                switch (category)
                {
                    case 1:
                        //GetAddPass_Stats.GetPassingStats();
                        break;
                    case 2:
                        //GetAddRush_Stats.GetRushStats();
                        break;
                    case 3:
                        //GetAddRec_Stats.GetRecStats();
                        break;
                    case 4:
                        //GetAddKick_Stats.GetKickStats();
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
