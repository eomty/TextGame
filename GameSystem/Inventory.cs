using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Inventory : Equipment
    {
        public static Equipment[] InventoryTemps = new Equipment[6];

        public void ItemSet(Equipment[] Temps, int Inventory)
        {
            List<Equipment> equipmentInventory = new List<Equipment>();
            {
                InventoryTemps[Inventory] = Temps[Inventory];
            };


            for (int i = 0; i < Temps.Length; i++)
            {
                equipmentInventory.Add(InventoryTemps[i]);
                InventoryTemps[i] = equipmentInventory[i];
            }
            Console.WriteLine(InventoryTemps[0]);
            Console.WriteLine("아이템이 인벤토리에 들어왔습니다.");
        }
    }

}

