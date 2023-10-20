using System.ComponentModel.DataAnnotations;

namespace APIServer.Models
{
	public class Customer
	{
		[Key]
		public int Id { get; set; }
		
		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public string PhoneNumber { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public string App { get; set; }

		[Required]
		public DateTime Date { get; set; } = DateTime.Now;
	}
}
