using CollegeFB_Stats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFB_Stats.GetAddMethodClasses
{
    class GetAddTeam
    {

        static string teamName;
        static int yearFormed;
        static string headCoach;
        static string cityState;
        static string league;
        static string mascot;

        public static Team currentTeam = new Team();

        /**************************************
         * GetTeamInfo()
         *      Get user input
         *      Calls CreateTeam()
         *************************************/
        public static Team GetTeamInfo()
        {
            bool validYear = true;

            Console.WriteLine("Please enter team name: ");
            teamName = Console.ReadLine();

            Console.WriteLine("Please enter team mascot: ");
            mascot = Console.ReadLine();

            Console.WriteLine("Please enter league to which team belongs: ");
            league = Console.ReadLine();

            Console.WriteLine("Please enter team's head coach: ");
            headCoach = Console.ReadLine();

            Console.WriteLine("Please enter the team location (City, St): ");
            cityState = Console.ReadLine();

            while (!validYear)
            {
                Console.WriteLine("Please enter year formed (2000): ");
                validYear = int.TryParse(Console.ReadLine(), out yearFormed);
            }

            currentTeam = CreateTeam();
            return currentTeam;
        }

        /*****************************************
         * CreateTeam()
         *      Adds user input to the Team table
         *****************************************/
        private static Team CreateTeam()
        {
            using (var db = new CFBStatsContext())
            {
                Team team = new Team
                {
                    Name = teamName,
                    Mascot = mascot,
                    League = league,
                    HeadCoach = headCoach,
                    CityState = cityState,
                    YearFormed = yearFormed
                };

                db.Team.Add(team);
                db.SaveChanges();

                return team;

            }
        }

        /**********************************************
         * UseExistingTeam()
         *      Gets name of team from user
         *      Sets team Id
         ***********************************************/
        public static Team UseExistingTeam(Player currentPlayer)
        {
            int teamId;
            bool validId = false;
            Team currentTeam = new Team();

            using (var db = new CFBStatsContext())
            {
                while (!validId)
                {
                    Console.WriteLine("Which team would you like to add stats for? (ID):");
                    validId = int.TryParse(Console.ReadLine(), out teamId);

                    if (validId && db.Team.Any(t => t.Id == teamId))
                    {
                        currentTeam = db.Team.First(t => t.Id == teamId);
                        validId = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, that is not a valid option.");
                        validId = false;
                    }
                }
            }

            return currentTeam;
        }

        /**********************************************
        * DisplayTeams()
        *      Gets and displays list of team names
        ***********************************************/
        public static void DisplayTeams()
        {
            //Get and display existing teams
            Console.WriteLine("Existing Teams: \n");
            using (var db = new CFBStatsContext())
            {
                foreach (Team t in db.Team)
                {
                    Console.WriteLine(t);
                };
            }
        }

    }
}
