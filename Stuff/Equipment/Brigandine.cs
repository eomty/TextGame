using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Brigandine: DataManagement
    {
        public Brigandine()
        {
            SetInfo(500, 15, 5, 15, 5, 200,"무난한 조끼");
        }
        public void SetInfo(int hp, int attack, int def, int evasion, int critical, int gold, string armor)
        {
            this.Attack_Prop = attack;
            this.Def = def;
            this.Evasion = evasion;
            this.Critical = critical;
            this.Hp = hp;
            this.Gold = gold;
            this.ArmorName = armor;
        }
    }
}
