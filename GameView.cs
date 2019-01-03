using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonAdventure
{
    /// <summary>
    /// Very WIP
    /// Outputs to the screen and takes input from the player
    /// Screens inherit from GameScreen abstract class
    /// </summary>

    // GameScreen is used as parent class for displaying content to the screen
    public abstract class GameScreen
    {
        protected IDictionary<string, Func<GameScreen>> MenuItems;

        public abstract GameScreen Run();

        protected void Write(string text)
        {
            Console.WriteLine(text);
            Console.WriteLine();
            Console.WriteLine("[ENTER]");
            Console.ReadLine();
        }

        protected string Prompt(string text)
        {
            Console.WriteLine(text);
            string PlayerChoice = Console.ReadLine();
            Console.WriteLine();
            return PlayerChoice;
        }

        protected GameScreen Menu()
        {
            Console.WriteLine("What do you want to do?");

            var i = 0;
            foreach (var item in MenuItems)
            {
                i++;
                Console.WriteLine("{0}. {1}", i, item.Key);
            }

            var input = Console.ReadLine();

            int selection;
            if (int.TryParse(input, out selection))
            {
                if (selection > 0 && selection <= MenuItems.Count)
                {
                    return MenuItems.ElementAt(selection - 1).Value();
                }
            }

            return null;
        }
    }

    public class IntroScreen : GameScreen
    {
        private readonly Player _player;

        public IntroScreen(Player player)
        {
            MenuItems = new Dictionary<string, Func<GameScreen>>  //TODO how to dynamically add menu items by room?

        }
    }

    private GameScreen Intro()
    {
        //TODO 
    }

    // public HUD view << Nested in main game view

    public class View
    {
        public View()
        {
            // Constructor sets up the game:
            // TODO add ASCII title and game intro
            // TODO pass the player's setup selections to player object (name, class)
        }


        // setup event to send movement input
        /*private void OnSelect_MoveNorth(object sender, RoutedEventArgs e)
        {
            game.MoveNorth();
        }

        private void OnSelect_MoveWest(object sender, RoutedEventArgs e)
        {
            game.MoveWest();
        }

        private void OnSelect_MoveEast(object sender, RoutedEventArgs e)
        {
            game.MoveEast();
        }

        private void OnSelect_MoveSouth(object sender, RoutedEventArgs e)
        {
            game.MoveSouth();
        }*/
    }
}
