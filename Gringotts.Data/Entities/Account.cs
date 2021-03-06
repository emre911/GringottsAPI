namespace Gringotts.Data.Entities
{
    public class Account : BaseEntity
    {
        public string AccountName { get; set; }
        public long AccountNumber { get; set; }
        public short AccountType { get; set; }
        public long CustomerNumber { get; set; }
        public string Currency { get; set; }
        public decimal BeginBalance { get; set; }
        public decimal Balance { get; set; }
        public DateTime? DateOpened { get; set; }
        public DateTime? DateClosed { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}
