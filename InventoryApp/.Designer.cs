using System.Windows.Forms;

namespace InventoryApp
{
    partial class InventoryForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox nameTextBox;
        private TextBox quantityTextBox;
        private TextBox priceTextBox;
        private TextBox categoryTextBox;
        private Button addItemButton;
        private Button removeItemButton;
        private Button updateQuantityButton;
        private ListBox itemsListBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.nameTextBox = new TextBox();
            this.quantityTextBox = new TextBox();
            this.priceTextBox = new TextBox();
            this.categoryTextBox = new TextBox();
            this.addItemButton = new Button();
            this.removeItemButton = new Button();
            this.updateQuantityButton = new Button();
            this.itemsListBox = new ListBox();
            this.SuspendLayout();

            // nameTextBox
            this.nameTextBox.Location = new System.Drawing.Point(20, 20);
            this.nameTextBox.Size = new System.Drawing.Size(200, 23);

            // quantityTextBox
            this.quantityTextBox.Location = new System.Drawing.Point(20, 55);
            this.quantityTextBox.Size = new System.Drawing.Size(80, 23);

            // priceTextBox
            this.priceTextBox.Location = new System.Drawing.Point(110, 55);
            this.priceTextBox.Size = new System.Drawing.Size(110, 23);

            // categoryTextBox
            this.categoryTextBox.Location = new System.Drawing.Point(20, 90);
            this.categoryTextBox.Size = new System.Drawing.Size(200, 23);

            // addItemButton
            this.addItemButton.Location = new System.Drawing.Point(240, 20);
            this.addItemButton.Size = new System.Drawing.Size(120, 30);
            this.addItemButton.Text = "Добавить";
            this.addItemButton.UseVisualStyleBackColor = true;
            this.addItemButton.Click += new System.EventHandler(this.AddItemButton_Click);

            // removeItemButton
            this.removeItemButton.Location = new System.Drawing.Point(240, 55);
            this.removeItemButton.Size = new System.Drawing.Size(120, 30);
            this.removeItemButton.Text = "Удалить";
            this.removeItemButton.UseVisualStyleBackColor = true;
            this.removeItemButton.Click += new System.EventHandler(this.RemoveItemButton_Click);

            // updateQuantityButton
            this.updateQuantityButton.Location = new System.Drawing.Point(240, 90);
            this.updateQuantityButton.Size = new System.Drawing.Size(120, 30);
            this.updateQuantityButton.Text = "Обновить";
            this.updateQuantityButton.UseVisualStyleBackColor = true;
            this.updateQuantityButton.Click += new System.EventHandler(this.UpdateQuantityButton_Click);

            // itemsListBox
            this.itemsListBox.Location = new System.Drawing.Point(20, 130);
            this.itemsListBox.Size = new System.Drawing.Size(540, 200);

            // InventoryForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 350);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.quantityTextBox);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.categoryTextBox);
            this.Controls.Add(this.addItemButton);
            this.Controls.Add(this.removeItemButton);
            this.Controls.Add(this.updateQuantityButton);
            this.Controls.Add(this.itemsListBox);
            this.Text = "Управление инвентарём";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}