using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Shop : Equipment
    {
        public int TempValue = 0;
        public bool temp = false;
        Equipment equipment = new Equipment();

        public void ShowPlayerStat(Player player)
        {

            Console.WriteLine($"\n골드:{player.Gold} 체력:{player.Hp} 공격력:{player.Attack_Prop} 방어력:{player.Def} 회피율:{player.Evasion}% 치명타:{player.Critical}%\n");
        }

        public void EquipMent(Player player)
        {
            player.Gold = 100000;
            Console.Write("\n");
            Console.WriteLine("사고싶은 장비 번호를 눌러주십시오.\n"); //사면 매진텍스트 띄울 것
            Console.WriteLine($"1. [{Temps[0].Gold}G] ({Temps[0].ArmorName}) 체력+{Temps[0].Hp} 공격력+{Temps[0].Attack_Prop} 방어력+{Temps[0].Def} 회피율+{Temps[0].Evasion}% 치명타+{Temps[0].Critical}%");
            Console.WriteLine($"2. [{Temps[1].Gold}G] ({Temps[1].ArmorName}) 체력+{Temps[1].Hp} 공격력+{Temps[1].Attack_Prop} 방어력+{Temps[1].Def} 회피율+{Temps[1].Evasion}% 치명타+{Temps[1].Critical}%");
            Console.WriteLine($"3. [{Temps[2].Gold}G] ({Temps[2].ArmorName}) 체력+{Temps[2].Hp} 공격력+{Temps[2].Attack_Prop} 방어력+{Temps[2].Def} 회피율+{Temps[2].Evasion}% 치명타+{Temps[2].Critical}%\n");
            Console.WriteLine($"4. [{Temps[3].Gold}G] ({Temps[3].ArmorName}) 체력+{Temps[3].Hp} 공격력+{Temps[3].Attack_Prop} 방어력+{Temps[3].Def} 회피율+{Temps[3].Evasion}% 치명타+{Temps[3].Critical}%");
            Console.WriteLine($"5. [{Temps[4].Gold}G] ({Temps[4].ArmorName}) 체력+{Temps[4].Hp} 공격력+{Temps[4].Attack_Prop} 방어력+{Temps[4].Def} 회피율+{Temps[4].Evasion}% 치명타+{Temps[4].Critical}%");
            Console.WriteLine($"6. [{Temps[5].Gold}G] ({Temps[5].ArmorName}) 체력+{Temps[5].Hp} 공격력+{Temps[5].Attack_Prop} 방어력+{Temps[5].Def} 회피율+{Temps[5].Evasion}% 치명타+{Temps[5].Critical}%\n");
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
                                   equipment.SetItemInventory(0);
                                    //equipment.IncreaseEquipmentStat(player, 0);

                                    // Temps[itemStat].PossibleActive = false;
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
                                    player.Equipment = Temps[1].ArmorName;
                                    equipment.IncreaseEquipmentStat(player, 1);
                                    // Temps[itemStat].PossibleActive = false;
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
                                    player.Equipment = Temps[2].ArmorName;
                                    equipment.IncreaseEquipmentStat(player, 2);
                                    // Temps[itemStat].PossibleActive = false;
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
                                    player.Equipment = Temps[3].ArmorName;
                                    equipment.IncreaseEquipmentStat(player, 3);
                                    // Temps[itemStat].PossibleActive = false;
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
                                    player.Equipment = Temps[4].ArmorName;
                                    equipment.IncreaseEquipmentStat(player,4);
                                    // Temps[itemStat].PossibleActive = false;
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
                                    player.Equipment = Temps[5].ArmorName;
                                    equipment.IncreaseEquipmentStat(player, 5);
                                    // Temps[itemStat].PossibleActive = false;
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
