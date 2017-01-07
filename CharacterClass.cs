using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon6tools
{
    public class CharacterClass
    {
        public string ClassName { get; }
        public string ClassDescription { get; }
        public List<LevelImprovement> LevelImprovements { get; }
        public List<Ability> Abilities { get; }

        //Initial objets
        //TODO

        public CharacterClass(string name, string description, List<LevelImprovement> levelImprovements, List<Ability> abilityList)
        {
            this.ClassName = name;
            this.ClassDescription = description;
            this.LevelImprovements = levelImprovements;
            this.Abilities = abilityList;
        }
    }
}
