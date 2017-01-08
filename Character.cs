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

    public class Ability
    {
        string Name { get; }
        string[] Parameters { get; }
        string Description { get; }

        public Ability(string Name, string[] Parameters, string Description)
        {
            this.Name = Name;
            this.Parameters = Parameters;
            this.Description = Description;
        }
    }

    public class LevelImprovement : PropertiesModifier
    {
        public int ExperienceNeeded { get; }

        public LevelImprovement(int ExperienceNeeded, int EnergyIncrement, int HPIIncrement, int AttackIncrement, int DefenseIncrement, int TalentIncrement, int DamageIncrement) : base(EnergyIncrement, HPIIncrement, AttackIncrement, DefenseIncrement, TalentIncrement, DamageIncrement)
        {
            this.ExperienceNeeded = ExperienceNeeded;
        }
    }

    public class Character : Actor
    {
        public PGClasses Class { get; private set; }
        protected List<LevelImprovement> LevelImprovements { get; private set; }
        protected List<Ability> Abilities { get; private set; }
        public string ClassName { get; private set; }
        public string ClassDescription { get; private set; }
        protected int Experience { get; set; }
        protected int Level { get; set; }

        /// <summary>
        /// Constructor of the Character class
        /// </summary>
        /// <param name="gm">The game manager</param>
        /// <param name="pgClass">The class of the pg you want to create</param>
        /// <param name="Name">The name of the pg. Leave to null to enerate it</param>
        public Character(GameManager gm, PGClasses pgClass, string Name = null) : base(gm)
        {
            CharacterClass classToAssign;
            GeneralData.CharacterClasses.TryGetValue(pgClass, out classToAssign);
            if (classToAssign == null)
            {
                Console.WriteLine("ERROR Creating character " + Name + " with class " + pgClass.ToString() + ": PGClass not found in General Data.");
                return;
            }
            ApplyClass(classToAssign);
            this.Class = pgClass;
            if (Name == null)
                Name = gm.GenerateName();
            this.Name = Name;

            //Set the first level parameters
            LevelImprovement level = LevelImprovements.ElementAt(0);
            this.Energy += level.EnergyModifier;
            this.HP += level.HPModifier;
            this.Attack += level.AttackModifier;
            this.Defense += level.DefenseModifier;
            this.Talent += level.TalentModifier;
            this.Damage += level.DamageModifier;

            Console.WriteLine("Creating new character " + Name + " with class " + pgClass.ToString());
        }

        /// <summary>
        /// Add experience to the PG. It will level up if enough!
        /// </summary>
        /// <param name="exp">The amount to experience to add.</param>
        public void AddExp(int exp)
        {
            Experience += exp;
            while (Level < LevelImprovements.Count - 1 && Experience >= LevelImprovements.ElementAt(Level + 1).ExperienceNeeded)
            {
                LevelImprovement nextLevel = LevelImprovements.ElementAt(Level + 1);
                ApplyPropertiesModifier(nextLevel);
                Level++;
                Console.WriteLine("Character " + Name + " " + Class.ToString() + " has reached level " + (Level + 1) + "!");
            }
        }

        /// <summary>
        /// Apply a class to the PG.
        /// </summary>
        /// <param name="classToApply">The class to apply</param>
        private void ApplyClass(CharacterClass classToApply)
        {
            this.ClassName = classToApply.ClassName;
            this.ClassDescription = classToApply.ClassDescription;
            this.LevelImprovements = classToApply.LevelImprovements;
            this.Abilities = classToApply.Abilities;
        }
    }
}
