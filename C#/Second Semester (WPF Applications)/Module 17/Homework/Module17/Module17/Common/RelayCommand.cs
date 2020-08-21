using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Module17.Common
{
    public class RelayCommand<T> : ICommand
    {
        #region Fields
        readonly Action<T> m_execute = null;
        readonly Predicate<T> m_canExecute = null;
        #endregion

        #region Constructors
        public RelayCommand(Action<T> execute) : this(execute, null)
        {

        }
        public RelayCommand(Action<T> _execute, Predicate<T> _canExecute)
        {
            if (_execute == null)
                throw new ArgumentNullException("execute");

            m_execute = _execute;
            m_canExecute = _canExecute;
        }
        #endregion

        #region ICommand Members
        ///<summary>
        ///Defines the method that determines whether the command can execute in its current state.
        ///</summary>
        ///<param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        ///<returns>
        ///true if this command can be executed; otherwise, false.
        ///</returns>
        public bool CanExecute(object parameter)
        {
            return m_canExecute is null || m_canExecute((T)parameter);
        }

        ///<summary>
        ///Occurs when changes occur that affect whether or not the command should execute.
        ///</summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        ///<summary>
        ///Defines the method to be called when the command is invoked.
        ///</summary>
        ///<param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to <see langword="null" />.
        ///</param>
        public void Execute(object parameter)
        {
            m_execute((T)parameter);
        }
        #endregion
    }
}
