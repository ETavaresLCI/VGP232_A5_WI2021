using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Assignment5
{
	[TestFixture]
	public class UnitTests
	{
		Character TestCharacter;
		Inventory TestInventory;
		int InventoryMax;
		int CharecterHealth;

		[SetUp]
		public void SetUp()
		{
			CharecterHealth = 10;
			TestCharacter = new Character("Test", RaceCategory.Human, CharecterHealth);
			InventoryMax = 5;
			TestInventory = new Inventory(InventoryMax);
		}

		[Test]
		public void TakeDamageHealth()
		{
			int damage = 5;
			Assert.AreEqual(TestCharacter.Health, CharecterHealth);
			Assert.Greater(CharecterHealth, damage);
			TestCharacter.TakeDamage(damage);
			Assert.AreEqual(TestCharacter.Health, CharecterHealth - damage);
		}

		[Test]
		public void TakeDamageSetAlive()
		{
			Assert.IsTrue(TestCharacter.IsAlive);
			TestCharacter.TakeDamage(CharecterHealth);
			Assert.IsFalse(TestCharacter.IsAlive);
		}

		[Test]
		public void RestoreHealthHealth()
		{
			int damage = 5;
			Assert.AreEqual(TestCharacter.Health, CharecterHealth);
			TestCharacter.TakeDamage(damage);
			TestCharacter.RestoreHealth(damage);
			Assert.AreEqual(TestCharacter.Health, CharecterHealth);
		}

		[Test]
		public void RestoreHealthSetAlive()
		{
			Assert.IsTrue(TestCharacter.IsAlive);
			TestCharacter.TakeDamage(CharecterHealth);
			TestCharacter.RestoreHealth(CharecterHealth);
			Assert.IsTrue(TestCharacter.IsAlive);
		}

		[Test]
		public void TakeItemTrue()
		{
			Item TestItem = new Item("fork", 1, ItemGroup.Key);
			TestInventory.AddItem(TestItem);
			TestInventory.TakeItem("fork", out Item found);
			Assert.AreSame(TestItem, found);
			Assert.AreEqual(TestInventory.AvailableSlots, InventoryMax);
		}

		[Test]
		public void TakeItemFalse()
		{
			Item TestItem = new Item("fork", 1, ItemGroup.Key);
			TestInventory.AddItem(TestItem);
			TestInventory.TakeItem("spoon", out Item found);
			Assert.IsNull(found);
			Assert.AreEqual(TestInventory.AvailableSlots, InventoryMax - 1);
		}

		[Test]
		public void AddItemTrue()
		{
			Item TestItem = new Item("fork", 1, ItemGroup.Key);
			TestInventory.AddItem(TestItem);
			Assert.AreEqual(TestInventory.AvailableSlots, InventoryMax - 1);
			Assert.AreEqual(TestInventory.ListAllItems()[0], TestItem);
		}

		[Test]
		public void ResetItemTrue()
		{
			TestInventory.AddItem(new Item("fork", 1, ItemGroup.Key));
			TestInventory.AddItem(new Item("Death Killer 10000000", 1, ItemGroup.Equipment));
			TestInventory.Reset();
			Assert.AreEqual(TestInventory.AvailableSlots, InventoryMax);
			Assert.IsEmpty(TestInventory.ListAllItems());
		}
	}
}
