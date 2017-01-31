using CollegeFB_Stats.GetAddMethodClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeFB_Stats.Models;

namespace CollegeFB_Stats
{
    class Program
    {
        public static Player currentPlayer = new Player();
        public static bool playOn = true;


        /*************************************
         * Main()
         *************************************/
        static void Main(string[] args)
        {
            while (playOn)
            {
                playOn = Menu();
            }

            Console.WriteLine("Your changes have been saved!");

        }

        /*********************************************************
         * Menu()
         *      Determines which table user wants to add data to
         *********************************************************/
        private static bool Menu()
        {
            bool validOption = false;
            string menuOption = "";

            while (!validOption)
            {
                Console.WriteLine("What do you want to do? " +
                                    "\n \t Add a (P)layer" +
                                                             // "\n \t Add a (T)eam" +
                                                             //"\n \t Add a (S)tat") +
                                    "\n \t (Q)uit");
                menuOption = Console.ReadLine().ToString().ToLower();
                validOption = (menuOption == "p" || menuOption == "t" || menuOption == "s" || menuOption == "q");
            }

            switch (menuOption)
            {
                case "p":
                    currentPlayer = GetAddPlayer.GetPlayerInfo();
                    break;
                //case "t":
                //    GetAddTeam.GetTeamInfo();
                //    break;
                //case "s":
                //    InitialGet_Stats.InitialInfo();
                //    break;
                case "q":
                    playOn = false;
                    break;
                default:
                    Console.WriteLine("Sorry, that is not a valid option.");
                    break;
            }
            return playOn;
        }
        
    }
}
