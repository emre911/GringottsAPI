using Gringotts.Data.Entities;
using GringottsAPI.Model;


namespace GringottsAPI.Models
{
    /// <summary>
    /// Response model for all accounts information of customer
    /// </summary>
    public class GetAllAccountsOfCustomerOutputModel : BaseResponse
    {
        /// <summary>
        /// List of accounts of the customer 
        /// </summary>
        public List<Account> Accounts { get; set; } = new List<Account>();
    }
}
