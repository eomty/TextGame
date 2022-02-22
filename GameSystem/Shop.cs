using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Shop : Equipment
    {
        public int inventoryListValue = 0;
        public bool temp = false;
        Equipment equipment = new Equipment();
        Inventory inventory = new Inventory();

        public void ShowPlayerStat(Player player)
        {
            while (true)
            {
                Console.WriteLine("원하는 행동을 선택하십시오.\n");
                Console.WriteLine("1. 인벤토리 및 장비확인");
                Console.WriteLine("2. 스탯확인");
                Console.WriteLine("3. 나가기");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    switch (result)
                    {
                        case 1:
                            PlayerInventoryEquipment(player);
                            //equipment.IncreaseEquipmentStat(player, Equipment.tempInventory);
                            break;
                        case 2:
                            Console.WriteLine($"\n골드:{player.Gold} 체력:{player.Hp} 공격력:{player.Attack_Prop} 방어력:{player.Def} 회피율:{player.Evasion}% 치명타:{player.Critical}%\n");
                            break;
                        case 3:
                            return;
                        default:
                            Console.WriteLine("\n적합하지 않은 문자를 적으셨습니다.");
                            Console.WriteLine("범위에 맞는 자연수를 적어주셔야 합니다.\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\n적합하지 않은 문자를 적으셨습니다.");
                    Console.WriteLine("범위에 맞는 자연수를 적어주셔야 합니다.\n");
                }
            }

        }

        private void PlayerInventoryEquipment(Player player)
        {
            while (true)
            {
                {
                    Console.WriteLine("원하는 행동을 선택하십시오.\n");
                    Console.WriteLine("1. 인벤토리");
                    Console.WriteLine("2. 장비 장착");
                    Console.WriteLine("3. 장비 해제");
                    Console.WriteLine("4. 나가기");

                    string input = Console.ReadLine();

                    if (int.TryParse(input, out int result))
                    {
                        switch (result)
                        {
                            case 1:
                                inventory.PrintBuyEquipment();
                                break;
                            case 2:
                                inventory.PlayerEquipment(player);
                                break; ;
                            case 3:
                                inventory.PlayerDismount(player);
                                break; ;
                            case 4:
                                return;
                            default:
                                Console.WriteLine("\n적합하지 않은 문자를 적으셨습니다.");
                                Console.WriteLine("범위에 맞는 자연수를 적어주셔야 합니다.\n");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n적합하지 않은 문자를 적으셨습니다.");
                        Console.WriteLine("범위에 맞는 자연수를 적어주셔야 합니다.\n");
                    }
                }

            }
        }

        public void EquipMent(Player player)
        {
            player.Gold = 100000;
            Console.Write("\n");

            Console.WriteLine("사고싶은 장비 번호를 눌러주십시오.\n"); //사면 매진텍스트 띄울 것
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"[{i + 1}] [{Temps[i].Gold}G] ({Temps[i].ArmorName}) 체력+{Temps[i].Hp} 공격력+{Temps[i].Attack_Prop} 방어력+{Temps[i].Def} 회피율+{Temps[i].Evasion}% 치명타+{Temps[i].Critical}%");
            }
            Console.WriteLine("7. 뒤로가기\n");
            while (true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    switch (result)
                    {
                        case 1:
                            if (Temps[0].PossibleActive == true)
                            {
                                if (player.Gold >= Temps[0].Gold)
                                {
                                    player.Gold -= Temps[0].Gold;
                                    player.Equipment = Temps[0].ArmorName;
                                    equipment.SetItemInventory(player,0);
                                    inventoryListValue += 1;
                                }
                                else
                                    Console.WriteLine("골드가 부족합니다 ㅠㅠ");
                            }
                            else
                                Console.WriteLine("이미 구입하신 장비입니다.");
                            break;

                        case 2:
                            if (Temps[1].PossibleActive == true)
                            {
                                if (player.Gold >= Temps[1].Gold)
                                {
                                    player.Gold -= Temps[1].Gold;
                                    player.Equipment = Temps[1].ArmorName;
                                    equipment.SetItemInventory(player, 1);
                                    inventoryListValue += 1;
                                }
                                else
                                    Console.WriteLine("골드가 부족합니다 ㅠㅠ");
                            }
                            else
                                Console.WriteLine("이미 구입하신 장비입니다.");
                            break;
                        case 3:
                            if (Temps[2].PossibleActive == true)
                            {
                                if (player.Gold >= Temps[2].Gold)
                                {
                                    player.Gold -= Temps[2].Gold;
                                    player.Equipment = Temps[2].ArmorName;
                                    equipment.SetItemInventory(player, 2);
                                    inventoryListValue += 1;
                                }
                                else
                                    Console.WriteLine("골드가 부족합니다 ㅠㅠ");
                            }
                            else
                                Console.WriteLine("이미 구입하신 장비입니다.");
                            break;
                        case 4:
                            if (Temps[3].PossibleActive == true)
                            {
                                if (player.Gold >= Temps[3].Gold)
                                {
                                    player.Gold -= Temps[3].Gold;
                                    player.Equipment = Temps[3].ArmorName;
                                    equipment.SetItemInventory(player, 3);
                                    inventoryListValue += 1;
                                }
                                else
                                    Console.WriteLine("골드가 부족합니다 ㅠㅠ");
                            }
                            else
                                Console.WriteLine("이미 구입하신 장비입니다.");
                            break;
                        case 5:
                            if (Temps[4].PossibleActive == true)
                            {
                                if (player.Gold >= Temps[4].Gold)
                                {
                                    player.Gold -= Temps[4].Gold;
                                    player.Equipment = Temps[4].ArmorName;
                                    equipment.SetItemInventory(player, 4);
                                    inventoryListValue += 1;
                                }
                                else
                                    Console.WriteLine("골드가 부족합니다 ㅠㅠ");
                            }
                            else
                                Console.WriteLine("이미 구입하신 장비입니다.");
                            break;
                        case 6:
                            if (Temps[5].PossibleActive == true)
                            {
                                if (player.Gold >= Temps[5].Gold)
                                {
                                    player.Gold -= Temps[5].Gold;
                                    player.Equipment = Temps[5].ArmorName;
                                    equipment.SetItemInventory(player, 5);
                                    inventoryListValue += 1;
                                }
                                else
                                    Console.WriteLine("골드가 부족합니다 ㅠㅠ");
                            }
                            else
                                Console.WriteLine("이미 구입하신 장비입니다.");
                            break;
                        case 7:
                            return;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\n적합하지 않은 문자를 적으셨습니다.");
                    Console.WriteLine("범위에 맞는 자연수를 적어주셔야 합니다.\n");
                }
            }
        }

    }
}
