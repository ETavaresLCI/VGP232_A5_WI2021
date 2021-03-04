using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    public class Inventory
    {
        // The dictionary items consist of the item and the quantity
        private Dictionary<Item, int> items;

        public int AvailableSlots
        {
            get
            {
                return availableSlots;
            }
        }

        public int MaxSlots
        {
            get
            {
                return MaxSlots;
            }
        }


        // The available slots to add item, once it's 0, you cannot add any more items.
        private int availableSlots;

        // The max available slots which is set only in the constructor.
        private int maxSlots;
        public Inventory(int slots)
        {
            items = new Dictionary<Item, int>();
            maxSlots = slots;
            availableSlots = maxSlots;
        }

        /// <summary>
        /// Removes all the items, and restore the original number of slots.
        /// </summary>
        public void Reset()
        {
            items.Clear();
            availableSlots = maxSlots;
        }

        /// <summary>
        /// Removes the item from the items dictionary if the count is 1 otherwise decrease the quantity.
        /// </summary>
        /// <param name="name">The item name</param>
        /// <param name="found">The item if found</param>
        /// <returns>True if you find the item, and false if it does not exist.</returns>
        public bool TakeItem(string name, out Item found)
        {
            found = new Item();
            foreach (var item in items)
			{
                if (item.Key.Name == name)
				{
                    found = item.Key;
                    if (item.Value > 1)
					{
                        items[item.Key] -= 1;
                        return true;
					}
                    else
					{
                        items.Remove(item.Key);
                        availableSlots += 1;
                        return true;
                    }
				}
			}
            return false;
        }

        /// <summary>
        /// Checks if there is space for a unique item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool AddItem(Item item)
        {
            // the instructions could have been interpreted as each item takes up an available slot
            // I decided that is stupid, and instead made it so each unique item takes up a slot
            if (items.TryGetValue(item, out int value))
			{
                items[item] += 1;
                return true;
			}
            else if (availableSlots > 0)
			{
                items[item] = 1;
                availableSlots -= 1;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Iterates through the dictionary and create a list of all the items.
        /// </summary>
        /// <returns></returns>
        public List<Item> ListAllItems()
        {
            List<Item> AllItems = new List<Item>();
            foreach (var item in items)
            {
                for (int i = item.Value; i > 0; i--)
				{
                    AllItems.Add(item.Key);
				}
            }
            return AllItems;
        }
    }
}
