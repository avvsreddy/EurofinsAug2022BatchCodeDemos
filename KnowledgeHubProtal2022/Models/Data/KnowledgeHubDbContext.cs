using KnowledgeHubProtal2022.Models.Entities;
using System.Data.Entity;

namespace KnowledgeHubProtal2022.Models.Data
{
    public class KnowledgeHubDbContext : DbContext
    {

        // configure the db
        public KnowledgeHubDbContext() : base("name=DefaultConnection")
        {

        }

        // configure the tables
        public DbSet<Catagory> Catagories { get; set; }

    }
}