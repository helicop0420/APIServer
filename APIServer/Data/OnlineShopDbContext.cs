using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

using APIServer.Models;

namespace APIServer.Data
{
	public class OnlineShopDbContext : DbContext
	{
		public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options)
		: base(options)
		{
			var dbCreater = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
			if (dbCreater != null)
			{
				// Create Database 
				if (!dbCreater.CanConnect())
				{
					dbCreater.Create();
				}

				// Create Tables
				if (!dbCreater.HasTables())
				{
					dbCreater.CreateTables();
				}
			}
		}

		public DbSet<Customer> Customers{ get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Customer>().HasData(
				new Customer() { 
					Id = 1, 
					FirstName = "Geraldo", 
					LastName = "Marques", 
					Email = "geraldomarques0966@gmail.com", 
					App = "App", 
					PhoneNumber = "1234567980", 
					Date=DateTime.Now });
		}
	}
}