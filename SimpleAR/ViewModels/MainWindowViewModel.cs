// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The main window view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Configuration;
using SimpleAR.Factories;
using SimpleAR_DAL.Managers;

namespace SimpleAR.ViewModels
{
    /// <summary>
    /// The main window view model.
    /// </summary>
    public class MainWindowViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            if (CheckIfVisualStudioRunning())
            {
                return;
            }

            IntializeStatements();
            InitializeServiceTab();
            InitializeCustomerTab();
            InitializeLedgerTab();
        }

        /// <summary>
        /// The check if visual studio running.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CheckIfVisualStudioRunning()
        {
            try
            {
                var setting = ConfigurationManager.ConnectionStrings["MyDbCS"].ConnectionString;
            }
            catch (Exception)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets or sets the statement tab.
        /// </summary>
        public StatementViewModel StatementTab { get; set; }

        /// <summary>
        /// Gets the customers tab view model.
        /// </summary>
        public CustomersViewModel CustomersTab { get; private set; }

        /// <summary>
        /// Gets the service tab.
        /// </summary>
        public ServiceViewModel ServiceTab { get; private set; }

        /// <summary>
        /// Gets the ledger tab.
        /// </summary>
        public LedgerViewModel LedgerTab { get; private set; }

        /// <summary>
        /// The intialize statements.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        private void IntializeStatements()
        {
            var controller = ControllerFactory.CreateStatementController();
            StatementTab = ViewModelFactory.CreateStatementViewModel(controller);
        }

        /// <summary>
        /// The initialize service tab.
        /// </summary>
        private void InitializeServiceTab()
        {
            var controller = ControllerFactory.CreateServiceController();
            ServiceTab = ViewModelFactory.CreateServiceViewModel(controller);
        }

        /// <summary>
        /// The initialize customer tab.
        /// </summary>
        private void InitializeCustomerTab()
        {
            var controller = ControllerFactory.CreateCustomerController();
            CustomersTab = ViewModelFactory.CreateCustomerViewModel(controller);
        }

        /// <summary>
        /// The initialize ledger tab.
        /// </summary>
        private void InitializeLedgerTab()
        {
            var controller = ControllerFactory.CreateLedgerController();
            LedgerTab = ViewModelFactory.CreateLedgerViewModel(controller);

        }

    }
}
