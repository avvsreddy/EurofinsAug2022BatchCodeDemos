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
    }

    public class Catagory
    {
        public int CatagoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
