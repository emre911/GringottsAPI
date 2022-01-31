using GringottsAPI.Model;

namespace GringottsAPI.Models
{
    /// <summary>
    /// Add new transaction output model
    /// </summary>
    public class AddTransactionOutputModel : BaseResponse
    {
        /// <summary>
        /// The identity number of new customer account
        /// </summary>
        public int TransactionId { get; set; }
        /// <summary>
        /// Create date of new customer account 
        /// </summary>
        public DateTime? CreateDate { get; set; }
    }
}
