namespace CollectionsDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[10];
            products[0] = new Product();
            products[0].Id = 111;
            products[0].Name = "IPhone";
            products[0].Price = 34343;
        }
    }

    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
