using GringottsAPI.Model;

namespace GringottsAPI.Models
{
    /// <summary>
    /// Add new customer account output model
    /// </summary>
    public class AddAccountOutputModel : BaseResponse
    {
        /// <summary>
        /// The identity number of new customer account
        /// </summary>
        public int AccountId { get; set; }
        /// <summary>
        /// Create date of new customer account 
        /// </summary>
        public DateTime? CreateDate { get; set; }
    }
}
