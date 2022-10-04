using System.Data.Entity;

namespace ContactsManagementConsoleApp.Data
{
    public partial class ContactsDbContext : DbContext
    {
        public ContactsDbContext()
            : base("name=ContactsDbContext")
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Contact>()
                .Property(e => e.Mobile)
                .IsFixedLength();

            modelBuilder.Entity<Contact>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Contact>()
                .Property(e => e.Location)
                .IsFixedLength();
        }
    }
}
