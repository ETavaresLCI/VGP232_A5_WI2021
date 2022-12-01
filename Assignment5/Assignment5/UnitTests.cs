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
        private int MaxSlots = 5;
        private int AvailableSlots;
        [SetUp]
        public void SetUp()
        {
            
            PlayerInventory = new Inventory(MaxSlots);
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
            AvailableSlots = PlayerInventory.AvailableSlots;
            Assert.IsTrue(PlayerInventory.TakeItem("Wooden Sword", out Item found));
            Assert.IsNotNull(found);
            Assert.Greater(PlayerInventory.AvailableSlots, AvailableSlots);
        }

        [Test]
        public void RemoveItemIsNull()
        {
            AvailableSlots = PlayerInventory.AvailableSlots;
            Assert.IsFalse(PlayerInventory.TakeItem("Apple", out Item found));
            Assert.IsNull(found);
            Assert.AreEqual(PlayerInventory.AvailableSlots, AvailableSlots);
        }

        [Test]
        public void AddItem()
        {
            AvailableSlots = PlayerInventory.AvailableSlots;
            Item item = new Item("Blue Berry", 1, ItemGroup.Consumable);
            Assert.IsTrue(PlayerInventory.AddItem(item));
            Assert.IsTrue(PlayerInventory.ListAllItems().IndexOf(item)>0);
            Assert.Less(PlayerInventory.AvailableSlots, AvailableSlots);
        }

        [Test]
        public void Reset()
        {
            PlayerInventory.Reset();
            Assert.AreEqual(PlayerInventory.AvailableSlots, MaxSlots);
        }
    }
}
