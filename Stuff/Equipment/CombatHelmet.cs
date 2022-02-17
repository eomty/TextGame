using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class CombatHelmet : DataManagement
    {
        public CombatHelmet()
        {
            SetInfo(200,10,2,10,10,100,"무난한 투구");
        }
        public void SetInfo(int hp, int attack, int def, int evasion, int critical,int gold, string armor)
        {
            this.Attack_Prop = attack;
            this.Def = def;
            this.Evasion = evasion;
            this.Critical = critical;
            this.Hp = hp;
            this.Gold = gold;
            this.ArmorName = armor;
        }

        public void PlayerEquipHelmet()
        {
            //플레이어 스탯 가져와서 장비추가한 스탯 조정
            
        }
    }
}
