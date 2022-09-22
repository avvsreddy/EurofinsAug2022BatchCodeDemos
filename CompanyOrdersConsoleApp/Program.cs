using System.Collections.Generic;

namespace CompanyOrdersConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Company company = new Company();
            Item i1 = new Item { Rate = 500 };
            Item i2 = new Item { Rate = 120 };
            Item i3 = new Item { Rate = 100 };

            company.Items.Add(i1);
            company.Items.Add(i2);
            company.Items.Add(i3);

            RegCustomer customer = new RegCustomer { Discount = 100 };
            company.Customers.Add(customer);

            Order order = new Order();
            customer.Orders.Add(order);

            OrderedItem oi = new OrderedItem { Quantity = 1, Item = i1 };
            order.OrderedItems.Add(oi);

            System.Console.WriteLine($"Total Worth: {company.GetTotalWorthOfOrdersPlaced()}");

        }
    }

    class Company
    {
        public List<Item> Items { get; set; } = new List<Item>();
        public List<Customer> Customers { get; set; } = new List<Customer>();


        public int GetTotalCustomersCount()
        {
            int count = 0;
            //implement 
            return count;
        }

        public int GetTotalRegCustomersCount()
        {
            int count = 0;
            //implement
            return count;
        }

        public double GetTotalWorthOfOrdersPlaced()
        {
            double totalAmount = 0;
            //double totalDiscount = 0;
            // for each customer
            foreach (Customer customer in Customers)
            {
                totalAmount += customer.GetOrdersTotal();

            }
            return totalAmount;
        }

    }

    class Item
    {
        public int Rate { get; set; }
        public string Description { get; set; }
    }

    class Customer
    {
        public List<Order> Orders { get; set; } = new List<Order>();

        public virtual double GetOrdersTotal()
        {
            double orderTotal = 0;
            foreach (Order order in Orders)
            {
                orderTotal += order.GetOrderTotal();
            }
            return orderTotal;

        }
    }

    class RegCustomer : Customer
    {
        public double Discount { get; set; }
        public override double GetOrdersTotal()
        {
            return base.GetOrdersTotal() - Discount;
        }
    }

    class Order
    {
        public List<OrderedItem> OrderedItems { get; set; } = new List<OrderedItem>();

        public double GetOrderTotal()
        {
            double orderTotal = 0;
            foreach (OrderedItem orderedItem in OrderedItems)
            {
                orderTotal += orderedItem.GetItemValue();
            }
            return orderTotal;
        }
    }

    class OrderedItem
    {
        public int Quantity { get; set; }
        public Item Item { get; set; }

        public double GetItemValue()
        {
            return Quantity * Item.Rate;
        }
    }
}
