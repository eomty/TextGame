using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Creature
    {
        public int hp;
        public int attack;

        public void HitDamaged(int damage)
        {
            hp -= damage;
        }

        public int GetHp()
        {
            return hp;
        }
    }
}
