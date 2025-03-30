//@BaseCode
#if ACCOUNT_ON
namespace SETemplate.Logic.DataContext
{
    partial class EntitySet<TEntity>
    {
        #region properties
        /// <summary>
        /// Sets the session token.
        /// </summary>
        public string SessionToken
        {
            internal get => Context.SessionToken;
            set => Context.SessionToken = value;
        }
        #endregion properties
    }
}
#endif