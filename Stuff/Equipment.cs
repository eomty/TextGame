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
       public static int tempInventory;
        public static int tempCount = 0;
        public static int equipCount = 0;
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
                    TempInt = 0,
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
                    TempInt = 1,
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
                    TempInt = 2,
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
                    TempInt = 3,
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
                    TempInt = 4,
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
                    TempInt = 5,
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
        public void SetItemInventory(Player player,int itemStat)
        {
             tempCount++;
            Inventory inventory = new Inventory();
            TempInt = itemStat;
            tempInventory = itemStat;
            Temps[itemStat].PossibleActive = false;

            if (player.Equipment.Contains("투구"))
                Temps[itemStat].ActiveHat = true;
            

            if (player.Equipment.Contains("조끼"))
                Temps[itemStat].ActiveArmor = true;


            if (player.Equipment.Contains("무기"))
                Temps[itemStat].ActiveWeapon = true;


            inventory.ItemSet(Temps, tempInventory);
        }
        public void DecreaseEquipmentStat(Player player, int itemStat)
        {
            if (Temps[itemStat].ActiveWeapon == true && Temps[itemStat].ArmorName.Contains("무기") && !Temps[itemStat].PossibleActive && Temps[itemStat].OverLap ==true) //장비탭에서 해제를 하면.
            {
                player.Attack_Prop -= Temps[itemStat].Attack_Prop;
                player.Hp -= Temps[itemStat].Hp;
                player.Def -= Temps[itemStat].Def;
                player.Evasion -= Temps[itemStat].Evasion;
                player.Critical -= Temps[itemStat].Critical;
                Temps[itemStat].OverLap = false;
                Console.WriteLine($"{Temps[itemStat].ArmorName} 적용 해제\n");
            }

            if (Temps[itemStat].ActiveArmor == true && Temps[itemStat].ArmorName.Contains("조끼") && !Temps[itemStat].PossibleActive && Temps[itemStat].OverLap == true) //장비탭에서 해제를 하면.
            {
                player.Attack_Prop -= Temps[itemStat].Attack_Prop;
                player.Hp -= Temps[itemStat].Hp;
                player.Def -= Temps[itemStat].Def;
                player.Evasion -= Temps[itemStat].Evasion;
                player.Critical -= Temps[itemStat].Critical;
                Temps[itemStat].OverLap = false;
                Console.WriteLine($"{Temps[itemStat].ArmorName} 적용 해제\n");
            }

            if (Temps[itemStat].ActiveHat == true && Temps[itemStat].ArmorName.Contains("투구") && !Temps[itemStat].PossibleActive && Temps[itemStat].OverLap == true) //장비탭에서 해제를 하면.
            {
                player.Attack_Prop -= Temps[itemStat].Attack_Prop;
                player.Hp -= Temps[itemStat].Hp;
                player.Def -= Temps[itemStat].Def;
                player.Evasion -= Temps[itemStat].Evasion;
                player.Critical -= Temps[itemStat].Critical;
                Temps[itemStat].OverLap = false;
                Console.WriteLine($"{Temps[itemStat].ArmorName} 적용 해제\n");
            }
        }



        public void IncreaseEquipmentStat(Player player, int itemStat)
        {
            Inventory inventory = new Inventory();
            if (Temps[itemStat].ActiveWeapon == true && Temps[itemStat].ArmorName.Contains("무기")&&!player.EquipWeapon)
            {
                tempInventory = itemStat;
                player.Attack_Prop += Temps[itemStat].Attack_Prop;
                player.Hp += Temps[itemStat].Hp;
                player.Def += Temps[itemStat].Def;
                player.Evasion += Temps[itemStat].Evasion;
                player.Critical += Temps[itemStat].Critical;
                Temps[itemStat].PossibleActive = false; //못건드려
                Temps[itemStat].OverLap = true; //건들 수 있음.
                player.EquipWeapon = true;
                equipCount++;
                inventory.EquipmentSet(Temps, tempInventory);
                Console.WriteLine($"{Temps[itemStat].ArmorName} 적용\n");
            }
            if (Temps[itemStat].ActiveArmor == true && Temps[itemStat].ArmorName.Contains("조끼") && !player.EquipArmor)
            {
                tempInventory = itemStat;
                player.Attack_Prop += Temps[itemStat].Attack_Prop;
                player.Hp += Temps[itemStat].Hp;
                player.Def += Temps[itemStat].Def;
                player.Evasion += Temps[itemStat].Evasion;
                player.Critical += Temps[itemStat].Critical;
                Temps[itemStat].PossibleActive = false;
                Temps[itemStat].OverLap = true;
                player.EquipArmor = true;
                equipCount++;
                inventory.EquipmentSet(Temps, tempInventory);
                Console.WriteLine($"{Temps[itemStat].ArmorName} 적용\n");
            }
            if (Temps[itemStat].ActiveHat == true && Temps[itemStat].ArmorName.Contains("투구") && !player.EquipHat)
            {
                tempInventory = itemStat;
                player.Attack_Prop += Temps[itemStat].Attack_Prop;
                player.Hp += Temps[itemStat].Hp;
                player.Def += Temps[itemStat].Def;
                player.Evasion += Temps[itemStat].Evasion;
                player.Critical += Temps[itemStat].Critical;
                Temps[itemStat].PossibleActive = false;
                Temps[itemStat].OverLap = true;
                player.EquipHat = true;
                equipCount++;
                inventory.EquipmentSet(Temps, tempInventory);
                Console.WriteLine($"{Temps[itemStat].ArmorName} 적용\n");
            }
            //else if (Temps[itemStat].ActiveHat == false)
            //{
            //    Console.WriteLine("보유하신 투구가 없습니다.");
            //}
        }
    }
}
