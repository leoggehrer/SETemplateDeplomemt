//@BaseCode
#if EXTERNALGUID_ON
namespace SETemplate.Common.Models
{
    partial class ModelObject
    {
        #region properties
        /// <summary>
        /// Gets or sets the unique identifier for the model object.
        /// </summary>
        public Guid Guid { get; set; }
        #endregion properties
    }
}
#endif