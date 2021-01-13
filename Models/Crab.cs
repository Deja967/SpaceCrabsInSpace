using System;
namespace HackAThonSpaceCrabsInSpace.Models
{
    public class Crab : Crustacean

    {
        
        public Crab(string name) : base(name)
        {
            health = 1000;
        }
        public override int Attack(Astronaut target)
        {
            int dmg = 10 * Dexterity;
            target.TakeDamage(dmg);
            Console.WriteLine($"{Name} crushes {target.Name} with their claws for {dmg} damage!");
            if (target.Health <= 0)
            {
                Console.WriteLine($"{Name} has defeated {target.Name}");
                Console.WriteLine($"{Name}: 'And that's why Krabs is King'");
            }
            return target.Health;
        }

        public override void Pounce(Astronaut target){
            
            int dmg = 300;
            int TwentyPercentChance = rand.Next(1, 11);
            if (TwentyPercentChance <= 2)
            {
            target.TakeDamage(dmg);
            Console.WriteLine($"{Name} leaps high into the air and lands on {target.Name} for {dmg} damage!");
            } else {
            Console.WriteLine($"{Name} leaps high into the air attempts to land on {target.Name} but {target.Name} dodges just in time!");
            }
        }
    }
}