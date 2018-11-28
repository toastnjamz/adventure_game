/* By Verity Davis
*  V1: 2018/11/27
*/

using System;
using System.Collections.Generic;

namespace AdventureGame
{
    public static class Game
    {
        // adding a Scenarios variable for flexibility later (for adding more)
        static int Scenarios = 3;
        // ToDo: add multidimensional arrays and use Length property in for loop below

        // declaring the CharacterName variable
        static string CharacterName;

        // adding list to keep track of player inventory (items)
        static List<string> Inventory = new List<string>();


        // adding index-sensitive arrays that store scenarios for the branching narrative
        static string[] PartOne =
        {
            "You see a human guard posted in the corridor outside your cell. What do you do?\nA) Take a look around your cell\nB) Whistle at the guard",
            "You search the dirt floor of your cell. It's got some dried blood stains and...\nWhat's this!\nYour darkvision picks up the shape of a tarnished key lying amongst some troll teeth.\nYou pick up the key.",
            "\"Hey there, handsome. Come here often?\"\nThe guard turns and raises a hairy eyebrow at you, then turns back around.",
            "You wait to make sure the guard isn't looking, then try to open the cell door lock.",
            "You try the key you found.\nIt turns and the lock springs open!\nHow... convenient.",
            "You try picking the lock with an old bone you find on the ground.\nAfter a little trying, the lock springs open!\nYou've done this before... *something about unsavory pasts*",
            "You slowly open the gate to keep it from creaking, then step out into the corridor."
        };

        static string[] PartTwo =
        {
            "Unfortunately, the guard heard you open the cell door and turns to see you standing there.\nHe starts running toward you. What do you do?\nA) Stand your ground and fight him mono e half-pint\nB) Try to run between his legs (you're pretty short, being a dwarf and all)",
            "The guard sees you're attempting to fight and swings his broad sword.\nYou're able to dodge just in time, despite your hangover.\nYou run past him and into the corridor beyond.",
            "Despite your headache, you're quick on your feet.\nYou run right between the guard's legs, narrowly escaping into the corridor beyond.",
            "You run down the corridor and traverse up a stone staircase at the end.\nAt the top is another corridor with rooms flanking each side.\nYou step into the first doorway on the left.\nEmbers of Ragnaros! You've stumbled on the armory! How... convenient.",
            "The small room is lined with weapon racks filled with all manner of aggressive-looking implements.",
            "The small room is lined with weapon racks filled with all manner of aggressive-looking implements.",
            "There are a couple of items very close at hand..."
        };

        static string[] PartThree =
        {
            "Which do you choose?\nA) A battle axe. Tempered, trusty.\nB) A parasol? What's this even doing here?",
            "Nothing like a familiar weapon in your hands!",
            "I feel pretty! Oh so pretty!",
            "You see the shadow of the guard mounting the staircase.\nYou brandish your chosen weapon and ready a surprise attack.",
            "The guard rounds the corner and you have just enough time land a surprise blow at torso level.\nBaruk Khazad! You cut him deep. He hits the floor.",
            "As the guard rounds the corner, you open your pretty parasol in his face, distracting him.\nYou use the stolen time to jab him in the eye with the end.\nHe hits the floor.",
            "With the guard down, you peep around the corner and see the main exit at the end of the hall.\nIt's flanked by two more guards.\nYou steel yourself and round the corner, gripping your weapon.\nYou charge the guards..."
        };

        // TODO change guard copy to a different color (include Utility class in a separate file with Dialog method)

        // calls the major methods for the game
        public static void StartGame()
        {
            GameTitle();
            IntroText();
            NameCharacter();
            Choice();
            EndGame();
        }

        // sets console title and prints opening game screen
        public static void GameTitle()
        {
            // Console.SetWindowSize(85, 43); Not supported on this platform
            string Title = "Not Another Dungeon";
            Console.Title = Title;
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            // prints ASCII art from ASCIITITLE.cs file
            AsciiTitle.WriteAsciiTitle();
        }

        // prints intro text to the screen
        static void IntroText()
        {
            string IntroString =
                "You wake up in a cell in what looks like a dungeon after a night of dwarven debauchery.\n" +
                "One minute you were drinking ale with your clan-mates...\n" +
                "...The next you woke up here. Your head is pounding. Even your beard hurts.\n" +
                "You sure could use a hair of the hellhound. Time to find a way out!";

            Console.WriteLine(IntroString);
        }

        // reads in and saves the player's choice of character name
        public static void NameCharacter()
        {
            Console.WriteLine("Can you remember your name?");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            CharacterName = Console.ReadLine();
            Console.ResetColor();
            Console.WriteLine($"Yes, {CharacterName}. That sounds right.");
            Console.WriteLine("See if you can find the key, {0}.\n", CharacterName);
        }

