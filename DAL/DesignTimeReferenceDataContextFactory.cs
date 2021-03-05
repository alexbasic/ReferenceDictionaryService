using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL
{
    public class DesignTimeReferenceDataContextFactory : IDesignTimeDbContextFactory<ReferenceDataContext>
    {
        public ReferenceDataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ReferenceDataContext>();
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=E:\TEMP\TEST_DB\REFERENCE_DB.MDF;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False"
                );

            return new ReferenceDataContext(optionsBuilder.Options);
        }
    }

/*
 * Simple help
 * -----------
 * 
 * PS>Install-Package Microsoft.EntityFrameworkCore.Tools
 * 
 * Add-Migration Initial
 * Remove-Migration
 * Update-Database
 */
}
