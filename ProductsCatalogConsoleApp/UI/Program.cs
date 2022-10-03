using ProductsCatalogConsoleApp.Data;
using ProductsCatalogConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductsCatalogConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
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
