using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsCatalogConsoleApp.Entities
{
    //[Table("tbl_products")]
    public class Product
    {
        //[Key]
        public int ProductID { get; set; }
        [Required]
        [MaxLength(50)]
        //[Column("product_name")]
        public string Name { get; set; }
        public int Price { get; set; }
        [NotMapped]
        public int ProfitMargin { get; set; }
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

    //[Table("Suppliers")]
    public class Supplier : Person
    {
        //public int SupplierID { get; set; }
        //public string Name { get; set; }
        public string GST { get; set; }
        public int Rating { get; set; }
        public virtual List<Product> Products { get; set; } = new List<Product>();
        //public Address Address { get; set; }
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
    //TPC

    abstract public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonID { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }

    //[Table("Customers")]
    public class Customer : Person
    {
        public int Discount { get; set; }
        public string Type { get; set; }
    }
}
