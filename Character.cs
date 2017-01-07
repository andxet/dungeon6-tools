using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon6tools
{
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

    public class LevelImprovement
    {
        public int ExperienceNeeded { get; }
        public int EnergyIncrement { get; }
        public int HPIIncrement { get; }
        public int AttackIncrement { get; }
        public int DefenseIncrement { get; }
        public int TalentIncrement { get; }
        public int DamageIncrement { get; }

        public LevelImprovement(int ExperienceNeeded, int EnergyIncrement, int HPIIncrement, int AttackIncrement, int DefenseIncrement, int TalentIncrement, int DamageIncrement)
        {
            this.ExperienceNeeded = ExperienceNeeded;
            this.EnergyIncrement = EnergyIncrement;
            this.HPIIncrement = HPIIncrement;
            this.AttackIncrement = AttackIncrement;
            this.DefenseIncrement = DefenseIncrement;
            this.TalentIncrement = TalentIncrement;
            this.DamageIncrement = DamageIncrement;
        }
    }

    public class Character
    {
        protected GameManager manager;

        public PGClasses Class { get; private set; }

        protected string Name { get; private set; }
        protected int Level { get; private set; }
        protected int Experience { get; private set; }
        protected int Energy { get; private set; }
        protected int HP { get; private set; }
        protected int Attack { get; private set; }
        protected int Defense { get; private set; }
        protected int Talent { get; private set; }
        protected int Damage { get; private set; }
        protected int Movement { get; private set; }

        //Inventory
        //TODO

        protected List<LevelImprovement> LevelImprovements { get; private set; }
        protected List<Ability> Abilities { get; private set; }
        public string ClassName { get; private set; }
        public string ClassDescription { get; private set; }

        /// <summary>
        /// Constructor of the Character class
        /// </summary>
        /// <param name="gm">The game manager</param>
        /// <param name="pgClass">The class of the pg you want to create</param>
        /// <param name="Name">The name of the pg. Leave to null to enerate it</param>
        public Character(GameManager gm, PGClasses pgClass, string Name = null)
        {
            this.manager = gm;
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
            this.Energy += level.EnergyIncrement;
            this.HP += level.HPIIncrement;
            this.Attack += level.AttackIncrement;
            this.Defense += level.DefenseIncrement;
            this.Talent += level.TalentIncrement;
            this.Damage += level.DamageIncrement;

            Console.WriteLine("Creating new character " + Name + " with class " + pgClass.ToString());
        }

        /// <summary>
        /// Apply the level modification to this character. It not manage the logic of already applied levels or unapplied levels.
        /// </summary>
        /// <param name="level">The level improvements to apply</param>
        protected void ApplyLevelImprovements(LevelImprovement level)
        {
            this.Energy += level.EnergyIncrement;
            this.HP += level.HPIIncrement;
            this.Attack += level.AttackIncrement;
            this.Defense += level.DefenseIncrement;
            this.Talent += level.TalentIncrement;
            this.Damage += level.DamageIncrement;
        }

        /// <summary>
        /// Add experience to the PG. It will level up if enough!
        /// </summary>
        /// <param name="exp">The amount to experience to add.</param>
        public void AddExp(int exp)
        {
            Experience += exp;
            while(Level < LevelImprovements.Count - 1 && Experience >= LevelImprovements.ElementAt(Level + 1).ExperienceNeeded)
            {
                LevelImprovement nextLevel = LevelImprovements.ElementAt(Level + 1);
                ApplyLevelImprovements(nextLevel);
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
