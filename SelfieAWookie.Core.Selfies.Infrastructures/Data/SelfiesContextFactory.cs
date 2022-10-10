using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Infrastructures.Data
{
    public class SelfiesContextFactory : IDesignTimeDbContextFactory<SelfiesContext>
    {
        #region Public Methods
        public SelfiesContext CreateDbContext(string[] args)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

            configurationBuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "Settings", "AppSettings.json"));

            IConfigurationRoot configurationRoot = configurationBuilder.Build();

            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(configurationRoot.GetConnectionString("SelfiesDatabase")/*, b => b.MigrationsAssembly("SelfieAWookie.Core.Selfies.Data.Migrations")*/);

            builder.UseSqlServer();

            SelfiesContext context = new SelfiesContext(builder.Options);

            return context;
        }
        #endregion
    }
}
