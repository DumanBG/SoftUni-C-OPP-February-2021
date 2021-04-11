using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        public static void Main()
        {

            int players = int.Parse(Console.ReadLine());
            Dictionary<string, BaseHero> heroes = new Dictionary<string, BaseHero>();
            while(heroes.Count <players)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                BaseHero hero = CreateHero(type, name);
                if(hero == null)
                {
                    Console.WriteLine("Invalid hero!");
                    
                }
                else
                {
                    heroes.Add(name, hero);

                }

            }
            int bossPoints = int.Parse(Console.ReadLine());
            int raidPoints = 0;
            if (heroes.Any())
            {
                foreach (var hero in heroes.Values)
                {
                    string ability = hero.CastAbility();
                    Console.WriteLine(ability);
                    raidPoints += hero.Power;
                }
            }
            if(raidPoints >= bossPoints)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private static BaseHero CreateHero(string type, string name)
        {
            BaseHero hero = null;
            if (type == nameof(Paladin))
            {
               hero = new Paladin(name);
               
            }
            else if (type == nameof(Druid))
            {
              hero = new Druid(name);
                
            }
            else if (type == nameof(Warrior))
            {
               hero = new Warrior(name);
                
            }
            else if (type == nameof(Rogue))
            {
               hero = new Rogue(name);
           
            }
            
            return hero;
        }
    }
}
