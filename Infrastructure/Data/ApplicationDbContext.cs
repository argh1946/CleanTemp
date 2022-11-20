using Core.Contracts;
using Core.Entities;
using Core.Helper;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public ApplicationDbContext() { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            //builder.ApplyConfiguration(new StatusCfg());
            var entitiesAssembly = typeof(BaseEntity).Assembly;
            builder.RegisterEntityTypeConfiguration(entitiesAssembly);

        }

        //public DbSet<AtmCrs> AtmCrs { get; set; }
       

    }
}
