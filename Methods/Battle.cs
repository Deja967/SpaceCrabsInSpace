using System;
using System.Collections.Generic;
using System.Linq;
using HackAThonSpaceCrabsInSpace.Models;


namespace HackAThonSpaceCrabsInSpace.Methods
{
    public class Battle
    {
        static Random rand = new Random();
        public static void Start(List<Astronaut> allies, List<Crustacean> enemies, List<Crustacean> deadEnemies, List<Astronaut> deadAllies)
        {
            Console.WriteLine($"{enemies.Count} crustaceans have appeared and they are crabby!");
            while (!allies.All(a => a.Health <= 0) && allies.Count > 0 && enemies.Count > 0 || !enemies.All(a => a.Health <= 0) && allies.Count > 0 && enemies.Count > 0)
            {
                if (allies.Count > 0 && enemies.Count != 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("\nAllies:\n");
                    foreach (var ally in allies)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                        int whichEnemy = rand.Next(0, enemies.Count);
                        // ally.getStats();
                        if (enemies.Count > 0 && ally.Health > 0)
                        {
                            Console.WriteLine($"{ally.Name} What would you like to use?");
                            if (ally is Human)
                            {
                                Console.WriteLine("\n1:Attack\n2:Heal");
                                int attackMethod = Convert.ToInt32(Console.ReadLine());
                                if (attackMethod == 1)
                                {
                                    ally.Attack(enemies[whichEnemy]);
                                    if (enemies[whichEnemy].Health <= 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;

                                        Console.WriteLine($"\n{enemies[whichEnemy].Name} was added to the army of the dead.\n");
                                        deadEnemies.Add(enemies[whichEnemy]);
                                        enemies.Remove(enemies[whichEnemy]);
                                        Console.ResetColor();
                                    }
                                    Console.ResetColor();
                                }
                                if (attackMethod == 2)
                                {
                                    int pos = 0;
                                    foreach (var checkHealth in allies)
                                    {
                                        Console.WriteLine($"{pos}:{checkHealth.Name}'s health is {checkHealth.Health}");
                                        pos++;
                                    }
                                    int chooseHeal = Convert.ToInt32(Console.ReadLine());
                                    switch (chooseHeal)
                                    {
                                        case 0:
                                            ally.Heal(allies[0]);
                                            break;
                                        case 1:
                                            ally.Heal(allies[1]);
                                            break;
                                        case 2:
                                            ally.Heal(allies[2]);
                                            break;
                                        case 3:
                                            ally.Heal(allies[3]);
                                            break;
                                    }
                                }
                            }
                            if (ally is Monkey)
                            {
                                Console.WriteLine("\n1:Attack\n2:Throw Banana");
                                int attackMethod = Convert.ToInt32(Console.ReadLine());
                                if (attackMethod == 1)
                                {
                                    ally.Attack(enemies[whichEnemy]);
                                    if (enemies[whichEnemy].Health <= 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;

                                        Console.WriteLine($"\n{enemies[whichEnemy].Name} was added to the army of the dead.\n");
                                        deadEnemies.Add(enemies[whichEnemy]);
                                        enemies.Remove(enemies[whichEnemy]);
                                        Console.ResetColor();
                                    }
                                }
                                if (attackMethod == 2)
                                {
                                    ally.ThrowBanana(enemies[whichEnemy]);
                                    if (enemies[whichEnemy].Health <= 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;

                                        Console.WriteLine($"\n{enemies[whichEnemy].Name} was added to the army of the dead.\n");
                                        deadEnemies.Add(enemies[whichEnemy]);
                                        enemies.Remove(enemies[whichEnemy]);
                                        Console.ResetColor();
                                    }
                                }
                            }
                            if (ally is Dog)
                            {
                                Console.WriteLine("\n1:Attack\n2:Bark");
                                int attackMethod = Convert.ToInt32(Console.ReadLine());
                                if (attackMethod == 1)
                                {
                                    ally.Attack(enemies[whichEnemy]);
                                    if (enemies[whichEnemy].Health <= 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;

                                        Console.WriteLine($"\n{enemies[whichEnemy].Name} was added to the army of the dead.\n");
                                        deadEnemies.Add(enemies[whichEnemy]);
                                        enemies.Remove(enemies[whichEnemy]);
                                        Console.ResetColor();
                                    }
                                }
                                if (attackMethod == 2)
                                {
                                    ally.Barks(enemies);
                                    List<Crustacean> loggingTheNames = enemies.Where(e => e.Health <= 0).ToList();
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;

                                    foreach (var dead in loggingTheNames)
                                    {
                                        Console.WriteLine($"\n{dead.Name} was added to the army of the dead.\n");

                                    }
                                    deadEnemies.AddRange(enemies.Where(e => e.Health <= 0).ToList());
                                    enemies = enemies.Where(e => e.Health > 0).ToList();
                                    Console.ResetColor();
                                }
                                Console.ResetColor();

                            }

                        }
                    }
                    Console.ResetColor();
                }
                if (allies.Count != 0 && enemies.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;

                    Console.Write("\nEnemies:\n");
                    foreach (var enemy in enemies)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;

                        int whichAlly = rand.Next(0, allies.Count);
                        // enemy.getStats();
                        if (allies.Count > 0 && enemy.Health > 0)
                        {
                            if (enemy is Lobster)
                            {
                                int chance = new Random().Next(1, 4);
                                if (chance == 1)
                                {
                                    enemy.Swipe(allies);
                                    List<Astronaut> loggingTheNames = allies.Where(e => e.Health <= 0).ToList();
                                    foreach (var dead in loggingTheNames)
                                    {
                                        Console.WriteLine($"\n{dead.Name} was added to the army of the dead.\n");
                                    }
                                    deadAllies.AddRange(allies.Where(e => e.Health <= 0).ToList());
                                    allies = allies.Where(e => e.Health > 0).ToList();
                                }
                                else
                                {
                                    enemy.Attack(allies[whichAlly]);
                                    if (allies[whichAlly].Health <= 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.WriteLine($"\n{allies[whichAlly].Name} was added to the army of the dead.\n");
                                        deadAllies.Add(allies[whichAlly]);
                                        allies.Remove(allies[whichAlly]);
                                        Console.ResetColor();
                                    }
                                }
                            }
                            else if (enemy is Crab)
                            {
                                int leap = new Random().Next(1, 5);
                                if (leap == 1)
                                {
                                    enemy.Pounce(allies[whichAlly]);
                                    if (allies[whichAlly].Health <= 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.WriteLine($"\n{allies[whichAlly].Name} was added to the army of the dead.\n");
                                        deadAllies.Add(allies[whichAlly]);
                                        allies.Remove(allies[whichAlly]);
                                        Console.ResetColor();
                                    }
                                }
                                else
                                {
                                    enemy.Attack(allies[whichAlly]);
                                    if (allies[whichAlly].Health <= 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.WriteLine($"\n{allies[whichAlly].Name} was added to the army of the dead.\n");
                                        deadAllies.Add(allies[whichAlly]);
                                        allies.Remove(allies[whichAlly]);
                                        Console.ResetColor();
                                    }
                                }
                            }
                            else
                            {
                                enemy.Attack(allies[whichAlly]);
                                if (allies[whichAlly].Health <= 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine($"\n{allies[whichAlly].Name} was added to the army of the dead.\n");
                                    deadAllies.Add(allies[whichAlly]);
                                    allies.Remove(allies[whichAlly]);
                                    Console.ResetColor();
                                }
                            }

                            }
                        }
                        Console.ResetColor();
                    }
                }
            }
        
            public static void post1(List<Astronaut> l1, List<Crustacean> l2, List<Crustacean> l3, List<Astronaut> l4)
            {

                Console.WriteLine("\nThe battle has finished..");
                if (l4.Count > 0)
                {
                    Console.WriteLine("Fatalities for the allies include:");
                    foreach (var DeadAlly in l4)
                    {
                        Console.WriteLine($"{DeadAlly.Name}");
                    }
                }
                if (l4.Count == 0)
                {
                    Console.WriteLine("Surprisingly no allies have died.");
                }
                if (l3.Count > 0)
                {

                    Console.WriteLine("Fatalities for the enemies include:");
                    foreach (var DeadEnemy in l3)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;

                        Console.WriteLine($"{DeadEnemy.Name}");
                        Console.ResetColor();
                    }
                }
                if (l3.Count == 0)
                {
                    Console.WriteLine("How embarrassing. You didn't manage to kill a single Enemy!");
                }
                if (l1.Count == 0)
                {
                    Console.WriteLine("\nAll Allies have been slain.\n\nGame over. Type `dotnet run` to play again");
                }
                if (l1.Count > 0)
                {
                    Console.WriteLine($"You made it through the first stage with {l1.Count} allies remaining!\n\nTo check current stats and proceed type 1.");
                    string proceed1 = Console.ReadLine();
                    while (proceed1 != "1")
                    {
                        Console.WriteLine("Just press 1, why drag your death out any further.");
                        proceed1 = Console.ReadLine();
                    }

                    if (proceed1 == "1")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                        foreach (var Ally in l1)
                        {
                            Console.WriteLine($"{Ally.Name} has {Ally.Health} Health remaining.");
                        }
                        Console.ResetColor();

                    }
                }
            }
            public static void post2(List<Astronaut> l1, List<Crustacean> l2, List<Crustacean> l3, List<Astronaut> l4, List<Crustacean> l5)
            {
                Console.WriteLine("\nThe battle has finished..");
                if (l4.Count > 0)
                {
                    Console.WriteLine("Fatalities for the allies include:");
                    foreach (var DeadAlly in l4)
                    {
                        Console.WriteLine($"{DeadAlly.Name}");
                    }
                }
                if (l4.Count == 0)
                {
                    Console.WriteLine("Surprisingly no allies have died.");
                }
                if (l3.Count > 0)
                {
                    Console.WriteLine("Fatalities for the enemies include:");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    foreach (var DeadEnemy in l3)
                    {
                        Console.WriteLine($"{DeadEnemy.Name}");
                    }
                    Console.ResetColor();
                }
                if (l3.Count == 0)
                {
                    Console.WriteLine("How embarrassing. You didn't manage to kill a single Enemy!");
                }
                if (l1.Count == 0)
                {
                    Console.WriteLine("\n\n\nGame over. Type `dotnet run` to play again");
                    return;
                }
                if (l1.Count > 0)
                {
                    Console.WriteLine($"You made it through the Second stage with {l1.Count} allies remaining!\n\nTo check current stats and proceed type 1.");
                    string proceed1 = Console.ReadLine();
                    while (proceed1 != "1")
                    {
                        Console.WriteLine("Why would you go off script when you're already this far in?");
                        proceed1 = Console.ReadLine();
                    }

                    if (proceed1 == "1")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine($"The K/D Ratio of this group is:  {l3.Count + l5.Count} : {l4.Count}");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        foreach (var Ally in l1)
                        {
                            Console.WriteLine($"{Ally.Name} has {Ally.Health} Health remaining.");
                        }
                        Console.ResetColor();

                    }
                }
            }
        }
    }
