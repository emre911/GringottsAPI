namespace GringottsAPI.Models
{
    /// <summary>
    /// New Transaction input model
    /// </summary>
    public class AddTransactionInputModel
    {
        public long AccountNumber { get; set; }
        public char TransactionType { get; set; } 
        public string Currency { get; set; }
        public decimal Amount { get; set; }
    }
}
