using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InventoryApp
{
    public class InventoryManager
    {
        public List<InventoryItem> Items { get; private set; }

        public InventoryManager()
        {
            Items = new List<InventoryItem>();
            LoadItems();
        }

        public void AddItem(InventoryItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            Items.Add(item);
            SaveItems();
        }

        public void RemoveItem(InventoryItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            Items.Remove(item);
            SaveItems();
        }

        public void UpdateItemQuantity(InventoryItem item, int newQuantity)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            item.Quantity = newQuantity;
            SaveItems();
        }

        private void SaveItems()
        {
            var lines = Items.Select(i => $"{i.Name}|{i.Quantity}|{i.Price}|{i.Category}");
            File.WriteAllLines("inventory.txt", lines);
        }

        private void LoadItems()
        {
            if (File.Exists("inventory.txt"))
            {
                var lines = File.ReadAllLines("inventory.txt");
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 4)
                    {
                        if (int.TryParse(parts[1], out int quantity) &&
                            decimal.TryParse(parts[2], out decimal price))
                        {
                            Items.Add(new InventoryItem(parts[0], quantity, price, parts[3]));
                        }
                    }
                }
            }
        }
    }
}