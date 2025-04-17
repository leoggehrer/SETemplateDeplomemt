//@BaseCode
namespace SETemplate.Common.Contracts
{
    /// <summary>
    /// Represents an identifiable in the company manager.
    /// </summary>
    public partial interface IIdentifiable
    {
        #region Properties
#if EXTERNALGUID_OFF
        /// <summary>
        /// Gets the unique identifier for the entity.
        /// </summary>
        IdType Id { get; protected set; }
#else
        /// <summary>
        /// Gets the unique identifier for the entity.
        /// </summary>
        Guid Guid { get; protected set; }
#endif
        #endregion Properties
    }
}
