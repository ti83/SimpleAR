using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SimpleAR.Common;
using SimpleAR.Factories;
using SimpleAR.Interfaces;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.ViewModels
{
    public class StatementViewModel : INotifyPropertyChanged
    {
        public StatementViewModel()
        {
            _CurrentCursor = Cursors.Arrow;
        }

        public StatementViewModel(IStatementController controller)
        {
            _CurrentCursor = Cursors.Arrow;
            Controller = controller;
            GenerateReportCommand = new DelegateCommand(HandleGenerateReportCommand);
        }

        private IStatementController Controller;

        public DateTime? StartDate
        {
            get
            {
                if (Controller == null) return null;
                return Controller.StartDate;
            }
            set
            {
                Controller.StartDate = value;
                OnPropertyChanged("StartDate");
            }
        }

        public DateTime? EndDate
        {
            get
            {
                if (Controller == null) return null;
                return Controller.EndDate;
            }
            set
            {
                Controller.EndDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        private Cursor _CurrentCursor { get; set; }

        public Cursor CurrentCursor
        {
            get
            {
                return _CurrentCursor;                
            }
            set
            {
                _CurrentCursor = value;
                OnPropertyChanged("CurrentCursor");
            }
        }

        public List<CustomerStatementViewModel> Statements { get; set; }

        #region ICommand Properties

        /// <summary>
        /// Gets or sets the add new customer command.
        /// </summary>
        public ICommand GenerateReportCommand { get; set; }

        #endregion

        #region ICommand Methods

        /// <summary>
        /// The handle add new customer command.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void HandleGenerateReportCommand(object obj)
        {
            if (StartDate == null)
            {
                MessageBox.Show("Please specify a start date for the report.");
                return;
            }

            if (EndDate == null)
            {
                MessageBox.Show("Please specify a end date for the report.");
                return;
            }

            CurrentCursor = Cursors.Wait;

            var customers = Controller.GetStatementsForDateRange();
            Statements = ViewModelFactory.CreateCustomerStatementViewModelList(customers);

            CurrentCursor = Cursors.Arrow;
            OnPropertyChanged("Statements");
        }

        #endregion


        #region Implement INotifyPropertyChanged

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

    }
}
