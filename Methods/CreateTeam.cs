using System;
using System.Collections.Generic;
using HackAThonSpaceCrabsInSpace.Models;
using System.Linq;
namespace HackAThonSpaceCrabsInSpace.Models
{
    public class Team
    {
        public static List<Astronaut> Allies = new List<Astronaut>();

        public static void Begin()
        {

            Console.WriteLine("\n\n\n\n\n\nWelcome,");
            Console.WriteLine("This is supposed to be a three player game (allegedly), but if you would like to add more or less please type now or forever hold your peace.\n");
            Console.WriteLine("Enter a value of how many allies you would like (1-3) or if you're feeling upto it type a 0");
            int numOfAllies = Convert.ToInt32(Console.ReadLine());
            while ((numOfAllies > 3 || numOfAllies < 0))
            {
                Console.WriteLine("Well someone can't read.. Let's try this again.. Enter a number 0-3");
                numOfAllies = Convert.ToInt32(Console.ReadLine());
            }
            if (numOfAllies > 1 && numOfAllies <= 3)
            {
                Console.WriteLine($"You've chosen to have {numOfAllies} join you in this grueling quest. 1(you) + {numOfAllies}(allies) = {1 + numOfAllies}(Allies that will fight to determine their fate.) MATH!");
            }
            if (numOfAllies == 0)
            {
                Console.WriteLine("I've underestimated you.. You're riding solo, *In a duke nukem voice* YOU'VE GOT BALLS OF STEEL!");
            }
            if (numOfAllies == 1)
            {
                Console.WriteLine($"\n\nYou've chosen to have only {numOfAllies} ally to join you. \n*Bill Withers soulfully singing* \nJust the two of us, We can make it if we try, Just the two of us... You and I");
            }

            for (var i = 0; i < numOfAllies + 1; i++)
            {
                Console.WriteLine($"What shall we call you player {i + 1}?");
                string inputName = Console.ReadLine();
                while (inputName.Length < 2)
                {
                    if (inputName.Length < 2 && inputName.Length > 0)
                    {
                        Console.WriteLine($"Alright {inputName}(this is what you typed in): Humor me... name one person you know with a 1 letter name... \nOR, input your actual name");
                        inputName = Console.ReadLine();
                    }

                    if (inputName.Length == 0)
                    {
                        Console.WriteLine("Hmmm. We got a wise guy here ladies and genetleman.Alright Mr(s). No Name.. Name one person without a name.... Get it? It's not possible.\nTry again: Input your NAME");
                        inputName = Console.ReadLine();
                    }
                }
                Console.WriteLine($"Welcome, {inputName}");
                Console.WriteLine($"{inputName} Please type the number of the class you would like to embody.\n1 : Human\n2 : Monkey\n3 : Dog");
                int classChoice = Convert.ToInt32(Console.ReadLine());
                switch (classChoice, i)
                {
                    case (1, 0):
                        Console.WriteLine("You have chosen Human");
                        Human w0 = new Human($"{inputName}");
                        Allies.Add(w0);
                        break;
                    case (2, 0):
                        Console.WriteLine("You have chosen Monkey");
                        Monkey n0 = new Monkey($"{inputName}");
                        Allies.Add(n0);
                        break;
                    case (3, 0):
                        Console.WriteLine("You have chosen Dog");
                        Dog s0 = new Dog($"{inputName}");
                        Allies.Add(s0);
                        break;
                    case (1, 1):
                        Console.WriteLine("You have chosen Human");
                        Human w1 = new Human($"{inputName}");
                        Allies.Add(w1);
                        break;
                    case (2, 1):
                        Console.WriteLine("You have chosen Monkey");
                        Monkey n1 = new Monkey($"{inputName}");
                        Allies.Add(n1);
                        break;
                    case (3, 1):
                        Console.WriteLine("You have chosen Dog");
                        Dog s1 = new Dog($"{inputName}");
                        Allies.Add(s1);
                        break;
                    case (1, 2):
                        Console.WriteLine("You have chosen Human");
                        Human w2 = new Human($"{inputName}");
                        Allies.Add(w2);
                        break;
                    case (2, 2):
                        Console.WriteLine("You have chosen Monkey");
                        Monkey n2 = new Monkey($"{inputName}");
                        Allies.Add(n2);
                        break;
                    case (3, 2):
                        Console.WriteLine("You have chosen Dog");
                        Dog s2 = new Dog($"{inputName}");
                        Allies.Add(s2);
                        break;
                    case (1, 3):
                        Console.WriteLine("You have chosen Human");
                        Human w3 = new Human($"{inputName}");
                        Allies.Add(w3);
                        break;
                    case (2, 3):
                        Console.WriteLine("You have chosen Monkey");
                        Monkey n3 = new Monkey($"{inputName}");
                        Allies.Add(n3);
                        break;
                    case (3, 3):
                        Console.WriteLine("You have chosen Dog");
                        Dog s3 = new Dog($"{inputName}");
                        Allies.Add(s3);
                        break;
                };
                if (numOfAllies != i)
                {
                    Console.WriteLine("\nNext victim, I meant next ally! \n");
                }
            }
            Console.WriteLine("This is your team... Looking at the lineup. All I have to say is goodluck.");
            foreach (var ally in Allies)
            {
                Console.WriteLine($"{ally.Name}");
            }
            Console.WriteLine("If you want to see your team's stats: enter 1, otherwise enter any key");
            string GetTeamStats = Console.ReadLine();
            if (GetTeamStats == "1")
            {
                foreach (var ally in Allies)
                {
                    ally.getStats();
                }
            }
        }
    }
}