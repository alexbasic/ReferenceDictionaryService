using DAL;
using Microsoft.EntityFrameworkCore;

namespace Dal.Tests
{
    public class InTestReferenceDataContextFactory
    {
        public ReferenceDataContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ReferenceDataContext>();
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=E:\TEMP\TEST_DB\REFERENCE_DB.MDF;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False");

            return new ReferenceDataContext(optionsBuilder.Options);
        }
    }
}