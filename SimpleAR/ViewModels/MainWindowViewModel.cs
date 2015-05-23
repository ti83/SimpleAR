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
            InitializeServiceTab();
            InitializeCustomerTab();
        }

        /// <summary>
        /// Gets the customers tab view model.
        /// </summary>
        public CustomersViewModel CustomersTab { get; private set; }

        /// <summary>
        /// Gets the service tab.
        /// </summary>
        public ServiceViewModel ServiceTab { get; private set; }

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


    }
}
