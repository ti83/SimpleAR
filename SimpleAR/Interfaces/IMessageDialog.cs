using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAR.Interfaces
{
    /// <summary>
    /// The MessageDialog interface.
    /// </summary>
    public interface IMessageDialog
    {
        /// <summary>
        /// The show simple error.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        void ShowSimpleError(string message, string title);
    }
}
