using SimpleAR.Factories;

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
            InitializeCustomerTab();
        }

        /// <summary>
        /// Gets the customers tab view model.
        /// </summary>
        public CustomersViewModel CustomersTab { get; private set; }

        /// <summary>
        /// The initialize customer tab.
        /// </summary>
        private void InitializeCustomerTab()
        {
            var controller = ControllerFactory.CreateCustomerController();
            CustomersTab = ViewModelFactory.CreateCustomerViewModel(controller);
        }

    }
}
