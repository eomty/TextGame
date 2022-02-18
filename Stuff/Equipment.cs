using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Equipment : DataManagement
    {
        public static bool isBuyHat = false;
        public bool isBuyArmor = false;
        public bool isBuyWeapon = false;
        public static Equipment hat = null;
        public static Equipment armor = null;
        public static Equipment weapon = null;
        public static bool isAlreadyBuyHat = false;
        public static bool isAlreadyBuyArmor = false;
        public static bool isAlreadyBuyWeapon = false;
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
        public void SetEquipment()
        {
            hat = Temps[2];
            armor = Temps[1];
            weapon = Temps[0];
        }

        public void IncreaseEquipmentStat(Player player)
        {
            //if 플레이어가 투구를 샀다면.
            if (isBuyHat&&!isAlreadyBuyHat) //모자를 사고    그리고    이미 산게 아닌상태면 시행되야함
            {
                player.Attack_Prop += hat.Attack_Prop;
                player.Hp += hat.Hp;
                player.Def += hat.Def;
                player.Evasion += hat.Evasion;
                player.Critical += hat.Critical;
                player.Gold -= hat.Gold;
                Console.WriteLine("투구 적용");
            }
            if (isBuyArmor&&!isAlreadyBuyArmor)
            {
                player.Attack_Prop += armor.Attack_Prop;
                player.Hp += armor.Hp;
                player.Def += armor.Def;
                player.Evasion += armor.Evasion;
                player.Critical += armor.Critical;
                player.Gold -= armor.Gold;
                Console.WriteLine("조끼 적용");
            }
            if (isBuyWeapon&&!isAlreadyBuyWeapon)
            {
                player.Attack_Prop += weapon.Attack_Prop;
                player.Hp += weapon.Hp;
                player.Def += weapon.Def;
                player.Evasion += weapon.Evasion;
                player.Critical += weapon.Critical;
                player.Gold -= weapon.Gold;
                Console.WriteLine("무기 적용");
            }
        }
    }
}
