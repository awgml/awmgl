using System;

namespace InventoryApp
{
    public class InventoryItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public InventoryItem(string name, int quantity, decimal price, string category)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Не может быть пустого названия");

            if (quantity < 0)
                throw new ArgumentException("Не может быть отрицательное количество");

            if (price <= 0)
                throw new ArgumentException("Цена должна быть больше нуля");

            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Не может быть пустой категории");

            Name = name;
            Quantity = quantity;
            Price = price;
            Category = category;
        }
    }
}