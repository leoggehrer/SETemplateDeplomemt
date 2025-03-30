//@BaseCode
#if ACCOUNT_ON
namespace SETemplate.Logic.DataContext
{
    partial class ProjectDbContext
    {
        #region fields
        private string? _sessionToken;
        #endregion fields

        #region properties
        /// <summary>
        /// Sets the session token.
        /// </summary>
        public string SessionToken
        {
            internal get => _sessionToken ?? string.Empty;
            set
            {
                _sessionToken = value;
            }
        }
        #endregion properties

        #region constructors
        public ProjectDbContext(string sessionToken)
        {
            SessionToken = sessionToken;
            Constructing();

            Constructed();
        }
        #endregion constructors
    }
}
#endif