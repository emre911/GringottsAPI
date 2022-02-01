namespace GringottsAPI.Models
{
    /// <summary>
    /// List transactions of customer input model
    /// </summary>
    public class ListTransactionsOfCustomerInputModel
    {
        public long CustomerNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
