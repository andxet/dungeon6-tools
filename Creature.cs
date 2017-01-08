using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon6tools
{
    public class CreatureTactic
    {
        string Name { get; }
        string Description { get; }

        public CreatureTactic(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }

    public class CreatureNature : PropertiesModifier
    {
        public string Name { get; }

        public CreatureNature(string Name, int EnergyIncrement, int HPIIncrement, int AttackIncrement, int DefenseIncrement, int TalentIncrement, int DamageIncrement) : base(EnergyIncrement, HPIIncrement, AttackIncrement, DefenseIncrement, TalentIncrement, DamageIncrement)
        {
            this.Name = Name;
        }
    }

    public class CreatureTonnage : PropertiesModifier
    {
        public string Name { get; }
        public int Tonnage { get; }

        public CreatureTonnage(string Name, int Tonnage, int EnergyIncrement, int HPIIncrement, int AttackIncrement, int DefenseIncrement, int TalentIncrement, int DamageIncrement) : base(EnergyIncrement, HPIIncrement, AttackIncrement, DefenseIncrement, TalentIncrement, DamageIncrement)
        {
            this.Name = Name;
            this.Tonnage = Tonnage;
        }
    }

    public class CreaturePower
    {
        string Name { get; }
        string Description { get;}

        public CreaturePower(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
    class Creature : Actor
    {
        public CreatureType Type { get; private set; }
        public CreatureNature Nature { get; private set; }
        public CreatureTonnage Tonnage { get; private set; }
        public string SkinColor { get; private set; }
        public CreatureTactic Tactic { get; private set; }
        public int Force { get; private set; }
        public int Case { get; private set; }
        public int Distance { get; private set; }
        public CreaturePower Power { get; private set; }
        

        /// <summary>
        /// Constructor of the creature class.
        /// </summary>
        /// <param name="type">The type of creature</param>
        /// <param name="force">The force of the creature. L in manual</param>
        public Creature(GameManager gm, CreatureType type, int force) : base(gm)
        {
            this.Name = manager.GenerateName();
            this.Nature = GeneralData.CreatureNatureList.ElementAt(manager.RollDice6());
            ApplyPropertiesModifier(this.Nature);
            this.Tonnage = GeneralData.CreatureTonnageList.ElementAt(manager.RollDice6());
            ApplyPropertiesModifier(this.Tonnage);
            this.SkinColor = GeneralData.CreatureColorList.ElementAt(manager.RollDice6());
            this.Force = force;
            this.Case = GeneralData.CreatureCaseList.ElementAt(manager.RollDice6());

            Attack = Force + Case;
            Defense = 4 + Force + Case;
            Talent = Force + Case;
            Movement = 2 + Force + Case;
            if (Movement > 8)
                Movement = 8;
            if (Movement < 1)
                Movement = 1;
            HP = 3 + Case + 3 * Force;
            Distance = 1 + Case + Tonnage.Tonnage;
            if (Distance < 1)
                Distance = 1;
            Damage = 2 + Case + Force;
            if (Damage < 1)
                Damage = 1;

            Tactic = GeneralData.MonstersTactics.ElementAt(manager.RollDice6());
            int powerValue = manager.RollDice6() + Force;

            if((powerValue >= 8 && powerValue <= 10) || (powerValue <= 7 && Type == CreatureType.GUARDIAN))
                Power = GeneralData.CreatureMinorPowers.ElementAt(manager.RollDice6());
            else if(powerValue >= 11)
                Power = GeneralData.CreatureMajorPowers.ElementAt(manager.RollDice6());

            //Treasures
            //TODO
        }
    }
}
