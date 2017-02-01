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

        /**************************************
         * GetTeamInfo()
         *      Get user input
         *      Calls CreateTeam()
         *************************************/
        public static void GetTeamInfo()
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

            CreateTeam();
        }

        /*****************************************
         * CreateTeam()
         *      Adds user input to the Team table
         *****************************************/
        private static void CreateTeam()
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
            }
        }

        /**********************************************
         * UseExistingTeam()
         *      Gets name of team from user
         *      Sets team Id
         ***********************************************/
        public static void UseExistingTeam()
        {
            int teamId;
            string nameFromUser;

            Console.WriteLine("Which team would you like to add stats for? ");
            nameFromUser = Console.ReadLine();

            //Gets t.Id from Team where t.Name LIKE user entry
            using (var context = new CFBStatsContext())
            {
                var tId = context.Team.Where(t => t.Name.Contains(nameFromUser)).Select(t => t.Id);
                teamId = int.Parse(tId.ToString());
            }
        }
       
        /**********************************************
        * DisplayTeams()
        *      Gets and displays list of team names
        ***********************************************/
        public static void DisplayTeams()
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

    }
}
