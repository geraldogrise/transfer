using BR.ITAU.TRANSFER.Infra.Data.Core.Extensions;
using BR.ITAU.TRANSFER.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using IBM.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using BR.ITAU.TRANSFER.API.Domain.Aggregates.IM.Curva;

namespace BR.ITAU.TRANSFER.Infra.Data.Context
{
    public class DatabaseContext : DbContext
    {
        
		public DbSet<Curva> Curvas { get; set; }	
      
 	    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
			modelBuilder.AddConfiguration(new CurvaMap());	
            base.OnModelCreating(modelBuilder);
        }
		
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.EnableSensitiveDataLogging(false);
            optionsBuilder.UseDb2(config.GetConnectionString("DefaultConnection"), opt => opt.CommandTimeout(120));
        }
    }
}