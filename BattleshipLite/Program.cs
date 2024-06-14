using BattleshipLiteLibrary;
using BattleshipLiteLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace BattleshipLite
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DisplayMethods.Welcomemessage(); ;

            PlayerInfoModel activePlayer = LogicMethods.CreatePlayer("Player 1");
            PlayerInfoModel opponent = LogicMethods.CreatePlayer("player 2");

            PlayerInfoModel winner = null;

            do
            {

                // Display grid from activePlayer on where they fire
                DisplayMethods.DisplayShotGrid(activePlayer);


                // Ask activePlayer for their next shot
                // Determine if it is a valid shot (loop if not)
                // Determine shot results
                LogicMethods.RecordPlayerShot(activePlayer, opponent);


                // Determine if the game should continue
                bool doesGameContinue = GameLogic.PlayerStillActive(opponent);

                // If over, set activePlayer as winner
                // else, clear console and swap positions
                if (doesGameContinue == true)
                {
                    //GameLogic.SwapPlayer(activePlayer, opponent); this method commented in library
                    (activePlayer, opponent) = (opponent, activePlayer); // swap positions
                }

                else
                {
                    winner = activePlayer;
                }


            } while (winner == null);


            // Print winners name and amount of shots taken
            DisplayMethods.IdentifyWinner(winner);

            Console.ReadLine();

        }


    }
}
