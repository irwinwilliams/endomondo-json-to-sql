using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;

namespace EndomondoJsonToSQL
{
    public class EndomondoContext : DbContext
    {
        public EndomondoContext()
        {
            
        }
        public EndomondoContext(DbContextOptions options) 
            : base(options)
        {

        }
        public EndomondoContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public DbSet<EndomondoWorkout> Workouts { get; set; }
        public IConfiguration Configuration { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
    }

    public class EndomondoContextFactory : IDesignTimeDbContextFactory<EndomondoContext>
{
    public EndomondoContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EndomondoContext>();
        optionsBuilder.UseSqlServer(args[0]);

        return new EndomondoContext(optionsBuilder.Options);
    }
}
}