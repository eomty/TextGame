using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Equipment : DataManagement
    {
        //public static Equipment[] hat = new Equipment[2];
        //public static Equipment[] armor = new Equipment[2];
        //public static Equipment[] weapon = new Equipment[2];
        public static Equipment[] Temps = new Equipment[6];

        public void Temp()
        {
            //List<Equipment> weapon = new List<Equipment>()
            //{
            //    new Equipment() {ArmorName="무난한 무기",Hp=100,Attack_Prop=75,Def=1,Evasion=5,Critical=25,Gold=500},
            //    new Equipment() {ArmorName="무난한 조끼",Hp=500,Attack_Prop=15,Def=5,Evasion=15,Critical=5,Gold=200},
            //    new Equipment() {ArmorName="무난한 투구",Hp=200,Attack_Prop=10,Def=2,Evasion=10,Critical=10,Gold=100}
            //};

           List<Equipment> equipmentList = new List<Equipment>();
            {
                Temps[0] = new Equipment
                {
                    ArmorName = "무난한 무기",
                    Hp = 100,
                    Attack_Prop = 75,
                    Def = 1,
                    Evasion = 5,
                    Critical = 25,
                    Gold = 500,
                    PossibleActive = true,
                    PossibleBuy = true,
                };

                Temps[1] = new Equipment
                {
                    ArmorName = "무난한 조끼",
                    Hp = 500,
                    Attack_Prop = 15,
                    Def = 5,
                    Evasion = 15,
                    Critical = 5,
                    Gold = 200,
                    PossibleActive = true,
                    PossibleBuy = true,
                };

                Temps[2] = new Equipment
                {
                    ArmorName = "무난한 투구",
                    Hp = 200,
                    Attack_Prop = 10,
                    Def = 2,
                    Evasion = 10,
                    Critical = 10,
                    Gold = 100,
                    PossibleActive = true,
                    PossibleBuy = true,
                };

                Temps[3] = new Equipment
                {
                    ArmorName = "찬란한 무기",
                    Hp = 1000,
                    Attack_Prop = 375,
                    Def = 35,
                    Evasion = 20,
                    Critical = 45,
                    Gold = 3900,
                    PossibleActive = true,
                    PossibleBuy = true,
                };

                Temps[4] = new Equipment
                {
                    ArmorName = "찬란한 조끼",
                    Hp = 2000,
                    Attack_Prop = 25,
                    Def = 75,
                    Evasion = 30,
                    Critical = 25,
                    Gold = 2000,
                    PossibleActive = true,
                    PossibleBuy = true,
                };

                Temps[5] = new Equipment
                {
                    ArmorName = "찬란한 투구",
                    Hp = 375,
                    Attack_Prop = 40,
                    Def = 55,
                    Evasion = 25,
                    Critical = 30,
                    Gold = 1100,
                    PossibleActive = true,
                    PossibleBuy = true,
                };

                for (int i = 0; i < Temps.Length; i++)
                {
                    equipmentList.Add(Temps[i]);
                    Temps[i] = equipmentList[i];
                }
            }
        }
        //public void SetEquipment()
        //{
        //    hat[0] = Temps[0];
        //    armor[0] = Temps[1];
        //    weapon[0] = Temps[2];
        //    hat[1] = Temps[3];
        //    armor[1] = Temps[4];
        //    weapon[1] = Temps[5];
        //}
        public void SetItemInventory(int itemStat)
        {
            Inventory inventory = new Inventory();
            int tempInventory = itemStat;
            inventory.ItemSet(Temps, tempInventory);

        }
        public void DecreaseEquipmentStat(Player player)
        {
            if (player.Equipment == Temps[0].ArmorName && !Temps[0].PossibleActive) //장비탭에서 해제를 하면.
            {
                player.Attack_Prop -= Temps[0].Attack_Prop;
                player.Hp -= Temps[0].Hp;
                player.Def -= Temps[0].Def;
                player.Evasion -= Temps[0].Evasion;
                player.Critical -= Temps[0].Critical;
                Console.WriteLine("투구 해제");
                player.Equipment = string.Empty;//인벤토리 클라스에서 관리해야 될 것 같다.
            }
            else
            {
                Console.WriteLine("장비를 장착하고 있지 않습니다.\n");
            }
        }

        public void IncreaseEquipmentStat(Player player, int itemStat)
        {
            if (player.Equipment.Contains($"{Temps[itemStat].ArmorName}"))
            {
                Console.WriteLine(Temps[itemStat].ArmorName + "구매 완료");
                player.Attack_Prop += Temps[itemStat].Attack_Prop;
                player.Hp += Temps[itemStat].Hp;
                player.Def += Temps[itemStat].Def;
                player.Evasion += Temps[itemStat].Evasion;
                player.Critical += Temps[itemStat].Critical;
                Temps[itemStat].PossibleActive = false;
                Console.WriteLine($"{Temps[itemStat].ArmorName} 적용\n");
            }
        }
    }
}
