using APIServer.Data;
using APIServer.Dtos;
using APIServer.Helper;
using APIServer.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace APIServer.Controllers
{
	[Route("api/v1")]
	[ApiController]
	public class APIController: ControllerBase
	{
		private readonly CustomerRepository _customerRepository;

		public APIController(OnlineShopDbContext context)
		{
			_customerRepository = new CustomerRepository(context);
		}

		[HttpPost("customer/add")]
		public async Task<IActionResult> AddCustomer(CustomerRequest customerRequest)
		{
			try
			{
				if(ModelState.IsValid)
				{
					if (!Utils.isValidPhoneNumber(customerRequest.PhoneNumber)) return BadRequest("Correct phone number");
					else if (!Utils.isValidEmail(customerRequest.Email)) return BadRequest("Correct email");

					var result = await _customerRepository.AddCustomer(customerRequest);
					return Ok("Add Customer Success!");
				}
				else
				{
					return BadRequest("Check if all fields are filled");
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("customer/search")]
		public async Task<IActionResult> AddContactInfo(string searchKey)
		{
			try
			{
				var result = await _customerRepository.SearchCustomerByPhoneOrEmail(searchKey);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
