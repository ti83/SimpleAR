using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SimpleAR.Interfaces;

namespace SimpleAR.DialogService
{
    /// <summary>
    /// The message dialog class.
    /// </summary>
    public class MessageDialog : IMessageDialog
    {
        /// <summary>
        /// Show simple error.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        public void ShowSimpleError(string message, string title)
        {
            MessageBox.Show(message,title,MessageBoxButton.OK,MessageBoxImage.Error);
        }
    }
}
