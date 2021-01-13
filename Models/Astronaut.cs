using System;
using System.Collections.Generic;

using HackAThonSpaceCrabsInSpace.Interfaces;
namespace HackAThonSpaceCrabsInSpace.Models

{
    public abstract class Astronaut : IFighter
    {
                public Random rand = new Random();

        public string Name { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
        protected int health;

        public int Health
        {
            get { return health; } 
            set { health = value;}
            
        }

        public string GetInfo()
        {
            return $"{Name} is an Ally\nHealth: {Health}\nStrength: {Strength}Intelligence: {Intelligence}\nDexterity?: {Dexterity}";

        }
        public Astronaut(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }

        public Astronaut(string name, int str, int intel, int dex, int hp)
        {
            Name = name;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            health = hp;
        }

        // Build Attack method
        public virtual int Attack(Crustacean target)
        {
            int dmg = Strength * 3;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            target.TakeDamage(dmg);
            return target.Health;
        }
        public int TakeDamage(int damage)
        {
            health -= damage;
            return health;
        }
        public void getStats()
        {
            Console.WriteLine($"\n{Name}'s Stats:\nHealth: {health}\nStrength: {Strength}\nIntelligence: {Intelligence}\nDexterity: {Dexterity}\n");
        }
        public virtual int Heal(Astronaut target)
        {
            int heal = Intelligence * (new Random().Next(1,5));
            target.TakeDamage(heal * -1);
            Console.WriteLine($"{Name} has healed {target.Name} for {heal}");
            return target.Health;
        }
            public virtual int ThrowBanana(Crustacean target)
        {
            int banana_throw = Dexterity * (rand.Next(1, 5));
            Console.WriteLine($"{target.Name} has been pierced by {Name}'s banana for {banana_throw} damage!");
            target.TakeDamage(banana_throw);
            int dmg = 0;
            int TwentyPercentChance = rand.Next(1, 11);
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
                public virtual void Barks(List<Crustacean> targets)
        {
            int dmg = Strength * (rand.Next(1,5));
            int totBark = 0;
            foreach(var enemy in targets)
            {
                totBark += dmg;
                enemy.TakeDamage(dmg);
            }
            Console.WriteLine($"All crustaceans have been deafened the by {Name}'s bark for {dmg} damage!\nTotal damage to {targets}: {totBark}");
        }
    }
}