        // reads in and saves the player's choice for the branching narrative
        static void Choice()
        {
            // for loop keeps the game moving forward until scenarios run out
            for (int section = 1; section <= Scenarios; section++)
            {
                // declaring the input variable that stores the player's choices
                string input = "";

                // switch statement prints out branching narrative from arrays based on player choice
                // same pattern for each of the five sections
                // TODO add else if and if statements to allow for invalid input or add error handling
                switch (section)
                {
                    // part one
                    case 1:

                        // 1) prints out the first part of the array
                        Console.WriteLine(PartOne[0]);

                        // 2) reads in the player's choice (a or b)
                        Console.Write("Enter your choice: ");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        input = Console.ReadLine();
                        input = input.ToUpper();
                        Console.ResetColor();

                        // 3) if a, print the next part of the array, otherwise skip and print third
                        if (input == "A")
                        {
                            Console.WriteLine(PartOne[1]);
                            //adding item to player's inventory list
                            Inventory.Add("Key");
                        }
                        else
                        {
                            Console.WriteLine(PartOne[2]);
                            //adding item to player's inventory list
                            Inventory.Add("Bone");
                        }

                        // 4) prints out next part of the array
                        Console.WriteLine(PartOne[3]);

                        // again, if a, print next, otherwise skip ahead
                        if (input == "A")
                        {
                            Console.WriteLine(PartOne[4]);
                        }
                        else
                        {
                            Console.WriteLine(PartOne[5]);
                        }

                        // 5) prints out next part of the array
                        Console.WriteLine(PartOne[6]);

                        break;
                    
                    // part two
                    case 2:

                        Console.WriteLine(PartTwo[0]);
                        Console.Write("Enter your choice: ");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        input = Console.ReadLine();
                        input = input.ToUpper();
                        Console.ResetColor();

                        if (input == "A")
                        {
                            Console.WriteLine(PartTwo[1]);
                        }
                        else
                        {
                            Console.WriteLine(PartTwo[2]);
                        }

                        Console.WriteLine(PartTwo[3]);

                        if (input == "A")
                        {
                            Console.WriteLine(PartTwo[4]);
                        }
                        else
                        {
                            Console.WriteLine(PartTwo[5]);
                        }

                        Console.WriteLine(PartTwo[6]);

                        break;

                    // part three
                    case 3:

                        Console.WriteLine(PartThree[0]);
                        Console.Write("Enter your choice: ");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        input = Console.ReadLine();
                        input = input.ToUpper();
                        Console.ResetColor();

                        if (input == "A")
                        {
                            Console.WriteLine(PartThree[1]);
                            //adding item to player's inventory list
                            Inventory.Add("Battle Axe");
                        }
                        else
                        {
                            Console.WriteLine(PartThree[2]);
                            //adding item to player's inventory list
                            Inventory.Add("Parasol");
                        }

                        // player receives a random item from the Item class, then it's added to inventory
                        Console.WriteLine("What's this? There's something else in here...");
                        Item randomItem1 = new Item();
                        Inventory.Add(randomItem1.Name);

                        Console.WriteLine(PartThree[3]);

                        if (input == "A")
                        {
                            Console.WriteLine(PartThree[4]);
                        }
                        else
                        {
                            Console.WriteLine(PartThree[5]);
                        }

                        Console.WriteLine(PartThree[6]);

                        break;
                }

                // lets the player advance when ready, then clears the screen
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // prints end of game text and player inventory list
        public static void EndGame()
        {
            string ExitString =
            "It's time for the final showdown! You swing your trusty weapon at the first guard, cutting him down.\n" +
            "The second guard is a bit tougher and parries your blow, but he leaves himself open after a deflection.\n" +
            "You swing and stab him in the side. He cries out and crumples to the floor.\n" +
            "You push the heavy doors askew and feel a cool breeze on your face. Freedom!";

            Console.WriteLine(ExitString);
            Console.WriteLine($"Congratulations, {CharacterName}!");

            // prints out the player's inventory of "found" items
            Console.WriteLine("You found some items during your quest.");
            foreach (string item in Inventory)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(item);
                Console.ResetColor();
            }

            // if player finds an objective item, congratulate them, otherwise tell them they didn't find it
            if (Inventory.Contains("Key"))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Contratulations! You accomplished your goal. You found the key!");
                Console.ResetColor();
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You didn't find the key... better luck next time!");
                Console.ResetColor();
            }

            Console.WriteLine("Press any key to exit the game.");
        }
    }

    // class generates random items and their descriptions for the player to find
    public class Item
    {
        // setting default item as dungeon dirt
        public string Name = "dungeon dirt";
        public string Description = "nothing special";

        // initializing array of items and their descriptions
        string[] Items = { "troll tooth", "dead rat", "ball and chain" };
        string[] Descriptions = { "someone's missing this", "mmm, tasty", "the usual dungeon fare" };

        // adding a constructor to initialize random Name and Description values
        public Item()
        {
            // instantiating an object of the Random class
            Random randomNumber = new Random();

            // setting variable 'number' equal to a random number between and array length to match the number of items in Items[]
            int number = randomNumber.Next(Items.Length);

            // selecting a random item name and description from the arrays
            Name = Items[number];
            Description = Descriptions[number];
            Console.WriteLine("\nYou found a " + Name + " (" + Description + ").\n");
        }
            
    }

    // main class where the game is run
    class Program
    {
        static void Main()
        {
            Game.StartGame();
            //Console.ReadKey(); - don't need this on mac
        }
    }
}
