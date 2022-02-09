using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Creature
    {
        public int Hp { get; set; }
        public int Attack { get; set; }

        public void DecreaseHp(int damage)
        {
            Hp -= damage;
        }

        public bool IsDie()
        {
            if (Hp <= 0)
            {
               return true;
            }
            else
            {
               return false;
            }
        }
        public void SetInfo(int hp, int attack)
        {
            this.Hp = hp;
            this.Attack = attack;
        }
    }
}
