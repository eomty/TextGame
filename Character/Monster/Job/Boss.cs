using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Boss : Monster
    {
        public Boss()
        {
            SetInfo(10000, 350, 150, 33, 50, 314159265, 100,"Boss");
        }
        public void SetInfo(int hp, int attack, int def, int evasion, int critical, int gold, int exp,string name)
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
