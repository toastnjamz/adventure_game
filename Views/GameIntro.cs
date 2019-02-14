using System;

namespace AdventureGame
{
    public static class GameIntro
    {
        // prints out ASCII title to the screen
        public static void WriteAsciiTitle()
        {
            string title = @"

 ███▄    █  ▒█████  ▄▄▄█████▓    ▄▄▄       ███▄    █  ▒█████  ▄▄▄█████▓ ██░ ██ ▓█████  ██▀███     
 ██ ▀█   █ ▒██▒  ██▒▓  ██▒ ▓▒   ▒████▄     ██ ▀█   █ ▒██▒  ██▒▓  ██▒ ▓▒▓██░ ██▒▓█   ▀ ▓██ ▒ ██▒   
▓██  ▀█ ██▒▒██░  ██▒▒ ▓██░ ▒░   ▒██  ▀█▄  ▓██  ▀█ ██▒▒██░  ██▒▒ ▓██░ ▒░▒██▀▀██░▒███   ▓██ ░▄█ ▒   
▓██▒  ▐▌██▒▒██   ██░░ ▓██▓ ░    ░██▄▄▄▄██ ▓██▒  ▐▌██▒▒██   ██░░ ▓██▓ ░ ░▓█ ░██ ▒▓█  ▄ ▒██▀▀█▄     
▒██░   ▓██░░ ████▓▒░  ▒██▒ ░     ▓█   ▓██▒▒██░   ▓██░░ ████▓▒░  ▒██▒ ░ ░▓█▒░██▓░▒████▒░██▓ ▒██▒   
░ ▒░   ▒ ▒ ░ ▒░▒░▒░   ▒ ░░       ▒▒   ▓▒█░░ ▒░   ▒ ▒ ░ ▒░▒░▒░   ▒ ░░    ▒ ░░▒░▒░░ ▒░ ░░ ▒▓ ░▒▓░   
░ ░░   ░ ▒░  ░ ▒ ▒░     ░         ▒   ▒▒ ░░ ░░   ░ ▒░  ░ ▒ ▒░     ░     ▒ ░▒░ ░ ░ ░  ░  ░▒ ░ ▒░   
   ░   ░ ░ ░ ░ ░ ▒    ░           ░   ▒      ░   ░ ░ ░ ░ ░ ▒    ░       ░  ░░ ░   ░     ░░   ░    
         ░     ░ ░                    ░  ░         ░     ░ ░            ░  ░  ░   ░  ░   ░        
                                                                                                  
▓█████▄  █    ██  ███▄    █   ▄████ ▓█████  ▒█████   ███▄    █  ▐██▌                              
▒██▀ ██▌ ██  ▓██▒ ██ ▀█   █  ██▒ ▀█▒▓█   ▀ ▒██▒  ██▒ ██ ▀█   █  ▐██▌                              
░██   █▌▓██  ▒██░▓██  ▀█ ██▒▒██░▄▄▄░▒███   ▒██░  ██▒▓██  ▀█ ██▒ ▐██▌                              
░▓█▄   ▌▓▓█  ░██░▓██▒  ▐▌██▒░▓█  ██▓▒▓█  ▄ ▒██   ██░▓██▒  ▐▌██▒ ▓██▒                              
░▒████▓ ▒▒█████▓ ▒██░   ▓██░░▒▓███▀▒░▒████▒░ ████▓▒░▒██░   ▓██░ ▒▄▄                               
 ▒▒▓  ▒ ░▒▓▒ ▒ ▒ ░ ▒░   ▒ ▒  ░▒   ▒ ░░ ▒░ ░░ ▒░▒░▒░ ░ ▒░   ▒ ▒  ░▀▀▒                              
 ░ ▒  ▒ ░░▒░ ░ ░ ░ ░░   ░ ▒░  ░   ░  ░ ░  ░  ░ ▒ ▒░ ░ ░░   ░ ▒░ ░  ░                              
 ░ ░  ░  ░░░ ░ ░    ░   ░ ░ ░ ░   ░    ░   ░ ░ ░ ▒     ░   ░ ░     ░                              
   ░       ░              ░       ░    ░  ░    ░ ░           ░  ░                                 
 ░ 
            ";

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(title);
            Console.WriteLine("Press enter to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void IntroText()
        {
            string IntroString =
                "You wake up in a cell in what looks like a dungeon after a night of dwarven debauchery.\n" +
                "One minute you were drinking ale with your clan-mates...\n" +
                "...The next you woke up here. Your head is pounding. Even your beard hurts.\n" +
                "You sure could use a hair of the hellhound. Time to find a way out!";

            Console.WriteLine(IntroString);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Type 'Help' for a list of options.");
            Console.WriteLine();
        }
    }
}
