using System;
using System.Windows.Forms;
using System.Linq;

namespace InventoryApp
{
    public partial class InventoryForm : Form
    {
        private InventoryManager inventoryManager;

        public InventoryForm()
        {
            InitializeComponent();
            inventoryManager = new InventoryManager();
            UpdateItemsList();
        }

        private void UpdateItemsList()
        {
            itemsListBox.Items.Clear();
            foreach (var item in inventoryManager.Items)
            {
                itemsListBox.Items.Add($"{item.Name} | {item.Quantity} | {item.Price:C} | {item.Category}");
            }
        }

        private void AddItemButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text) ||
                string.IsNullOrWhiteSpace(quantityTextBox.Text) ||
                string.IsNullOrWhiteSpace(priceTextBox.Text) ||
                string.IsNullOrWhiteSpace(categoryTextBox.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка");
                return;
            }

            if (!int.TryParse(quantityTextBox.Text, out int quantity) || quantity < 0)
            {
                MessageBox.Show("Количество должно быть целым положительным числом!", "Ошибка");
                return;
            }

            if (!decimal.TryParse(priceTextBox.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Цена должна быть положительным числом!", "Ошибка");
                return;
            }

            try
            {
                var newItem = new InventoryItem(
                    nameTextBox.Text.Trim(),
                    quantity,
                    price,
                    categoryTextBox.Text.Trim()
                );

                inventoryManager.AddItem(newItem);

                nameTextBox.Clear();
                quantityTextBox.Clear();
                priceTextBox.Clear();
                categoryTextBox.Clear();

                UpdateItemsList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void RemoveItemButton_Click(object sender, EventArgs e)
        {
            if (itemsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите товар для удаления!", "Ошибка");
                return;
            }

            string selectedItem = itemsListBox.SelectedItem.ToString();
            string itemName = selectedItem.Split('|')[0].Trim();

            var itemToRemove = inventoryManager.Items.FirstOrDefault(i => i.Name == itemName);
            if (itemToRemove != null)
            {
                var result = MessageBox.Show($"Удалить товар '{itemName}'?", "Подтверждение", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    inventoryManager.RemoveItem(itemToRemove);
                    UpdateItemsList();
                }
            }
        }

        private void UpdateQuantityButton_Click(object sender, EventArgs e)
        {
            if (itemsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите товар для обновления!", "Ошибка");
                return;
            }

            if (string.IsNullOrWhiteSpace(quantityTextBox.Text))
            {
                MessageBox.Show("Введите новое количество!", "Ошибка");
                return;
            }

            if (!int.TryParse(quantityTextBox.Text, out int newQuantity) || newQuantity < 0)
            {
                MessageBox.Show("Количество должно быть целым положительным числом!", "Ошибка");
                return;
            }

            string selectedItem = itemsListBox.SelectedItem.ToString();
            string itemName = selectedItem.Split('|')[0].Trim();

            var itemToUpdate = inventoryManager.Items.FirstOrDefault(i => i.Name == itemName);
            if (itemToUpdate != null)
            {
                inventoryManager.UpdateItemQuantity(itemToUpdate, newQuantity);
                quantityTextBox.Clear();
                UpdateItemsList();
            }
        }
    }
}