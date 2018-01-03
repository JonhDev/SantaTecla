using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SantaTecla.WPF.ViewModels.Commands
{
    public class LoginCommand : ICommand
    {
        public Action<object> ExecuteMethod { get; set; }
        public Func<object, bool> CanExecuteMethod { get; set; }

        public LoginCommand(Action<object> executeMethod, Func<object, bool> canExecuteMethod)
        {
            this.ExecuteMethod = executeMethod;
            this.CanExecuteMethod = canExecuteMethod;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return CanExecuteMethod(parameter);
        }

        public void Execute(object parameter)
        {
            ExecuteMethod(parameter);
        }
    }
}
