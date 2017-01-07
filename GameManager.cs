using System;
using System.Diagnostics;

namespace Dungeon6
{
    public class GameManager
    {
        Random random;

        public GameManager()
        {
            random = new Random();
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
            if(nameLength % 2 == 0)
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
