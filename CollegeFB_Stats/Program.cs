using CollegeFB_Stats.GetAddMethodClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFB_Stats
{
    class Program
    {
        /*************************************
         * Main()
         *************************************/
        static void Main(string[] args)
        {
            string menuOption;

            bool playOn = true;

            while (playOn)
            {
                menuOption = Menu();
                CallGetAdd(menuOption);
                playOn = SuccessMessage();
            }
        }

        /*********************************************************
         * Menu()
         *      Determines which table user wants to add data to
         *********************************************************/
        private static string Menu()
        {
            bool validOption = true;
            string menuOption = "";

            while (!validOption)
            {
                Console.WriteLine("What do you want to do? " +
                                    "\n \t \t Add a (P)layer" +
                                    "\n \t \t Add a (T)eam" +
                                    "\n \t \t Add a (S)tat");
                menuOption = Console.ReadLine().ToString().ToLower();
                validOption =
                    (menuOption == "p" || menuOption == "t" || menuOption == "s")
                    ? true : false;
            }

            return menuOption;
        }

        /*********************************************************
         * CallGetAdd()
         *      Calls the correct GetAdd... class
         *********************************************************/
        private static void CallGetAdd(string menuOption)
        {
            if (menuOption == "p")
            {
                GetAddPlayer.GetPlayerInfo();
            }
            else if (menuOption == "t")
            {
                GetAddTeam.GetTeamInfo();
            }
            else
            {
                InitialGet_Stats.InitialInfo();
            }
        }
    }
}
