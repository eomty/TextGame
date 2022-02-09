using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Player : Creature
    {
        public class Knight : Player
        {
            public Knight()
            {
                SetInfo(120, 10);
            }
        }
        public class Archer : Player
        {
            public Archer()
            {
                SetInfo(100, 15);
            }
        }
        public class Mage : Player
        {
            public Mage()
            {
                SetInfo(80, 20);
            }
        }
    }
}
