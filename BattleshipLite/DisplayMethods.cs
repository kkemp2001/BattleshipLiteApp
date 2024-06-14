using BattleshipLiteLibrary.Models;
using BattleshipLiteLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLite
{
    internal class DisplayMethods
    {

        public static void IdentifyWinner(PlayerInfoModel winner)
        {
            Console.WriteLine($"Congratulations to {winner.UsersName} for winning!");
            Console.WriteLine($"{winner.UsersName} took {GameLogic.GetShotCount(winner)} shots");
        }

        //private static void IdentifyWinner(PlayerInfoModel winner)
        //{
        //  Console.WriteLine($"Congratulations to { winner.UsersName } for winning!");
        //     Console.WriteLine($"{ winner.UsersName } took { GameLogic.GetShotCount(winner)} shots");
        // }


        public static string AskforShot(PlayerInfoModel activePlayer)
        {
            Console.WriteLine($"{activePlayer.UsersName}, where would you like to shoot? ");
            string output = Console.ReadLine();

            return output;
        }

        public static void DisplayShotGrid(PlayerInfoModel activePlayer)  // improve it by having A, B, C, 1, 2, 3, etc on border and underscores for empty spots 
        {

            string currentRow = activePlayer.ShotGrid[0].SpotLetter;

            foreach (var gridSpot in activePlayer.ShotGrid)
            {
                if (gridSpot.SpotLetter != currentRow)
                {
                    Console.WriteLine();
                    currentRow = gridSpot.SpotLetter;
                }

                if (gridSpot.Status == GridSpotStatus.Empty)
                {
                    Console.Write($" {gridSpot.SpotLetter}{gridSpot.SpotNumber}");
                }

                else if (gridSpot.Status == GridSpotStatus.Hit)
                {
                    Console.Write(" X ");
                }

                else if (gridSpot.Status == GridSpotStatus.Miss)
                {
                    Console.Write(" O ");
                }

                else // catch all
                {
                    Console.Write(" ?  ");
                }
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public static void Welcomemessage()
        {
            Console.WriteLine("Welcome to Battleship Lite");
            Console.WriteLine("Created by Kacey Kemp");
            Console.WriteLine();
        }

    }
}
