using System;
using System.Collections.Generic;

namespace PlayersAndMonsters
{
    public class StartUp
    {
      public  static void Main(string[] args)
        {
            var knight = new BladeKnight("Duman", 100);

            var soulMaster = new SoulMaster("Soul", 180);

            List<Hero> list = new List<Hero>();

            list.Add(knight);
            list.Add(soulMaster);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
