using Gringotts.Data.Entities;
using GringottsAPI.Model;

namespace GringottsAPI.Models
{
    /// <summary>
    /// Response model for all transactions of a customer between a time period
    /// </summary>
    public class ListTransactionsOfCustomerOutputModel : BaseResponse
    {
        /// <summary>
        /// List of transaction of the customer 
        /// </summary>
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
