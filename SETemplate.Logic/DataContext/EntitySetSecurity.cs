//@BaseCode
#if ACCOUNT_ON
using SETemplate.Logic.Modules.Security;
using System.Reflection;

namespace SETemplate.Logic.DataContext
{
    [Authorize]
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

        #region methods
        partial void BeforeAccessing(MethodBase methodBase)
        {
            bool handled = false;

            BeforeAccessingHandler(methodBase, ref handled);
            if (handled == false)
            {
                System.Diagnostics.Debug.WriteLine($"Before accessing {methodBase.Name}");
            }
        }
        #endregion methods

        #region partial methods
        partial void BeforeAccessingHandler(MethodBase methodBase, ref bool handled);
        #endregion partial methods
    }
}
#endif