using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFB_Stats.GetAddMethodClasses
{
    class InitialGet_Stats
    {

        /**************************************************
         * InitialInfo()
         *      Add or select from existing players/teams?
         *      Call Display...() if existing
         *      Call Get...() if create new
         *      Call GetStatsCategory()
         **************************************************/
        public void InitialInfo()
        {
            bool validSelection = false;
            validSelection = NewOrExistingPlayer(validSelection);

            NewOrExistingTeam();

            GetStatsCategory();
        }

        /**************************************************
         * NewOrExistingPlayer()
         *      Asks user if they want to create a new
         *      team of use an existing one
         *      Calls UseExistingPlayer() if existing
         *      Calls GetPlayerInfo() if new
         **************************************************/
        public bool NewOrExistingPlayer(bool validSelection)
        {
            int addOrCreatePlayer = 0;

            DisplayPlayers();

            while (!validSelection)
            {
                Console.WriteLine("Do you want to (1)Add to current Player (2)Create new Player? ");
                validSelection = int.TryParse(Console.ReadLine(), out addOrCreatePlayer);

                if (validSelection)
                {
                    if (addOrCreatePlayer == 1) //Use existing
                    {
                        GetAddPlayer.UseExistingPlayer();
                        validSelection = true;
                    }
                    else if (addOrCreatePlayer == 2) //Create new
                    {
                        GetAddPlayer.GetPlayerInfo();
                        validSelection = true;
                    }
                    else
                    {
                        validSelection = false;
                    }
                }

            }

            return validSelection;
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
            DisplayTeams();

            while (!validSelection)
            {
                Console.WriteLine("Do you want to (1)Add to current Team (2)Create new Team? ");
                validSelection = int.TryParse(Console.ReadLine(), out addOrCreateTeam);

                switch(addOrCreateTeam)
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
         * DisplayPlayers()
         *      Gets and displays list of player names
         ***********************************************/
        public void DisplayPlayers()
        {
            //Get and display existing players
            Console.WriteLine("Existing Players: \n");
            using (var context = new CFBStatsContext())
            {
                var playersList = context.Player.Select(p => p.Name);
                foreach (string p in playersList)
                {
                    Console.WriteLine(p);
                };
            }
        }

        /**********************************************
        * DisplayTeams()
        *      Gets and displays list of team names
        ***********************************************/
        public void DisplayTeams()
        {
            //Get and display existing players
            Console.WriteLine("Existing Teams: \n");
            using (var context = new CFBStatsContext())
            {
                var teamsList = context.Team.Select(t => t.Name);
                foreach (string t in teamsList)
                {
                    Console.WriteLine(t);
                };
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
                        GetAddPass_Stats.GetPassingStats();
                        break;
                    case 2:
                        GetAddRush_Stats.GetRushStats();
                        break;
                    case 3:
                        GetAddRec_Stats.GetRecStats();
                        break;
                    case 4:
                        GetAddKick_Stats.GetKickStats();
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
