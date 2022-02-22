using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Inventory : Equipment
    {
        public static Equipment[] InventoryTemps = new Equipment[6];
        public static Equipment[] EquipTemps = new Equipment[6];
        public static int TempitemList = 0;
        public static int TempEquipList = 0;

        public void ItemSet(Equipment[] Temps, int Inventory)
        {
            List<Equipment> equipmentInventory = new List<Equipment>();
            {
                InventoryTemps[TempitemList] = Temps[Inventory];
                TempitemList++;
            };

            for (int i = 0; i < Temps.Length; i++)
            {
                equipmentInventory.Add(InventoryTemps[i]);
                InventoryTemps[i] = equipmentInventory[i];
            }
            Console.WriteLine(InventoryTemps);
            Console.Write($"아이템이 인벤토리에 들어왔습니다.");
        }

        public void EquipmentSet(Equipment[] Temps, int Inventory)
        {
            List<Equipment> equipmentSet = new List<Equipment>();
            {
                EquipTemps[TempEquipList] = Temps[Inventory];
                TempEquipList++;
            };

            for (int i = 0; i < Temps.Length; i++)
            {
                equipmentSet.Add(EquipTemps[i]);
                EquipTemps[i] = equipmentSet[i];
            }
            Console.WriteLine(EquipTemps);
            Console.Write($"장착템이 인벤토리에 들어왔습니다.");
        }

        public void PrintBuyEquipment()
        {
            //if (tempCount > 0)
            //{
            //    Console.WriteLine("지금까지 구매한 아이템\n");
            //    for (int i = 0; i < tempCount; i++)
            //    {
            //        Console.WriteLine(InventoryTemps[i].ArmorName);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("보유하고 있는 장비가 없습니다.");
            //}
            Console.WriteLine("정상 작동되지만 기능이 겹쳐서 일단 막았습니다.");
            return;
        }

        public void PlayerEquipment(Player player)
        {

            if (tempCount > 0)
            {
                Console.WriteLine("장착 가능한 아이템\n");
                for (int i = 0; i < tempCount; i++)
                {
                    Console.WriteLine($"[{i + 1}] {InventoryTemps[i].ArmorName}");
                }
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        IncreaseEquipmentStat(player,/*구입한 장비의 값*/InventoryTemps[0].TempInt);
                        break;
                    case 2:
                        IncreaseEquipmentStat(player,/*구입한 장비의 값*/InventoryTemps[1].TempInt);
                        break;
                    case 3:
                        IncreaseEquipmentStat(player,/*구입한 장비의 값*/InventoryTemps[2].TempInt);
                        break;
                    case 4:
                        IncreaseEquipmentStat(player,/*구입한 장비의 값*/InventoryTemps[3].TempInt);
                        break;
                    case 5:
                        IncreaseEquipmentStat(player,/*구입한 장비의 값*/InventoryTemps[4].TempInt);
                        break;
                    case 6:
                        IncreaseEquipmentStat(player,/*구입한 장비의 값*/InventoryTemps[5].TempInt);
                        break;
                }
            }
            else
            {
                Console.WriteLine("장착중인 장비가 없습니다.");
            }
        }
        public void PlayerDismount(Player player)
        {
            if (equipCount > 0) //장착 카운트
            {
                Console.WriteLine("해제 가능한 아이템\n");
                for (int i = 0; i < equipCount; i++) //장착 카운트 만큼
                {
                    Console.WriteLine($"[{i + 1}] {EquipTemps[i].ArmorName}"); //현재 장착된 장비이름을 보여준다.
                }
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        DecreaseEquipmentStat(player, EquipTemps[0].TempInt);
                        break;
                    case 2:
                        DecreaseEquipmentStat(player, EquipTemps[1].TempInt);
                        break;
                    case 3:
                        DecreaseEquipmentStat(player, EquipTemps[2].TempInt);
                        break;
                    case 4:
                        DecreaseEquipmentStat(player, EquipTemps[3].TempInt);
                        break;
                    case 5:
                        DecreaseEquipmentStat(player, EquipTemps[4].TempInt);
                        break;
                    case 6:
                        DecreaseEquipmentStat(player, EquipTemps[5].TempInt);
                        break;
                }
            }
        }
    }
}

