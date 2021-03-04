using System;
using System.Collections.Generic;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Adventure of Assignment 5!");

            // TODO: Create an inventory
            // TODO: Add 2 items to the inventory
            // Verify the number of items in the inventory.
            Inventory MyInventory = new Inventory(2);
            MyInventory.AddItem(new Item("fork", 1, ItemGroup.Key));
            MyInventory.AddItem(new Item("Death Killer 10000000", 1, ItemGroup.Equipment));
            List<Item> AllItems = MyInventory.ListAllItems();
            foreach (Item item in AllItems)
			{
                Console.WriteLine(item.ToString());
			}
        }
    }
}
