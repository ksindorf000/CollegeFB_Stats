using CollegeFB_Stats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFB_Stats.GetAddMethodClasses
{
    class GetAddPlayer
    {
        static string playerName;
        static string position;
        static int age;
        static string schoolClass;

        /**************************************
         * GetPlayerInfo()
         *      Get user input
         *      Calls CreatePlayer()
         *************************************/
        public static Player GetPlayerInfo()
        {
            bool validAge = false;

            Console.WriteLine("Please enter player name: ");
            playerName = Console.ReadLine();

            Console.WriteLine("Please enter player position: ");
            position = Console.ReadLine();

            Console.WriteLine("Please enter player class (RS Freshman, True Freshman, Sophomore, Junior, Senior): ");
            schoolClass = Console.ReadLine();

            while (!validAge)
            {
                Console.WriteLine("Please enter player age: ");
                validAge = int.TryParse(Console.ReadLine(), out age);
            }

            Player currentPlayer = CreatePlayer();
            return currentPlayer;
        }

        /**********************************************
         * CreatePlayer()
         *      Adds user input to the Player table
         *********************************************/
        private static Player CreatePlayer()
        {
            using (var db = new CFBStatsContext())
            {
                Player player = new Player
                {
                    Name = playerName,
                    Position = position,
                    Age = age,
                    Class = schoolClass
                };

                db.Player.Add(player);
                db.SaveChanges();
                return player;
            }
        }

        /**********************************************
        * UseExistingPlayer()
        *      Gets id of player from user
        *      Sets currentPlayer
        ***********************************************/
        public static Player UseExistingPlayer()
        {
            int playerId;
            bool validId = false;
            Player currentPlayer = new Player();

            using (var db = new CFBStatsContext())
            {
                while (!validId)
                {
                    Console.WriteLine("Which player would you like to add stats for? (ID):");
                    validId = int.TryParse(Console.ReadLine(), out playerId);

                    if (db.Player.Any(p => p.Id == playerId))
                    {
                        currentPlayer = db.Player.First(p => p.Id == playerId);
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

            return currentPlayer;
        }

        /**********************************************
         * DisplayPlayers()
         *      Gets and displays list of player names
         ***********************************************/
        public static void DisplayPlayers()
        {
            //Get and display existing players
            Console.WriteLine("Existing Players: \n");
            using (var db = new CFBStatsContext())
            {
                foreach (Player p in db.Player)
                {
                    Console.WriteLine(p);
                };
            }
        }
    }
}

