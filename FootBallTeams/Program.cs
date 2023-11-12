using System;
using System.Linq;
using System.Collections.Generic; // becuse list need it
namespace FootBallTeams
{
//Hi am viewd this project am khatomi 
    #region Team Info
    //struct Team Info
    public struct Team
    {
        public string TeamName;
        public int NumberOfWin;
        public int NumberOfDraws;
        public int NumberOfLoses;
        public int Points;
    } 
    #endregion
    internal class Program
    {
        #region Methods
        /// <summary>
        /// this methode print message with one shap "*" 
        /// </summary>
        /// <param name="message"></param>
        static void PrintMessage(string message)
        {
            Console.WriteLine("****** ****** ****** ****** ****** ******");
            Console.WriteLine(message);
            Console.WriteLine("****** ****** ****** ****** ****** ******\n\n");
        }
        /// <summary>
        /// this methode print message with tow shaps "* or /"
        /// </summary>
        /// <param name="message"></param>
        /// <param name="MessageType"></param>
        static void PrintMessage(string message, int MessageType)
        {
            if (MessageType == 0)
            {
                
                Console.WriteLine(message);
                
            }
            else if (MessageType == 1) 
            {

                Console.WriteLine("****** ****** ****** ****** ****** ******");
                Console.WriteLine(message);
                Console.WriteLine("****** ****** ****** ****** ****** ******");

            }
            else
            {
                Console.WriteLine("\n\n-----------------------------------------");
                Console.WriteLine(message);
                Console.WriteLine("-----------------------------------------");
            }

        }
        /// <summary>
        /// this method chick number isit valid or not ?
        /// </summary>
        /// <param name="data"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        static bool ChickIntNumber(string data, out int num)
        {
            bool bIsValidNumber = int.TryParse(data, out num);
            if (!bIsValidNumber)
            {
                PrintMessage("plase enter valid number", 2);
                num = 0;
                return false;
            }
            return true;
        } 
        #endregion
        static void Main(string[] args)
        {
            #region 1 - welcome user to our app
            PrintMessage("welcome to our app !");
            #endregion


            #region 2 - define a list to store data of Team from user :
            List<Team> ListTeams = new List<Team>();
            #endregion


            #region  3 - loop over number of team to store data
            char LoopIndex = 'a';

            while (LoopIndex != 'e')
            {
                //define obj strcut of Team
                Team myTeam;

                #region 3.1- Read data from user (Data of Team)

                PrintMessage("plz enter team name", 0);
                myTeam.TeamName = Console.ReadLine();

                PrintMessage("plz enter number of wins", 0);
                if (!ChickIntNumber(Console.ReadLine(), out myTeam.NumberOfWin))
                    continue;

                PrintMessage("plz enter number of draws", 0);
                if (!ChickIntNumber(Console.ReadLine(), out myTeam.NumberOfDraws))
                    continue;

                PrintMessage("plz enter number of loses", 0);
                if (!ChickIntNumber(Console.ReadLine(), out myTeam.NumberOfLoses))
                    continue;
                #endregion

                // Calculate points
                myTeam.Points = (myTeam.NumberOfWin * 3) + myTeam.NumberOfDraws;

                #region 3.2- stor data into ginaric list
                ListTeams.Add(myTeam);
                #endregion

                PrintMessage("pres 'e' to exit or any keys to contnue", 2);
                LoopIndex = Convert.ToChar(Console.ReadLine());
            } 
            #endregion

            #region 3- sort for team by number of points:

            int MaxNumber = ListTeams.Max(x => x.Points);
            Team Winner = ListTeams.Where(a => a.Points == MaxNumber).FirstOrDefault();
            List<Team> lstfilterTeam = ListTeams.Where(p => p.Points > 20).ToList();
            #endregion

            #region 4- print team by winer
            PrintMessage($"the name of winner : {Winner.TeamName}", 1); 
            #endregion
        }
    }
}
