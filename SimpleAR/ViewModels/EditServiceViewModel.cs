// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditServiceViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The edit service view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Windows;
using System.Windows.Input;
using SimpleAR.Common;

namespace SimpleAR.ViewModels
{
    /// <summary>
    /// The edit service view model.
    /// </summary>
    public class EditServiceViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditServiceViewModel"/> class.
        /// </summary>
        public EditServiceViewModel()
        {
            SaveCommand = new DelegateCommand(HandleSaveCommand);
        }

        /// <summary>
        /// Gets or sets the service name.
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets or sets the price per unit.
        /// </summary>
        public decimal PricePerUnit { get; set; }

        /// <summary>
        /// Gets or sets the unit type.
        /// </summary>
        public string UnitType { get; set; }

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
