using BattleshipLiteLibrary.Models;
using BattleshipLiteLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLite
{
    internal class LogicMethods
    {
        public static void RecordPlayerShot(PlayerInfoModel activePlayer, PlayerInfoModel opponent)
        {
            // Asks for a shot (do we ask for "B2" or "B" and then "2"?) - ask for "B2"
            // Determine what row and column that is (split it apart)
            // Determine if that is a valid shot
            // Go back to beginning if not a valid shot (loop)

            bool isvalidShot = false;
            string row = "";
            int column = 0;

            do
            {
                string fullShot = DisplayMethods.AskforShot(activePlayer);


                try
                {
                    (row, column) = GameLogic.SplitShotComponents(fullShot);
                    isvalidShot = GameLogic.ValidateShot(activePlayer, row, column);
                }
                catch (Exception)
                {
                    isvalidShot = false;
                }

                if (isvalidShot == false)
                {
                    Console.WriteLine("Invalid shot location, please try again.");
                }

            } while (!isvalidShot);


            // Determine shot result
            bool isAHit = GameLogic.IdentifyShotResult(opponent, row, column);

            if(isAHit)
            {
                Console.WriteLine($"{row}{column} is a Hit!\n");
            }

            else
            {
                Console.WriteLine($"{row}{column} is a Miss.\n");
            }

            // Update gridspot status (Record results)
            GameLogic.MarkShotResult(activePlayer, row, column, isAHit);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

        }


        public static PlayerInfoModel CreatePlayer(string playerTitle)
        {

            PlayerInfoModel output = new PlayerInfoModel();

            Console.WriteLine($"Player information for {playerTitle}");

            // Ask the user for their name
            output.UsersName = GetPlayerName();

            // Load up the shot grid
            GameLogic.InitializeGrid(output);

            // Ask the user for their 5 ship placements
            PlaceShips(output);

            // Clear screen
            Console.Clear();

            return output;
        }


        public static string GetPlayerName()
        {
            Console.Write("What is your name? ");
            string output = Console.ReadLine();

            return output;
        }


        public static void PlaceShips(PlayerInfoModel model)
        {
            Console.WriteLine();
            DisplayMethods.DisplayShotGrid(model);

            do
            {
                Console.Write($"Where do you want to place ship number {model.ShipLocations.Count + 1}? ");
                string location = Console.ReadLine();

                bool isValidLocaiton = false;

                try
                {
                    isValidLocaiton = GameLogic.PlaceShip(model, location);
                }
                catch (Exception)
                {
                    

                }

                if (isValidLocaiton == false)
                {
                    Console.WriteLine("That was not a valid location, please try again\n");
                }


            } while (model.ShipLocations.Count < 5);
        }

    }
}
