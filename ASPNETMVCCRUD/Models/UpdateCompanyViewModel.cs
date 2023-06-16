namespace ASPNETMVCCRUD.Models
{
	public class UpdateCompanyViewModel
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string ContactInfo { get; set; }
		public int NoOfEmployees { get; set; }
	}
}
