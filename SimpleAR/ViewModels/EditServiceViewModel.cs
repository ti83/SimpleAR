using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SimpleAR.Common;

namespace SimpleAR.ViewModels
{
    public class EditServiceViewModel
    {
        public EditServiceViewModel()
        {
            SaveCommand = new DelegateCommand(HandleSaveCommand);
        }

        public string ServiceName { get; set; }
        public decimal PricePerUnit { get; set; }
        public string UnitType { get; set; }

        #region ICommand Properties

        public ICommand SaveCommand { get; set; }

        #endregion

        #region ICommand Methods

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
