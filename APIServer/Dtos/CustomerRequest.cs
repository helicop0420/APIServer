namespace APIServer.Dtos
{
	public class CustomerRequest
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string App { get; set; }
		public DateTime Date { get; set; } = DateTime.Now;
	}
}
