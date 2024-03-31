
namespace CleanArchitecture.Domain.Common
{
    /// <summary>
    /// BaseDomainModel Class
    /// </summary>
    public abstract class BaseDomainModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// DateCreated
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// CreatedBy
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// LastModifiedDate
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// LastModifiedBy
        /// </summary>
        public string? LastModifiedBy { get; set; }
    }
}
