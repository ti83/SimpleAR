// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditCustomerViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The edit customer view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Windows;
using System.Windows.Input;
using SimpleAR.Common;

namespace SimpleAR.ViewModels
{
    /// <summary>
    /// The edit customer view model.
    /// </summary>
    public class EditCustomerViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditCustomerViewModel"/> class.
        /// </summary>
        public EditCustomerViewModel()
        {
            SaveCommand = new DelegateCommand(HandleSaveCommand);
        }

        /// <summary>
        /// Gets or sets the customer name.
        /// </summary>
        public string CustomerName { get; set; }

        #region ICommand Properties

        /// <summary>
        /// Gets or sets the save command.
        /// </summary>
        public ICommand SaveCommand { get; set; }

        #endregion

        #region ICommand Methods

        /// <summary>
        /// The handle save command.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void HandleSaveCommand(object obj)
        {
            var window = obj as Window;
            if (window != null)
            {
                window.DialogResult = true;
                window.Close();                
            }
        }



        #endregion

    }
}
