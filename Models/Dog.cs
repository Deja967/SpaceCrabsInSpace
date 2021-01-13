using System;
using System.Collections.Generic;

namespace HackAThonSpaceCrabsInSpace.Models
{
    public class Dog : Astronaut
    {
        public Dog(string name) : base(name)
        {
            Strength = 20;
            health = 200;
        }
        public override int Attack(Crustacean target)
        {
            int dmg = Strength * 2;
            Console.WriteLine($"{Name} runs up and bites {target.Name} for {dmg} damage!");
            target.TakeDamage(dmg);
            if (target.Health <= 0)
            {
                Console.WriteLine($"{Name} has defeated {target.Name}");
            }
            
            return target.Health;
        }
        public override void Barks(List<Crustacean> targets)
        {
            int dmg = Strength;
            int totBark = 0;
            foreach(var enemy in targets)
            {
                totBark += dmg;
                enemy.TakeDamage(dmg);
            }
            Console.WriteLine($"All crustaceans have been deafened the by {Name}'s bark for {dmg} damage!\nTotal damage to all enemies: {totBark}");
        }
    }
}
