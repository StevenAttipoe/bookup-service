using System;
using System.Reflection.Emit;
using bookup_service.Models;
using Microsoft.EntityFrameworkCore;

namespace bookup_service
{
	public class ApplicationDbContext: DbContext
	{
        protected readonly IConfiguration Configuration;

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(builder);
        }


        public virtual DbSet<User> Users { get; set; }
	}
}

