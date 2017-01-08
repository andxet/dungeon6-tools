using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon6tools
{
    public class PropertiesModifier
    {
        public int EnergyModifier { get; }
        public int HPModifier { get; }
        public int AttackModifier { get; }
        public int DefenseModifier { get; }
        public int TalentModifier { get; }
        public int DamageModifier { get; }

        public PropertiesModifier(int EnergyIncrement, int HPIIncrement, int AttackIncrement, int DefenseIncrement, int TalentIncrement, int DamageIncrement)
        {
            this.EnergyModifier = EnergyIncrement;
            this.HPModifier = HPIIncrement;
            this.AttackModifier = AttackIncrement;
            this.DefenseModifier = DefenseIncrement;
            this.TalentModifier = TalentIncrement;
            this.DamageModifier = DamageIncrement;
        }
    }

    public abstract class Actor
    {
        protected GameManager manager;

        protected string Name { get; set; }
        protected int Energy { get; set; }
        protected int HP { get; set; }
        protected int Attack { get; set; }
        protected int Defense { get; set; }
        protected int Talent { get; set; }
        protected int Damage { get; set; }
        protected int Movement { get; set; }

        //Inventory
        //TODO

        public Actor(GameManager gm)
        {
            this.manager = gm;
            Energy = 0;
            HP = 0;
            Attack = 0;
            Defense = 0;
            Talent = 0;
            Damage = 0;
        }

        /// <summary>
        /// Apply the property modification to this actor.
        /// </summary>
        /// <param name="level">The level improvements to apply</param>
        protected void ApplyPropertiesModifier(PropertiesModifier level)
        {
            this.Energy += level.EnergyModifier;
            this.HP += level.HPModifier;
            this.Attack += level.AttackModifier;
            this.Defense += level.DefenseModifier;
            this.Talent += level.TalentModifier;
            this.Damage += level.DamageModifier;
        }
    }
}
