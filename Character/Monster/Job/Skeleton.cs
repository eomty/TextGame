using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Skeleton : Monster
    {
        public Skeleton()
        {
            SetInfo(2000, 70, 20, 20, 30, 700,35,"Skeleton");
        }
        public void SetInfo(int hp, int attack, int def, int evasion, int critical, int gold,int exp,string name)
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
