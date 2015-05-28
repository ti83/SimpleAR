// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DelegateCommand.cs" company="">
//   
// </copyright>
// <summary>
//   The delegate command.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Windows.Input;

namespace SimpleAR.Common
{
    /// <summary>
    /// The delegate command.
    /// </summary>
    public class DelegateCommand : ICommand
    {
        /// <summary>
        /// The can execute.
        /// </summary>
        Func<object, bool> canExecute;

        /// <summary>
        /// The execute action.
        /// </summary>
        Action<object> executeAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="executeAction">
        /// The execute action.
        /// </param>
        public DelegateCommand(Action<object> executeAction)
            : this(executeAction, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="executeAction">
        /// The execute action.
        /// </param>
        /// <param name="canExecute">
        /// The can execute.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecute)
        {
            if (executeAction == null)
            {
                throw new ArgumentNullException("executeAction");
            }

            this.executeAction = executeAction;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// The can execute.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            bool result = true;
            Func<object, bool> canExecuteHandler = this.canExecute;
            if (canExecuteHandler != null)
            {
                result = canExecuteHandler(parameter);
            }

            return result;
        }

        /// <summary>
        /// The can execute changed.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// The raise can execute changed.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            EventHandler handler = this.CanExecuteChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        public void Execute(object parameter)
        {
            this.executeAction(parameter);
        }
    }
}
