using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSample.DAL
{
    /// <summary>
    /// Design-time factory for ECommerceDbContext
    /// </summary>
    public class ECommerceDbContextFactory : IDesignTimeDbContextFactory<ECommerceDbContext>
    {
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
