using InventoryApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System;

namespace InventoryTests
{
    [TestClass]
    public class InventoryManagerTests
    {
        private InventoryManager _manager;
        private string _testFile = "inventory.txt";

        [TestInitialize]
        public void Setup()
        {
            if (System.IO.File.Exists(_testFile))
                System.IO.File.Delete(_testFile);

            _manager = new InventoryManager();
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (System.IO.File.Exists(_testFile))
                System.IO.File.Delete(_testFile);
        }

        [TestMethod]
        public void AddItem_NewItem()
        {
            var item = new InventoryItem("Монитор", 4, 8000, "Электроника");
            _manager.AddItem(item);

            Assert.AreEqual(1, _manager.Items.Count);
            Assert.AreEqual("Монитор", _manager.Items.First().Name);
        }

        [TestMethod]
        public void AddItem_NullItem()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _manager.AddItem(null));
        }

        [TestMethod]
        public void RemoveItem_ExistingItem()
        {
            var item = new InventoryItem("Принтер", 1, 5000, "Офис");
            _manager.AddItem(item);
            _manager.RemoveItem(item);

            Assert.AreEqual(0, _manager.Items.Count);
        }

        [TestMethod]
        public void RemoveItem_NullItem()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _manager.RemoveItem(null));
        }

        [TestMethod]
        public void UpdateItemQuantity_ValidItem()
        {
            var item = new InventoryItem("Клавиатура", 5, 1000, "Аксессуары");
            _manager.AddItem(item);
            _manager.UpdateItemQuantity(item, 10);

            Assert.AreEqual(10, item.Quantity);
        }

        [TestMethod]
        public void UpdateItemQuantity_NullItem()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _manager.UpdateItemQuantity(null, 5));
        }

        [TestMethod]
        public void AddMultipleItems()
        {
            var item1 = new InventoryItem("Тест1", 1, 100, "Категория");
            var item2 = new InventoryItem("Тест2", 2, 200, "Категория");
            var item3 = new InventoryItem("Тест3", 3, 300, "Категория");

            _manager.AddItem(item1);
            _manager.AddItem(item2);
            _manager.AddItem(item3);

            Assert.AreEqual(3, _manager.Items.Count);
        }
    }
}