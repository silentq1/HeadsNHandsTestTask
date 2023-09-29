using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadsNHandsTestTask.Entities
{
    internal class Monster : Creature
    {
        public Monster(double strength, double deffence, double health, int damageLowest, int damageHighest)
            : base(strength, deffence, health, damageLowest, damageHighest)
        {
        }

        public void GetMonsterInfo()
        {
            Console.WriteLine("Монстр : Сотояние: " + (Alive ? " жив" : " мёртв"));
            Console.WriteLine("        Атака: " + Strength);
            Console.WriteLine("        Защита " + Deffence);
            Console.WriteLine("        Текущее здоровье " + Health);
            Console.WriteLine("        Максимальное  здоровье " + MaxHealth);
            Console.WriteLine("        Урон " + DamageLowest + " - " + DamageHighest);
        }

        public void Attack(Creature creature)
        {

            if (Alive && creature.Alive)
            {
                double attackModifier = Strength - creature.Deffence + 1;
                Random random = new Random();
                bool success = false;
                for (int i = 1; i <= attackModifier; i++)
                {
                    if (random.Next(1, 6) >= 5)
                    {
                        int damage = random.Next(DamageLowest, DamageHighest);
                        if (creature.Health - damage <= 0)
                        {
                            creature.Health = 0;
                            creature.Alive = false;
                            Console.WriteLine("Монстр аттакует с уроном " + damage + ". Противник мертв.");
                        }
                        else
                        {
                            creature.Health -= damage;
                            Console.WriteLine("Монстр аттакует с уроном " + damage + ". Здоровье противника: " + creature.Health);
                        }
                        success = true;
                        break;
                    }
                }

                if (!success)
                {
                    Console.WriteLine("Монстр промахнулся.");
                }
            }
        }

        public void Heal()
        {
            if (!Alive)
            {
                Console.WriteLine("Монстр мертв и не может восстановить здоровье.");
            }
            else if (AvailibleHeal == 0)
            {
                Console.WriteLine("Монстр больше не может восстановить здоровье.");
            }
            else
            {
                if (Health + (MaxHealth * 0.3) >= MaxHealth)
                {
                    Health = MaxHealth;
                    Console.WriteLine("Монстр полностью востановил здоровье.");
                }
                else
                {
                    double arg = MaxHealth * 0.3;
                    Console.WriteLine("Монстр восстановил здоровье на " + arg + " очков здоровья.");
                    Health += arg;
                }
                AvailibleHeal--;
            }
        }
    }
}
