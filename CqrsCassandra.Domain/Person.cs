namespace CqrsCassandra.Domain
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string CountryCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string DistrictName { get; set; }
        public int DistrictId { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}