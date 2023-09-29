using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadsNHandsTestTask.Entities
{
    internal abstract class Creature
    {
        public double Strength { get; }

        public double Deffence { get; }

        public double Health { get; set; }

        public int DamageLowest { get; }

        public int DamageHighest { get; }

        public double MaxHealth { get; }

        public bool Alive { get; set; }

        public uint AvailibleHeal = 4;

        public Creature(double strength, double deffence, double health, int damageLowest, int damageHighest)
        {
            if (strength < 0)
            {
                Strength = 1;
            }
            else if (strength > 30)
            {
                Strength = 30;
            }
            else
            {
                Strength = strength;
            }

            if (deffence < 0)
            {
                Deffence = 1;
            }
            else if (deffence > 30)
            {
                Deffence = 30;
            }
            else
            {
                Deffence = deffence;
            }

            if (health < 0)
            {
                Health = 1;
                MaxHealth = health;
            }
            else
            {
                Health = health;
                MaxHealth = health;
            }

            if (damageLowest < 0)
            {
                DamageLowest = 0;
                DamageHighest = damageHighest;
            }
            else if (damageLowest > damageHighest)
            {
                DamageHighest = damageLowest;
                DamageLowest = damageHighest;
            }
            else
            {
                DamageLowest = damageLowest;
                DamageHighest = damageHighest;
            }

            Alive = true;
        }
    }
}
