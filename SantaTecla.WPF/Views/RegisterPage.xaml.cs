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
using System.Windows.Shapes;

namespace SantaTecla.WPF.Views
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
        ControlWindow control = new ControlWindow();
        public RegisterPage()
        {
            InitializeComponent();
            agregar.Click += Agregar_Click;
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(nombre.Text) || !String.IsNullOrEmpty(direccion.Text))
            {
                this.Hide();
                control.Show(1);
                this.Close();
            }
            else
                MessageBox.Show("informacion faltante");
        }
    }
}
