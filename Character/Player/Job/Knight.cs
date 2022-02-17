using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Knight : Player
    {
        public Knight()
        {
            SetInfo(200, 15, 3, 30, 20,1,50,0);
        }
        public void SetInfo(int hp, int attack, int def, int evasion, int critical, int level,int gold,int exp)
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
