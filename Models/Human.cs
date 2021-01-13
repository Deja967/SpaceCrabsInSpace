using System;
using System.Collections.Generic;
namespace HackAThonSpaceCrabsInSpace.Models
{
    public class Human : Astronaut
    {
        public Human(string name) : base(name)
        {
            Intelligence = 20;
            health = 150;
        }
        public override int Attack(Crustacean target)
        {
            int dmg = Intelligence * 2;
            int TwentyPercentChance = rand.Next(1, 11);
            if (TwentyPercentChance <= 2)
            {
                dmg += 10;
                Console.WriteLine("as the french say... Bonus Damage.");
            }
            target.TakeDamage(dmg);
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            if (target.Health <= 0)
            {
                Console.WriteLine($"{Name} has defeated {target.Name}");
            }
            return target.Health;
        }
        public override int Heal(Astronaut target)
        {
            int heal = Intelligence * (new Random().Next(1,5));
            target.TakeDamage(heal * -1);
            Console.WriteLine($"{Name} has healed {target.Name} for {heal}");
            return target.Health;
        }
    }
}


