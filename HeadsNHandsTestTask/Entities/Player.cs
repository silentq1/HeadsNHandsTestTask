using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadsNHandsTestTask.Entities
{
    internal class Player : Creature
    {
        public Player(double strength, double deffence, double health, int damageLowest, int damageHighest) 
            : base(strength, deffence, health, damageLowest, damageHighest)
        {
        }

        public void GetPlayerInfo()
        {
            Console.WriteLine("Игрок : Сотояние: " + (Alive ? " жив" : " мёртв") );
            Console.WriteLine("        Атака: " + Strength);
            Console.WriteLine("        Защита: " + Deffence);
            Console.WriteLine("        Текущее здоровье: " + Health);
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
                            Console.WriteLine("Игрок аттакует с уроном " + damage + ". Противник мертв.");
                        }
                        else
                        {
                            creature.Health -= damage;
                            Console.WriteLine("Игрок аттакует с уроном " + damage + ". Здоровье противника: " + creature.Health);
                        }
                        success = true;
                        break;
                    }
                }
                
                if (!success)
                {
                    Console.WriteLine("Игрок промахнулся.");
                }
            }
        }

        public void Heal()
        {
            if (!Alive)
            {
                Console.WriteLine("Игрок мертв и не может восстановить здоровье.");
            }
            else if (AvailibleHeal == 0)
            {
                Console.WriteLine("Игрок больше не может восстановить здоровье.");
            }
            else
            {
                if (Health + (MaxHealth * 0.3) >= MaxHealth)
                {
                    Health = MaxHealth;
                    Console.WriteLine("Игрок полностью востановил здоровье.");
                }
                else
                {
                    double arg = MaxHealth * 0.3;
                    Console.WriteLine("Игрок восстановил здоровье на " + arg + " очков здоровья.");
                    Health += arg;
                }
                AvailibleHeal--;
            }
        }
    }
}
