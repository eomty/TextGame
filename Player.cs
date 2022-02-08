using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
     class Player
    {
       public class Knight : Creature
        {
            public Knight(int hp, int attack)
            {
                this.hp = hp;
                this.attack = attack;
            }
        }

       public class Archer : Creature
        {
            public Archer(int hp, int attack)
            {
                this.hp = hp;
                this.attack = attack;
            }
        }

       public class Mage : Creature
        {
            public Mage(int hp, int attack)
            {
                this.hp = hp;
                this.attack = attack;
            }
        }
    }
}
