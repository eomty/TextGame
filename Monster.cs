using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Monster
    {
        public class Slime : Creature
        {
            public Slime(int hp, int attack)
            {
                this.hp = hp;
                this.attack = attack;
            }
        }
    }
}