using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Slime : Monster
    {
        public Slime()
        {
            SetInfo(100, 7, 1, 0, 10, 3, 10,"Slime");
        }
        public void SetInfo(int hp, int attack, int def, int evasion, int critical, int gold, int exp, string name)
        {
            this.Attack_Prop = attack;
            this.Def = def;
            this.Evasion = evasion;
            this.Critical = critical;
            this.Gold = gold;
            this.Hp = hp;
            this.Exp = exp;
            this.Name = name;
        }
    }
}
