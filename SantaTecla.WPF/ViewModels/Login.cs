using SantaTecla.WPF.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SantaTecla.WPF.ViewModels
{
    public class Login
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string Visible { get; set; }
        public LoginCommand Display { get; private set; }
        public Login()
        {
            Display = new LoginCommand(Execute,CanExecute);
        }

        public bool CanExecute(object param)
        {
            return true;
        }

        public void Execute(object param)
        {
            User = "asdfasdfasdf";
            Password="asdfasdfasdf2";
            
            MessageBox.Show("");
        }



    }
}
