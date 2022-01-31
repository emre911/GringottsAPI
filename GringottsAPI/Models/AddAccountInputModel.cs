namespace GringottsAPI.Models
{
    /// <summary>
    /// New Account input model
    /// </summary>
    public class AddAccountInputModel
    {
        public long AccountNumber { get; set; }
        public string AccountName { get; set; }
        public int CustomerNumber { get; set; }
        public short AccountType { get; set; }
        public string Currency { get; set; }
        public string? Description { get; set; }
        public decimal BeginBalance { get; set; }
        public DateTime? DateOpened { get; set; }
    }
}
