using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Assignment5
{
    [TestFixture]
    internal class UnitTests
    {
        private Inventory PlayerInventory;

        [SetUp]
        public void SetUp()
        {
            PlayerInventory = new Inventory(5);
            PlayerInventory.AddItem(new Item("Wooden Sword", 1, ItemGroup.Equipment));
        }

        [TearDown]
        public void CleanUp()
        {
            PlayerInventory = null;
        }

        [Test]
        public void RemoveItemIsSet()
        {
            Console.WriteLine($"Current Available slot: {PlayerInventory.AvailableSlots.ToString()}");
            Assert.IsTrue(PlayerInventory.TakeItem("Wooden Sword", out Item found));
            Console.WriteLine($"Found item: {found.Name.ToString()}");
            Console.WriteLine($"Updated Available slot: {PlayerInventory.AvailableSlots.ToString()}");
        }

        [Test]
        public void RemoveItemIsNull()
        {
            Console.WriteLine($"Current Available slot: {PlayerInventory.AvailableSlots.ToString()}");
            PlayerInventory.TakeItem("Apple", out Item found);
            Assert.IsFalse(found !=null);
            Console.WriteLine($"Updated Available slot: {PlayerInventory.AvailableSlots.ToString()}");
        }

        [Test]
        public void AddItem()
        {
            Console.WriteLine($"Current Available slot: {PlayerInventory.AvailableSlots.ToString()}");
            Item item = new Item("Blue Berry", 1, ItemGroup.Consumable);
            Console.WriteLine($"Adding item: {item.Name} Amount: {item.Amount} Group: {item.Group.ToString()}");
            PlayerInventory.AddItem(item);
            foreach (Item listItem in PlayerInventory.ListAllItems())
            {
                Console.WriteLine(listItem.ToString());
            }
            Console.WriteLine($"Updated Available slot: {PlayerInventory.AvailableSlots.ToString()}");
        }

        [Test]
        public void Reset()
        {
            Console.WriteLine($"Current Available slot: {PlayerInventory.AvailableSlots.ToString()}");
            PlayerInventory.Reset();
            Console.WriteLine($"Showing list of items: ");
            foreach (Item listItem in PlayerInventory.ListAllItems())
            {
                Console.WriteLine(listItem.ToString());
            }
            Console.WriteLine($"Available slot: {PlayerInventory.AvailableSlots.ToString()}");
        }
    }
}
