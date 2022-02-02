using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ECommerceSample.DAL
{
    /// <summary>
    /// Design-time factory for ECommerceDbContext to apply migrations
    /// </summary>
    public class ECommerceDbContextFactory : IDesignTimeDbContextFactory<ECommerceDbContext>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="args">connection string</param>
        /// <returns></returns>
        public ECommerceDbContext CreateDbContext(string[] args)
        {
            var connectionString = args == null || args.Length == 0
                ? "dummy"
                : args[0].Trim();

            var optionsBuilder = new DbContextOptionsBuilder<ECommerceDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ECommerceDbContext(optionsBuilder.Options);
        }
    }
}
