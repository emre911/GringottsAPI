using Gringotts.Data.Entities;
using GringottsAPI.Model;

namespace GringottsAPI.Models
{
    /// <summary>
    /// Response model for all transactions of an account
    /// </summary>
    public class ListTransactionsOfAccountOutputModel : BaseResponse
    {
        /// <summary>
        /// List of transactions of an account
        /// </summary>
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
