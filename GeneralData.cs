using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon6tools
{
    //PG
    public enum PGClasses { WIZARD, WARRIOR, THIEF, CLERIC };

    //Creatures
    public enum CreatureType { COMMON, GENERAL, GUARDIAN, BOSS };


    public class GeneralData
    {
        public static string GameDescription = "Dungeon 6";
        public static string GameVersion = "3.0";

        public static Dictionary<PGClasses, CharacterClass> CharacterClasses { get; private set; }
        public static List<CreatureTactic> MonstersTactics { get; private set; }
        public static List<CreatureNature> CreatureNatureList { get; private set; }
        public static List<CreatureTonnage> CreatureTonnageList { get; private set; }
        public static List<string> CreatureColorList { get; private set; }
        public static List<int> CreatureCaseList { get; private set; }
        public static List<CreaturePower> CreatureMinorPowers { get; private set; }
        public static List<CreaturePower> CreatureMajorPowers { get; private set; }

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

        public static string GetGameNameAndVersion()
        {
            return GameDescription + " version " + GameVersion;
        }

        static GeneralData gd = new GeneralData();
        private GeneralData()
        {
            CharacterClasses = new Dictionary<PGClasses, CharacterClass>();
            {//Wizard
                string name = "Mago";
                string description = "Sei il personaggio saggio e dotato di poteri misteriosi. Attraverso la tua conoscenza puoi evocare poteri meravigliosi e terribili.";

                List<LevelImprovement> LevelImprovements = new List<LevelImprovement>();
                LevelImprovements.Add(new LevelImprovement(0, 6, 4, 1, 3, 4, 1));
                LevelImprovements.Add(new LevelImprovement(15, 1, 1, 0, 1, 1, 0));
                LevelImprovements.Add(new LevelImprovement(30, 1, 0, 1, 0, 1, 0));
                LevelImprovements.Add(new LevelImprovement(45, 1, 1, 0, 1, 1, 1));
                LevelImprovements.Add(new LevelImprovement(60, 2, 0, 0, 0, 1, 0));
                LevelImprovements.Add(new LevelImprovement(75, 1, 1, 1, 1, 1, 0));
                LevelImprovements.Add(new LevelImprovement(90, 1, 0, 0, 0, 1, 1));
                LevelImprovements.Add(new LevelImprovement(105, 1, 1, 0, 1, 1, 0));
                LevelImprovements.Add(new LevelImprovement(120, 1, 0, 1, 0, 1, 0));
                LevelImprovements.Add(new LevelImprovement(135, 2, 2, 1, 2, 1, 2));

                List<Ability> Abilities = new List<Ability>();
                Abilities.Add(new Ability("La Spinta della Magia", new string[] { "LC", "4D", "F" }, "La creatura viene spinta lontano dal mago di L quadretti e subisce 3+L danni"));
                Abilities.Add(new Ability("Invocare la mente confusa", new string[] { "1C", "4D", "M" }, "La creatura rimane confusa per 1 turno, durante il quale non può attaccare nè muoversi. La difesa inoltre è abbassata di 2."));
                Abilities.Add(new Ability("Armatura magica", new string[] { "3C", "0D" }, "Il mago viene cirondato da un'armatura magica per 3 turni che gli dona un bonus di L alla difesa."));
                Abilities.Add(new Ability("Lo Strale Magico", new string[] { "3C", "4D", "F" }, "Dalle mani del mago scaturisce un dardo di fuoco che infligge 1d6+L danni."));
                Abilities.Add(new Ability("La Lama della Magia", new string[] { "3C", "3D" }, "L'arma bersaglio ottiene un bonus pari a L/2(per difetto) in attacco per 2 turni."));
                Abilities.Add(new Ability("Invisibilità", new string[] { "5C", "0D" }, "Il mago diventa invisibile per 2 turni durante i quali può muoversi e attaccare senza che nessuno possa vederlo e contrattaccare."));
                Abilities.Add(new Ability("Terrore ancestrale", new string[] { "5C", "3D", "M" }, "Tutte le creature entro 3 quadretti dal mago fuggono in preda ad un terrore profondo e scapperanno al massimo della loro velocità per 1 turno."));
                Abilities.Add(new Ability("Tempesta", new string[] { "6C", "5D", "F" }, "Tutte le creature entro 5 quadretti dal mago subiscono 2d6 danni da fulmini e fuoco."));
                Abilities.Add(new Ability("Varcare i Cancelli del Vuoto", new string[] { "5C", "0D" }, "Il mago e tutto ciò che porta, può spostarsi in un qualsiasi punto già disegnato della mappa."));
                Abilities.Add(new Ability("Dominazione", new string[] { "7C", "3D", "M" }, "La creatura è sotto gli ordini del mago per 3 turni. L'unico ordine che non eseguirà è quello di suicidarsi. Non influenza il Signore del Sotterraneo."));

                //Todo: inventory

                CharacterClass wizard = new CharacterClass(name, description, LevelImprovements, Abilities);
                CharacterClasses.Add(PGClasses.WIZARD, wizard);
            }
            {//Warrior

            }
            {//Thief

            }
            {//Cleric

            }

            //Creature nature

            //Creature tonnage

            //Creature color
            CreatureColorList = new List<string>
            {
                "bianca",
                "verde",
                "trasparente",
                "nera",
                "rossa",
                "blu"
            };

            CreatureCaseList = new List<int>
            {
                -1,
                -1,
                0,
                0,
                1,
                1
            };
        }
    }
}
