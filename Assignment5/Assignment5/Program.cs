using System;
using System.Xml.Linq;

namespace Assignment5
{
    internal class Program
    {
        static Inventory PlayerInventory;
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Adventure of Assignment 5!");

            // Initialize Player inventory
            PlayerInventory = new Inventory(5);

            List_Items();

            Item itmSword = new Item("Wooden Sword", 1, ItemGroup.Equipment);

            Add_Item(itmSword);

            Add_Item(itmSword);

            Item itmBerry = new Item("Blue Berry", 1, ItemGroup.Consumable);

            Add_Item(itmBerry);

            Item itmCloth = new Item("Cloth", 1, ItemGroup.Consumable);

            Add_Item(itmCloth);
            

            Item itmKey = new Item("Rust key", 1, ItemGroup.Key);

            Add_Item(itmKey);

            Item itmKey2 = new Item("Rust key2", 1, ItemGroup.Key);

            Add_Item(itmKey2);

            // Add more item makes invalid
            Item itemApple = new Item("Apple", 1, ItemGroup.Consumable);

            Add_Item(itemApple);


            // Take existing item reduce amount
            if(PlayerInventory.TakeItem("Wooden Sword", out Item found))
            {
                Console.WriteLine(found.Name);
            }
            else
            {
                Console.WriteLine("Item doesnt exist.");
            }
            List_Items();

            // Take item with 1 amount
            if (PlayerInventory.TakeItem("Blue Berry", out Item found1))
            {
                Console.WriteLine(found1.Name);
            }
            else
            {
                Console.WriteLine("Item doesnt exist.");
            }
            List_Items();

            // Item doenst exist
            if (PlayerInventory.TakeItem("Apple", out Item found2))
            {
                Console.WriteLine(found2.Name);
            }
            else
            {
                Console.WriteLine("Item doesnt exist.");
            }
            List_Items();


            Console.WriteLine("Data has been reset.");
            PlayerInventory.Reset();
            List_Items();
        }

        static void List_Items()
        {
            foreach (Item listItem in PlayerInventory.ListAllItems())
            {
                Console.WriteLine(listItem.ToString());
            }

            Console.WriteLine($"Available Slots: {PlayerInventory.AvailableSlots.ToString()}");
            Console.WriteLine($"Max Slots: {PlayerInventory.MaxSlots.ToString()}");
        }

        static void Add_Item(Item itm)
        {
            if (!PlayerInventory.AddItem(itm)) Console.WriteLine("No more available slot.");
            List_Items();
        }
    }
}
