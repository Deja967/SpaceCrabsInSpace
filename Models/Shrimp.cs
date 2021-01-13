using System;
using System.Collections.Generic;
using HackAThonSpaceCrabsInSpace.Models;
using System.Linq;
namespace HackAThonSpaceCrabsInSpace.Models
{
    public class Shrimp : Crustacean
{
            public Shrimp(string name) : base(name)
            {
                health = 50;
            }
            public override int Attack(Astronaut target)
            {
                int dmg = Dexterity;
                target.TakeDamage(dmg);
                Console.WriteLine($"{Name} tail whipped {target.Name} for {dmg} damage!");
                if (target.Health <= 0)
                {
                    Console.WriteLine($"{Name} has defeated {target.Name}");
                    Console.WriteLine($"{Name}: 'Who's the shrimp now?'");
                }
                return target.Health;
            }
        }
}