using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsCatalogConsoleApp.Entities
{
    public class Product
    {
        //[Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public string Brand { get; set; }

        public bool InStock { get; set; }
        public virtual Catagory TheCatagory { get; set; }

        public virtual List<Supplier> Suppliers { get; set; } = new List<Supplier>();
    }

    public class Catagory
    {
        public int CatagoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<Product> Products { get; set; } = new List<Product>();

    }


    public class Supplier
    {
        public int SupplierID { get; set; }
        public string Name { get; set; }
        public string GST { get; set; }
        public int Rating { get; set; }
        public virtual List<Product> Products { get; set; } = new List<Product>();
        public Address Address { get; set; }
    }

    [ComplexType]
    public class Address
    {
        public string Area { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
