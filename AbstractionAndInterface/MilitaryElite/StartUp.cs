using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, ISoldier> soldiersById = new Dictionary<string, ISoldier>();
            while (true)
            {

                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] parts = line.Split();

                string type = parts[0];
                string id = parts[1];
                string firstName = parts[2];
                string lastName = parts[3];


                //•	Private: "Private <id> <firstName> <lastName> <salary>"
                if (type == nameof(Private))
                {
                    decimal salary = decimal.Parse(parts[4]);
                    soldiersById[id] = new Private(id,firstName,lastName,salary);
                }

                //•	LeutenantGeneral: "LieutenantGeneral <id> <firstName> <lastName> <salary> 
                //<private1Id> <private2Id> … <privateNId>" where privateXId will always be an Id of a Private already received through the input.
                else if (type == nameof(LieutenantGeneral))
                {
                    decimal salary = decimal.Parse(parts[4]);
                    ILieutenantGeneral leutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);
                    for (int i = 5; i < parts.Length; i++)
                    {
                        string privateId = parts[i];
                       if(!soldiersById.ContainsKey(privateId))
                        {
                            continue;
                        }
                    leutenantGeneral.AddPrivate((IPrivate)soldiersById[privateId]);  // иска IPrivate  и го кастваме
                    }



                    soldiersById[id] =leutenantGeneral;
                }

                //•	Engineer: "Engineer <id> <firstName> <lastName> <salary> <corps> <repair1Part> <repair1Hours> … <repairNPart> <repairNHours>" where repairXPart is the name of a repaired part and repairXHours the hours it took to repair it(the two parameters will always come paired).
                else if (type == nameof(Engineer))
                {
                    decimal salary = decimal.Parse(parts[4]);
                 bool isCorpsValid = Enum.TryParse(parts[5], out Corps corps); // после ползваме директно corps v инит на Енгинера

                    if(!isCorpsValid)
                    {
                        continue;
                    }
                    IEngineer engineer = new Engineer(id,firstName,lastName,salary,corps); // corps go vzema ot enum 3 reda po nagore

                    for (int i = 6; i < parts.Length; i+=2)
                    {
                        string repairPart = parts[i];
                        int hoursWorked = int.Parse(parts[i+1]);

                        IRepair repair = new Repair(repairPart, hoursWorked);

                        engineer.AddRepair(repair);
                    }
                    soldiersById[id] = engineer;
                }
                //•	Commando: "Commando <id> <firstName> <lastName> <salary> <corps> 
                //<mission1CodeName>  <mission1state> … <missionNCodeName> <missionNstate>" a missions code name, description and state will always come together.
                else if (type == nameof(Commando))
                {
                    decimal salary = decimal.Parse(parts[4]);
                     bool isCorpsValid = Enum.TryParse(parts[5], out Corps corps);
                    if (!isCorpsValid)
                    {
                        continue;
                    }
                    ICommando commando = new Commando(id, firstName, lastName, salary, corps);
                    for (int i = 6; i < parts.Length; i += 2)
                    {
                        string missionCodeName = parts[i];
                        string missionState = parts[i + 1];
                        bool isMissIonStateIsValid = Enum.TryParse(missionState, out MissionState missState);
                        if(!isMissIonStateIsValid)
                        {
                            continue;
                        }

                        IMission mission = new Mission(missionCodeName, missState);
                        commando.AddMission(mission);
                    }
                        soldiersById[id] = commando;
                }
                //•	Spy: "Spy <id> <firstName> <lastName> <codeNumber>"
                else if (type == nameof(Spy))
                {
                    int codeNumber = int.Parse(parts[4]);
                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);
                    soldiersById[id] = spy;
                 }

            }

            foreach (var soldier in soldiersById.Values)
            {
                Console.WriteLine(soldier);
            }
        }

    }
}
