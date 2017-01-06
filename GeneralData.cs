using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon6
{
    public class GeneralData
    {
        public static string[] DungeonName =
        {
            "Cripta di ",
            "Sotterraneo di ",
            "Grotte di ",
            "Città perduta di ",
            "Labirinto di ",
            "Sale di "
        };

        public static char[,] ConsonantsDictionary =
        {
            {'b','b','k','k','s','s'},
            {'c','c','l','l','t','t'},
            {'d','d','m','m','v','v'},
            {'f','f','n','n','w','w'},
            {'g','g','p','p','x','x'},
            {'j','j','r','r','z','z'}
        };

        public static char[] VocalsDictionary =
        {
            'a',
            'e',
            'i',
            'o',
            'u',
            'y'
        };
    }
}
