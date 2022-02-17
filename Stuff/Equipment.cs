using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Equipment : DataManagement
    {

        public Equipment hat = null;
        public Equipment armor = null;
        public Equipment weapon = null;
        public Equipment[] Temps = new Equipment[3];


        public void Temp()
        {
            List<Equipment> weapon = new List<Equipment>()
            {
                new Equipment() {ArmorName="무난한 무기",Hp=100,Attack_Prop=75,Def=1,Evasion=5,Critical=25,Gold=500},
                new Equipment() {ArmorName="무난한 조끼",Hp=500,Attack_Prop=15,Def=5,Evasion=15,Critical=5,Gold=200},
                new Equipment() {ArmorName="무난한 투구",Hp=200,Attack_Prop=10,Def=2,Evasion=10,Critical=10,Gold=100}
            };
            for (int i = 0; i < weapon.Count; i++)
            {
                Temps[i] = weapon[i];
            }
        }
        public void PlayerEquipment()
        {
            //if 플레이어가 장비를 샀다면.
            hat = Temps[0];

        }
    }

}
