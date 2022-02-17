using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Archer : Player
    {
        public Archer()
        {
            SetInfo(150, 20, 2, 20, 30,1,50,0);
        }
        public void SetInfo(int hp, int attack, int def, int evasion, int critical,int Level, int gold,int exp)
        {
            this.Attack_Prop = attack;
            this.Def = def;
            this.Evasion = evasion;
            this.Critical = critical;
            this.Hp = hp;
            this.Level = Level;
            this.Gold = gold;
            this.Exp = exp;
        }
    }
}
