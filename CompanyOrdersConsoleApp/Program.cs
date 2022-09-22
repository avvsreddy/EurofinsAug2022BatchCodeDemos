using System.Collections.Generic;

namespace CompanyOrdersConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Company
    {
        public List<Item> Items { get; set; } = new List<Item>();
        public List<Customer> Customers { get; set; } = new List<Customer>();

    }

    class Item
    {
        public int Rate { get; set; }
        public string Description { get; set; }
    }

    class Customer
    {
        public List<Order> Orders { get; set; } = new List<Order>();
    }

    class RegCustomer : Customer
    {

    }

    class Order
    {
        public List<OrderedItem> OrderedItems { get; set; } = new List<OrderedItem>();
    }

    class OrderedItem
    {
        public int Quantity { get; set; }
        public Item Item { get; set; }
    }
}
