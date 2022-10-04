using ProductsCatalogConsoleApp.Data;
using ProductsCatalogConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductsCatalogConsoleApp
{
    //class NamePrice
    //{
    //    public string PName { get; set; }
    //    public int Price { get; set; }
    //}

    internal class Program
    {
        static void Main(string[] args)
        {
            //ProductsDbContext db = new ProductsDbContext();
            //db.Database.Log = Console.WriteLine;
            //AddCustomerSuppliers();\
            SelectCustomers();

        }

        private static void SelectCustomers()
        {
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;
            var customers = db.People.OfType<Customer>();
            foreach (var item in customers)
            {
                Console.WriteLine(item.Name);
            }
        }

        private static void AddCustomerSuppliers()
        {
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;
            Address a = new Address();
            Customer c = new Customer { Name = "Customer 1", Discount = 250, Type = "Silver" };
            Supplier s = new Supplier { Name = "Supplier 1", GST = "dfsd23434erwerwe", Rating = 9 };
            c.Address = a;
            s.Address = a;
            db.People.Add(c);
            //db.People.Add(s);
            db.SaveChanges();
        }

        private static void EgarLoading()
        {
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;
            // Product name and C Name
            //var plist = from p in db.Products
            //            select new
            //            { PName = p.Name, CName = p.TheCatagory.Name };

            //foreach (var item in plist)
            //{
            //    Console.WriteLine(item.PName + "\t" + item.CName);
            //}


            var plist = from p in db.Products//.Include("TheCatagory")
                        select p;

            foreach (var item in plist)
            {
                Console.WriteLine($"{item.Name} \t {item.TheCatagory.Name}");
            }
        }

        private static void UpdateProductWithCat()
        {
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;

            // update iphone with mobiles catagory

            var cat = db.Catagories.Find(1);
            var p = db.Products.Find(2);
            p.TheCatagory = cat;
            db.SaveChanges();
        }

        private static void ProductWithExistingCatagory()
        {
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;

            // Add new product with existing catagory
            //var existingCat = db.Catagories.Find(1);
            var mobile = (from c in db.Catagories
                          where c.Name == "Mobiles"
                          select c).FirstOrDefault();
            var p = new Product { Name = "Galaxy Z Fold", Brand = "Samsung", Price = 78000, InStock = true, TheCatagory = mobile };
            db.Products.Add(p);
            db.SaveChanges();
        }

        private static void SaveProductAndCatagory()
        {
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;
            // add new product with new catagory

            var cat = new Catagory { Name = "Mobiles", Description = "Smart Devices" };

            var p = new Product { Name = "IPhone 13 Max", Price = 75000, Brand = "Apple", InStock = true, TheCatagory = cat };

            db.Products.Add(p);
            //db.Catagories.Add(cat);
            db.SaveChanges();
        }

        private static void Linq()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //table: numbers
            // column: number
            // sql: select number from numbers where number mod 2 = 0;

            // get all even numbers and disply
            // linq to objects

            var evenNumbers = from n in numbers
                              where n % 2 == 0
                              select n;


            List<int> evens = new List<int>();
            foreach (var item in numbers)
            {
                if (item % 2 == 0)
                    evens.Add(item);
            }

            foreach (var item in evens)
            {
                Console.WriteLine(item);
            }


            // search/select
            // get all products more than 1L
            ProductsDbContext db = new ProductsDbContext();
            // LINQ to Entities
            // SQL Select : select * from products where price >= 100000

            var costlyProducts = (from p in db.Products where p.Price >= 100000 select p).ToList();

            // Lambda expressions

            var cplist = db.Products.Where(p => p.Price >= 100000);


            foreach (var item in costlyProducts)
            {
                //Console.WriteLine($"{item.Name}\t{item.Price}");
            }

            var constliestProduct = (from p in db.Products orderby p.Price descending select p).FirstOrDefault();
            Console.WriteLine(constliestProduct.Name);

            int maxPrice = (from p in db.Products select p.Price).Max();
            var costliestProduct = from p in db.Products
                                   where p.Price == maxPrice
                                   select p;

            var result = from p in db.Products
                         where p.Price == (from i in db.Products select p.Price).Max()
                         select p;
        }

        private static void Edit()
        {
            // edit product by id
            ProductsDbContext db = new ProductsDbContext();
            var productToEdit = db.Products.Find(2);
            productToEdit.Price += 500;
            db.SaveChanges();
            Console.WriteLine("edited...");
        }

        private static void delete()
        {
            // delete product id 1
            // get the object to delete
            ProductsDbContext db = new ProductsDbContext();
            var productToDel = db.Products.Find(2);
            if (productToDel != null)
            {
                db.Products.Remove(productToDel);
                //db.SaveChanges();
                Console.WriteLine("delete");
            }
            else
                Console.WriteLine("not found");
        }

        private static void Get()
        {
            // get product by id
            ProductsDbContext db = new ProductsDbContext();
            var p = db.Products.Find(1);

            var pp = db.Products.Find(1);

            if (p == null)
                Console.WriteLine("Product not found");
            else
                Console.WriteLine(p.Name + "\t" + p.Price);
        }

        private static void Save()
        {
            // Add new product - Only OO

            Product p = new Product { Name = "IPhone 14 Plus 128GB", Price = 140000 };
            ProductsDbContext db = new ProductsDbContext();
            db.Products.Add(p);
            db.SaveChanges();
            Console.WriteLine("Saved...");
        }
    }
}
