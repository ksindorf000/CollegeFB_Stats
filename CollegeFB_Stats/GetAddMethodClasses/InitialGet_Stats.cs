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
        public static Team currentTeam = new Team();
        public static int season;


        /**************************************************
         * InitialInfo()
         *      New or Existing Player?
         *      New or Existing Team?
         *      Stats category?
         *      
         **************************************************/
        public static void InitialInfo()
        {
            currentPlayer = NewOrExistingPlayer();

            currentTeam = NewOrExistingTeam();

            //Console.WriteLine($"{currentPlayer} - {currentTeam}");
            //Console.ReadLine();

            GetStatsCategory();

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
                            currentPlayer = GetAddPlayer.GetPlayerInfo();
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
        public static Team NewOrExistingTeam()
        {
            bool validSelection = false;
            int addOrCreate = 0;

            GetAddTeam.DisplayTeams();

            while (!validSelection)
            {
                Console.WriteLine("Are these stats for (1) an Existing Team or (2) a New Team? ");
                validSelection = int.TryParse(Console.ReadLine(), out addOrCreate);

                if (validSelection)
                {
                    switch (addOrCreate)
                    {
                        case 1:
                            currentTeam = GetAddTeam.UseExistingTeam(currentPlayer);
                            validSelection = true;
                            break;

                        case 2:
                            currentTeam = GetAddTeam.GetTeamInfo();
                            validSelection = true;
                            break;
                        default:
                            Console.WriteLine("That is not a valid option.");
                            validSelection = false;
                            break;
                    }
                }
            }
            return currentTeam;
        }


        /**********************************************
         * GetStatsCategory()
         *      Gets category of stats to be entered
         *      Also gets season
         *      Calls [Category]Stats()
         ***********************************************/
        public static void GetStatsCategory()
        {
            int category;
            bool valid = false;

            Console.WriteLine("Which season are these stats for? (2016): ");
            season = int.Parse(Console.ReadLine());
            
            while (!valid)
            {
                Console.WriteLine("Which type of stats would you like to add? " +
                    "Your options are: \n \t " +
                    "(1)Passing, (2)Rushing, (3)Receiving, (4)Kicking");

                valid = int.TryParse(Console.ReadLine(), out category);

                if (valid)
                {
                    switch (category)
                    {
                        case 1:
                            GetAddPass_Stats.GetPassingStats(currentPlayer, currentTeam, season);
                            break;
                        case 2:
                            GetAddRush_Stats.GetRushStats(currentPlayer, currentTeam, season);
                            break;
                        case 3:
                            GetAddRec_Stats.GetRecStats(currentPlayer, currentTeam, season);
                            break;
                        case 4:
                            GetAddKick_Stats.GetKickStats(currentPlayer, currentTeam, season);
                            break;
                        default:
                            break;
                    }
                }
            }

        }
    }
}
