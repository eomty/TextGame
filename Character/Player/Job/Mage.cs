using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Mage : Player
    {
        public Mage()
        {
            SetInfo(120, 35, 1, 5, 5,1,50,0);
        }
        public void SetInfo(int hp, int attack, int def, int evasion, int critical,int level,int gold,int exp)
        {
            this.Attack_Prop = attack;
            this.Def = def;
            this.Evasion = evasion;
            this.Critical = critical;
            this.Hp = hp;
            this.Level = level;
            this.Gold = gold;
            this.Exp = exp;
        }
    }
}
