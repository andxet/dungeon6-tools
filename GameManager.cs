using System;
using System.Diagnostics;

namespace Dungeon6tools
{
    public class GameManager
    {
        public string DungeonName { get; private set; }

        Random random;

        public GameManager()
        {
            random = new Random();
            DungeonName = GeneralData.DungeonName[RollDice6()] + GenerateName();
            Console.WriteLine("Created a new dungeon with name " + DungeonName + "!");
        }        

        public int RollDice6()
        {
            return random.Next(0, 6) + 1;
        }

        public string GenerateName()
        {
            string name = "";
            int nameLength = RollDice6() + 2;
            Debug.WriteLine("Generating name with lenght " + nameLength);
            int vocalsGenerated = 0;
            if (nameLength % 2 == 0)
            {
                name += GeneralData.VocalsDictionary[RollDice6() - 1];
                nameLength--;
            }

            for (; vocalsGenerated < nameLength; vocalsGenerated++)
            {
                if (vocalsGenerated % 2 == 1)
                    name += GeneralData.VocalsDictionary[RollDice6() - 1];
                else
                    name += GeneralData.ConsonantsDictionary[RollDice6() - 1, RollDice6() - 1];
            }
            return char.ToUpper(name[0]) + name.Substring(1);
        }
    }
}
