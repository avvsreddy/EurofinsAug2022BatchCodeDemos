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

        public double GetTotalWorthOfOrdersPlaced()
        {
            double totalAmount = 0;
            double totalDiscount = 0;
            // for each customer
            foreach (Customer customer in Customers)
            {
                //for each orders placed by each customer
                foreach (Order order in customer.Orders)
                {
                    // for each orders - ordered items
                    foreach (OrderedItem oItem in order.OrderedItems)
                    {
                        totalAmount += oItem.Quantity * oItem.Item.Rate;
                    }
                }

                if (customer is RegCustomer)
                {
                    RegCustomer regCustomer = customer as RegCustomer;
                    //RegCustomer regCustomer = (RegCustomer)customer;
                    totalDiscount += regCustomer.Discount;
                }

            }
            return totalAmount - totalDiscount;
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
    }

    class RegCustomer : Customer
    {
        public double Discount { get; set; }
        //private double discount;
        //public void SetDiscount(double discount)
        //{
        //    this.discount = discount;
        //}
        //public double GetDiscount()
        //{
        //    return this.discount;
        //}
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
