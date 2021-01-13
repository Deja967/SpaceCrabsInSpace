using System;
using System.Collections.Generic;
using HackAThonSpaceCrabsInSpace.Models;
using System.Linq;
using HackAThonSpaceCrabsInSpace.Methods;


namespace HackAThonSpaceCrabsInSpace
{
    class Program
    {
        public static List<Astronaut> DeadAllies = new List<Astronaut>();
        public static List<Crustacean> DeadFloor1 = new List<Crustacean>();
        public static List<Crustacean> DeadFloor2 = new List<Crustacean>();
        public static List<Crustacean> DeadFloor3 = new List<Crustacean>();

        public static void ListEnemies(List<Crustacean> Team)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;

            foreach (var enemy in Team)
            {
                Console.WriteLine($"{enemy.Name}");
            }
            Console.ResetColor();

        }
        public static void ListAllies(List<Astronaut> Team)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            foreach (var ally in Team)
            {
                Console.WriteLine($"{ally.Name}");
            }
            Console.ResetColor();
        }


        public static List<Crustacean> Floor1 = new List<Crustacean>(){
            new Shrimp("Bob"),
            new Shrimp("Jim"),
            new Shrimp("Greg"),
            new Shrimp("Harold"),
            new Shrimp("Fred"),
            new Shrimp("Bart"),
            new Shrimp("Karen"),
            new Shrimp("Ed"),
        };

        public static List<Crustacean> Floor2 = new List<Crustacean>(){
            new Lobster("Larry"),
            new Lobster("Elvis"),
            new Lobster("Mike"),
        };

        public static List<Crustacean> Floor3 = new List<Crustacean>(){
            new Crab("Mr. Crabs"),
            new Shrimp("Kevin"),
            new Shrimp("Barbara")
        };

        static void Main(string[] args)
        {
            Team.Begin();
            string break1 = Console.ReadLine();
            Console.WriteLine("You and your team have just crash-landed on the beach of the distant planet of KRUS Station");
            Console.WriteLine("Looking around you see nothing but ocean and beach, with a forest in front of you.\nIn the distance you see a giant skyscraper towering over the landscape.\nFrom this distance you can just make out the name at the top: Crustaceans and Crabs Corporation, LLC");
            Console.WriteLine("With nowhere else to go, you make your way to the base of the skyscraper");
            Console.WriteLine("\nProceed?(y/n)");
            string break2 = Console.ReadLine();
            if(break2 =="n")
            {
                Console.WriteLine("You starve to death on the beach\nType dotnet run to play again.");
                Environment.Exit(0);
            }
            Console.WriteLine($"You enter the building and are immediately accosted by a group of business shrimp.\nOver the intercom: 'Do you have an appointment?\nFirst Floor employees all scurry and yell: 'You may not enter without an appointment!'");
            string break8 = Console.ReadLine();
            ListAllies(Team.Allies);
            Console.WriteLine("\nVS\n");
            ListEnemies(Floor1);
            Battle.Start(Team.Allies, Floor1, DeadFloor1, DeadAllies);
            Battle.post1(Team.Allies, Floor1, DeadFloor1, DeadAllies);
            Console.WriteLine("You've made it out alive and you notice an elevator door open.\nEnter? (y/n)\n");
            string break3 = Console.ReadLine();
            if(break3 == "n")
            {
                Console.WriteLine("You exit the building and glance back and notice a confused giant crab looking at you from the top floor.\nThen you die on the beach from starvation.");
                Console.WriteLine("Fin.\ntype dotnet run to play again.");
                Environment.Exit(0);
            }
            Console.WriteLine("\nAs you exit the elevator, you run right into a pack of smug-looking lobsters. \n'Are you here to work overtime? Second Floor employees rudely ask \n'You must keep working for the good of the corporation!'");
            string break9 = Console.ReadLine();
            ListAllies(Team.Allies);
            Console.WriteLine("\nVS\n");
            ListEnemies(Floor2);
            Battle.Start(Team.Allies, Floor2, DeadFloor2, DeadAllies);
            Battle.post2(Team.Allies,Floor2, DeadFloor2, DeadAllies,DeadFloor1);
            Console.WriteLine("Weekend Workaholics can't stop you!");
            string break4 = Console.ReadLine();
            Console.WriteLine("As you approach the main office, the air starts to chill.  Up ahead you see a sign, 'The thermostat must always be set to 63 degrees per Mr. Krabs!'");
            Console.WriteLine("The thermostat currently reads 63, do you change it higher or lower?");
            string break5 = Console.ReadLine();
            Console.WriteLine("'HOW DARE YOU TOUCH THE THERMOSTAT!' you hear from inside the main office");
            string break6 = Console.ReadLine();
            Console.WriteLine($"The doors burst open and out bursts an enormous Alaskan King Crab wearing a 3-piece suit followed by two harried-looking shrimps, {Floor3[1].Name} & {Floor3[2].Name}");
            Console.WriteLine($"{Floor3[0].Name}: 'You'll be paying for that in overtime for the next 6 months!'");
            string break7 = Console.ReadLine();
            ListAllies(Team.Allies);
            Console.WriteLine("\nVS\n");
            ListEnemies(Floor3);
            Battle.Start(Team.Allies, Floor3, DeadFloor3, DeadAllies);
            Console.WriteLine($"You have defeated the Crustaceans and Crabs Corporation, LLC!");
            Console.WriteLine("With the way cleared, you are able to call for help and are able to safely escape KRUS Station\nFin.\nType dotnet run to play again.");
        }
    }
}
