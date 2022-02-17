using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Orc : Monster
    {
        public Orc()
        {
            SetInfo(500, 20, 5, 10, 20, 50,20);
        }
        public void SetInfo(int hp, int attack, int def, int evasion, int critical, int gold,int exp)
        {
            this.Attack_Prop = attack;
            this.Def = def;
            this.Evasion = evasion;
            this.Critical = critical;
            this.Gold = gold;
            this.Hp = hp;
            this.Exp = exp;
        }
    }
}
