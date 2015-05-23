using SimpleAR.Controllers;
using SimpleAR.Interfaces;

namespace SimpleAR.Factories
{
    /// <summary>
    /// The controller factory.
    /// </summary>
    public class ControllerFactory
    {
        /// <summary>
        /// The create customer controller.
        /// </summary>
        /// <returns>
        /// The <see cref="ICustomerController"/>.
        /// </returns>
        public static ICustomerController CreateCustomerController()
        {
            return new CustomerController();
        }
    }
}
