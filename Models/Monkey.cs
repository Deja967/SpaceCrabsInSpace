using System;

namespace HackAThonSpaceCrabsInSpace.Models

{
    public class Monkey : Astronaut
    {
        public Monkey(string name) : base(name)
        {
            Dexterity = 20;
            health = 100;
        }
        public override int Attack(Crustacean target)
        {
            int dmg = Dexterity * 2;
            Console.WriteLine($"{Name} runs up and slaps {target.Name} for {dmg} damage!");
            target.TakeDamage(dmg);
            if (target.Health <= 0)
            {
                Console.WriteLine($"{Name} has defeated {target.Name}");
            }
            return target.Health;
        }
        public override int ThrowBanana(Crustacean target)
        {
            int banana_throw = Dexterity * (rand.Next(1, 5));
            Console.WriteLine($"{target.Name} has been pierced by {Name}'s banana for {banana_throw} damage!");
            target.TakeDamage(banana_throw);
            int dmg = 0;
            int TwentyPercentChance = rand.Next(1, 6);
            if (TwentyPercentChance <= 2)
            {
                dmg += 10;
                Console.WriteLine($"{target.Name} has slipped on the peel and took 10 extra damage.");
            }
            target.TakeDamage(dmg);
            if (target.Health <= 0)
            {
                Console.WriteLine($"{Name} has defeated {target.Name}");
            }
            return target.Health;
        }
    }
}