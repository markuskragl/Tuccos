using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Windows
{
    /// <summary>
    /// Hides a method used for Command Binding in WPF.
    /// </summary>
    public class Command : System.Windows.Input.ICommand
    {
        /// <summary>
        /// Internal field for the method to be executed.
        /// </summary>
        private System.Action<object> _ExecuteMethod = null;

        /// <summary>
        /// Internal field for the method checking if Execute is possible
        /// </summary>
        private System.Predicate<object> _CanExecuteMethod = null;

        /// <summary>
        /// Raises if the state of CanExecute was changed...
        /// </summary>
        /// <remarks>Linked to the CommandManager.</remarks>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                System.Windows.Input.CommandManager.RequerySuggested += value;
            }
            remove
            {
                System.Windows.Input.CommandManager.RequerySuggested -= value;
            }
        }

        /// <summary>
        /// Returns a boolean if the Execute method is possible.
        /// </summary>
        /// <param name="parameter">Information of data binding</param>
        public bool CanExecute(object parameter)
        {
            return this._CanExecuteMethod == null ? true : this._CanExecuteMethod(parameter);
        }

        /// <summary>
        /// Calls the method hidden in this command.
        /// </summary>
        /// <param name="parameter">Data from data binding</param>
        public void Execute(object parameter)
        {
            this._ExecuteMethod(parameter);
        }

        /// <summary>
        /// Initializes a new object.
        /// </summary>
        /// <param name="executeMethod">Delegte to the method which should be executed.</param>
        public Command(System.Action<object> executeMethod) : this(executeMethod, null)
        {

        }

        /// <summary>
        /// Initializes a new object.
        /// </summary>
        /// <param name="executeMethod">Delegate to the method which should be executed.</param>
        /// <param name="canExecuteMethod">Delegate to the method which checks if the
        /// command is allowed to be executed.</param>
        public Command(System.Action<object> executeMethod, System.Predicate<object> canExecuteMethod)
        {
            this._ExecuteMethod = executeMethod;
            this._CanExecuteMethod = canExecuteMethod;
        }
    }
}
