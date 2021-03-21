using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            try
            {
                Dictionary<string, Team> teamsByName = new Dictionary<string, Team>();


                while (true)
                {
                    string line = Console.ReadLine();
                    if (line == "END")
                    {
                        break;
                    }

                    string[] token = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
                    string command = token[0];
                    string currTeamName = token[1];
                    if (command == "Team")
                    {
                        Team createTeam = new Team(currTeamName);
                        teamsByName.Add(currTeamName, createTeam);
                    }


                    else if (command == "Rating")
                    {
                        if (!teamsByName.ContainsKey(currTeamName))
                        {
                            Console.WriteLine($"Team{currTeamName} does not exist.");
                            continue;
                        }
                        Team team = teamsByName[currTeamName];
                        Console.WriteLine($"{currTeamName} - {team.AverageRating}");
                    }

                    else if (command == "Add")
                    {
                        if (!teamsByName.ContainsKey(currTeamName))
                        {
                            Console.WriteLine($"Team{currTeamName} does not exist.");
                            continue;
                        }

                        string playerName = token[2];
                        Team team = teamsByName[currTeamName];
                        Player newPlayer = new Player(playerName, int.Parse(token[3]), int.Parse(token[4]), int.Parse(token[5]), int.Parse(token[6]), int.Parse(token[7]));
                        team.AddPlayer(newPlayer);
                    }


                    else if (command == "Remove")
                    {
                        string playerName = token[2];

                        Team team = teamsByName[currTeamName];
                        team.RemovePlayer(playerName);
                    }

                }
            }
            catch (Exception ex)
            when (ex is ArgumentException || ex is InvalidOperationException)
            {

                Console.WriteLine(ex.Message);
            }




        }
    }
}

