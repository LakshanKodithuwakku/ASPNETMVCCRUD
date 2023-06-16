namespace ASPNETMVCCRUD.Models.Domain
{
    public class Company
    {
        public Guid Id { get; set; } // Unique identifier for the company
        public string Name { get; set; } 
        public string Address { get; set; }
        public string ContactInfo { get; set; }
        public int NoOfEmployees { get; set; }
    }
}
