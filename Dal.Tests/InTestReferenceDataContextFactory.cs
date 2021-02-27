using DAL;
using Microsoft.EntityFrameworkCore;

namespace Dal.Tests
{
    public class InTestReferenceDataContextFactory
    {
        public ReferenceDataContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ReferenceDataContext>();
            optionsBuilder.UseSqlite(
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\temp\test_db\reference_db.mdf;Integrated Security=True;Connect Timeout=30");

            return new ReferenceDataContext(optionsBuilder.Options);
        }
    }
}