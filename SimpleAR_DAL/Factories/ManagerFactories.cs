// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManagerFactories.cs" company="">
//   
// </copyright>
// <summary>
//   The manager factories.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using SimpleAR_DAL.Managers;

namespace SimpleAR_DAL.Factories
{
    /// <summary>
    /// The manager factories.
    /// </summary>
    public class ManagerFactories
    {
        /// <summary>
        /// The create context manager.
        /// </summary>
        /// <returns>
        /// The <see cref="ContextManager"/>.
        /// </returns>
        public static ContextManager CreateContextManager()
        {
            return new ContextManager();
        }
    }
}
