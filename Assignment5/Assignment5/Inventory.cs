using System;
using System.Collections.Generic;
using System.Data;
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
                return maxSlots;
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
            if (items.Count > 0)
            {
                foreach (Item itm in items.Keys)
                {
                    if(itm.Name == name)
                    {
                        if(itm.Amount > 1)
                        {
                            itm.Amount--;
                        }
                        else
                        {
                            availableSlots++;
                            items.Remove(itm);
                        }
                        found = itm;
                        return true;
                    }
                }
            }
            found = null;
            return false;
        }

        /// <summary>
        /// Checks if there is space for a unique item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool AddItem(Item item)
        {
            // if items dictionary is null add item automaticallly
            if(items.Count == 0)
            {
                items.Add(item, item.Amount);
                availableSlots--;
                return true;
            }
            else
            {
                // Add it in the items dictionary and increment it the number if it already exist
                foreach (Item itm in items.Keys)
                {
                    // if item exist
                    // no amount max limit
                    if (itm.Name == item.Name)
                    {
                        itm.Amount += item.Amount;
                        return true;
                    }
                    else
                    {
                        // Reduce the slot once it's been added.
                        if (availableSlots > 0)
                        {
                            items.Add(item, item.Amount);
                            availableSlots--;
                            return true;
                        }
                        // returns false if the inventory is full
                        else
                        {
                            return false;
                        }
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// Iterates through the dictionary and create a list of all the items.
        /// </summary>
        /// <returns></returns>
        public List<Item> ListAllItems()
        {
            // use a foreach loop to iterate through the key value pairs and duplicate the item base on the quantity.
            //throw new NotImplementedException();
            List<Item> listItems = new List<Item>();

            foreach(Item itm in items.Keys)
            {
                listItems.Add(itm);
            }

            return listItems;
        }
    }
}
