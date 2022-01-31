using Gringotts.Data.Entities;
using GringottsAPI.Model;

namespace GringottsAPI.Models
{
    /// <summary>
    /// New customer account output model
    /// </summary>
    public class GetAccountOutputModel : BaseResponse
    {
        /// <summary>
        /// New account object
        /// </summary>
        public Account Account { get; set; } = new Account();   
    }
}
