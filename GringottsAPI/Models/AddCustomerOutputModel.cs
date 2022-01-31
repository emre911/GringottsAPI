namespace GringottsAPI.Model
{
    /// <summary>
    /// Add new customer output model
    /// </summary>
    public class AddCustomerOutputModel : BaseResponse
    {
        public int CustomerId { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
