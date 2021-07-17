using BR.Rodobens.Migration.Infra.Data.Core.Extensions;
using BR.Rodobens.Migration.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using BR.Rodobens.Migration.Domain.Aggregates.Users.PartnerType;
using BR.Rodobens.Migration.Domain.Aggregates.Users.UserPersonal;
using BR.Rodobens.Migration.Domain.Aggregates.Users.UserRegister;

namespace BR.Rodobens.Migration.Infra.Data.Context
{
    public class DatabaseContext : DbContext
    {
       
        public DbSet<PartnerType> PartnerTypes { get; set; }
        public DbSet<UserRegister> UserRegisters { get; set; }
        public DbSet<UserPersonal> UserPersonals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new PartnerTypeMap());
            modelBuilder.AddConfiguration(new UserPersonalMap());
            modelBuilder.AddConfiguration(new UserRegisterMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.EnableSensitiveDataLogging(false);
            optionsBuilder.UseMySql(config.GetConnectionString("DefaultConnection"), opt => opt.EnableRetryOnFailure());
        }
    }
}
