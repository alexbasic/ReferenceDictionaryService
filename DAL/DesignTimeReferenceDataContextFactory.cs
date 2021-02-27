using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL
{
    public class DesignTimeReferenceDataContextFactory : IDesignTimeDbContextFactory<ReferenceDataContext>
    {
        public ReferenceDataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ReferenceDataContext>();
            optionsBuilder.UseSqlite(
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\temp\test_db\reference_db.mdf;Integrated Security=True;Connect Timeout=30");

            return new ReferenceDataContext(optionsBuilder.Options);
        }
    }
}
