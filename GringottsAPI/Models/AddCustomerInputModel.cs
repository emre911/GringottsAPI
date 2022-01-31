namespace GringottsAPI.Model
{
    /// <summary>
    /// Add new customer input model
    /// </summary>
    public class AddCustomerInputModel
    {
        public int CustomerNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int YearBirth { get; set; }
        public char Gender { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
