namespace ProductsCatalogConsoleApp.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductsCatalogConsoleApp.Data.ProductsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ProductsCatalogConsoleApp.Data.ProductsDbContext";
        }

        protected override void Seed(ProductsCatalogConsoleApp.Data.ProductsDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
