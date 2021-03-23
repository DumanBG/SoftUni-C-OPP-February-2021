using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            List<IIdentifiable> indentifiable = new List<IIdentifiable>();
            string input = Console.ReadLine();

            while(input != "End")
            {
                string[] token = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                
                if (token.Count() == 2)
                {
                   string model = token[0];
                 string   id = token[1];
                    indentifiable.Add(new Robot(id, model));
                }
                else if(token.Count() ==3)
                {
                    string name = token[0];
                  int  age =int.Parse(token[1]);
                 string   id = token[2];
                    indentifiable.Add(new Citizen(name, age, id));
                }


                input = Console.ReadLine();
            }
            string badEndId = Console.ReadLine();

            indentifiable.RemoveAll(x => !x.Id.EndsWith(badEndId));

            if (indentifiable.Any())
            {


                foreach (var item in indentifiable)
                {
                    Console.WriteLine(item.Id);
                }
            }
        }
    }
}
