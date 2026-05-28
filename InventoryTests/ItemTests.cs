using InventoryApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace InventoryTests
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void ValidData()
        {
            var item = new InventoryItem("Ноутбук", 5, 1000, "Электроника");

            Assert.AreEqual("Ноутбук", item.Name);
            Assert.AreEqual(5, item.Quantity);
            Assert.AreEqual(1000, item.Price);
            Assert.AreEqual("Электроника", item.Category);
        }

        [TestMethod]
        public void QuantityZero()
        {
            var item = new InventoryItem("Тест", 0, 100, "Категория");
            Assert.AreEqual(0, item.Quantity);
        }

        [TestMethod]
        public void VeryLargeQuantity()
        {
            var item = new InventoryItem("Тест", int.MaxValue, 100, "Категория");
            Assert.AreEqual(int.MaxValue, item.Quantity);
        }

        [TestMethod]
        public void PriceOne()
        {
            var item = new InventoryItem("Тест", 1, 1, "Категория");
            Assert.AreEqual(1, item.Price);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PriceZero()
        {
            new InventoryItem("Тест", 1, 0, "Категория");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativePrice()
        {
            new InventoryItem("Тест", 1, -1, "Категория");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeQuantity()
        {
            new InventoryItem("Тест", -5, 100, "Категория");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NameNull()
        {
            new InventoryItem(null, 5, 100, "Категория");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyName()
        {
            new InventoryItem("", 5, 100, "Категория");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CategoryNull()
        {
            new InventoryItem("Тест", 5, 100, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyCategory()
        {
            new InventoryItem("Тест", 5, 100, "");
        }
    }
}