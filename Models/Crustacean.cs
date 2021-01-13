using System;
using System.Collections.Generic;
using HackAThonSpaceCrabsInSpace.Models;
using System.Linq;
using HackAThonSpaceCrabsInSpace.Interfaces;

namespace HackAThonSpaceCrabsInSpace.Models
{
    public abstract class Crustacean : IFighter
    {
        public static Random rand = new Random();

        public string Name { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
        protected int health;

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public string GetInfo()
        {
            return $"{Name} is an Ally\nHealth: {Health}\nStrength: {Strength}Intelligence: {Intelligence}\nDexterity?: {Dexterity}";

        }
        public Crustacean(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }

        public Crustacean(string name, int str, int intel, int dex, int hp)
        {
            Name = name;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            health = hp;
        }

        // Build Attack method
        public virtual int Attack(Astronaut target)
        {
            int dmg = Strength * 3;
            target.TakeDamage(dmg);
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
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
        public virtual void Swipe(List<Astronaut> targets)
        {
            int dmg = Strength * (new Random().Next(1, 3));
            int totSwipe = 0;
            foreach (var enemy in targets)
            {
                totSwipe += dmg;
                enemy.TakeDamage(dmg);
            }
            Console.WriteLine($"All astronauts have been slapped by {Name}'s tail for {dmg} damage!\nTotal damage to {targets}: {totSwipe}");
        }
        public virtual void Pounce(Astronaut target)
        {

            int dmg = 300;
            int TwentyPercentChance = rand.Next(1, 11);
            if (TwentyPercentChance <= 2)
            {
                target.TakeDamage(dmg);
                Console.WriteLine($"{Name} leaps high into the air and lands on {target.Name} for {dmg} damage!");
            }
            else
            {
                Console.WriteLine($"{Name} leaps high into the air attempts to land on {target.Name} but {target.Name} dodges just in time!");
            }
        }
    }
}