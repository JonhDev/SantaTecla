using SantaTecla.Services;
using SantaTecla.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SantaTecla.WPF.Views
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        Login log = new Login();
        int key;
        public LoginPage()
        {
            InitializeComponent();
            
        }

        private async void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            key = await log.AccessAsync(usr.Text, pass.Password);

            if (key !=0 )
            {
                
                MessageBox.Show("BIENVENIDO");
                this.Hide();
                ControlWindow control = new ControlWindow();
                control.Show(key);
                this.Close();
            }
            else
                MessageBox.Show("usuario invalido");

        }
    }
}
