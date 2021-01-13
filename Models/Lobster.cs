using System;
using System.Collections.Generic;
namespace HackAThonSpaceCrabsInSpace.Models
{
    public class Lobster : Crustacean
    {
            public Lobster(string name) : base(name)
            {
                Strength = 10;
                health = 250;
            }
            public override int Attack(Astronaut target)
            {
                int dmg = Strength;
                target.TakeDamage(dmg);
                Console.WriteLine($"{Name} snapped at {target.Name} for {dmg} damage!");
                if (target.Health <= 0)
                {
                    Console.WriteLine($"{Name} has defeated {target.Name}");
                    Console.WriteLine($"{Name}: 'Seems pretty shellfish of you to not be coming in this Saturday'");
                }
                return target.Health;
            }

            public override void Swipe(List<Astronaut> targets)
            {
                int dmg = Strength * (new Random().Next(1,3));
                int totSwipe = 0;
                foreach(var enemy in targets)
                {
                    totSwipe += dmg;
                    enemy.TakeDamage(dmg);
                }
                Console.WriteLine($"All astronauts have been slapped by {Name}'s tail for {dmg} damage!\nTotal damage to astronauts: {totSwipe}");
            }
    }
}
