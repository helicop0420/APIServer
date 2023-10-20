using APIServer.Data;
using APIServer.Dtos;
using APIServer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Reflection;

namespace APIServer.Repositories
{
	public class CustomerRepository
	{
		private readonly OnlineShopDbContext _context;

		public CustomerRepository(OnlineShopDbContext context) { 
			_context = context;
		}
		
		public async Task<List<Customer>> SearchCustomerByPhoneOrEmail(string searchKey)
		{
			var filteredCustomers = _context.Customers.Where(item => EF.Functions.Like(item.PhoneNumber, "%" + searchKey + "%") || EF.Functions.Like(item.Email, "%" + searchKey + "%")).ToList();

			return filteredCustomers;
		}

		public async Task<bool> AddCustomer(CustomerRequest model)
		{
			Customer newCustomer = new Customer()
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				Email = model.Email,
				PhoneNumber = model.PhoneNumber,
				App = model.App,
				Date = model.Date
			};
			_context.Customers.Add(newCustomer);
			_context.SaveChanges();

			return true;
		}
	}
}
