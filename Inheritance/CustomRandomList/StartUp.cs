using System;

namespace CustomRandomList
{
    public class StartUp
    {
       public static void Main(string[] args)
        {



            RandomList<string> list = new RandomList<string>();

            list.Add("Duman");
            list.Add("Teodor");
            list.Add("Pesho");
            list.Add("Azar");
            list.Add("Mudan");


            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine(list.RandomString());
            }
            foreach (var item in list)
            {
                Console.WriteLine(list.RandomString());
            }
        }
    }
}
