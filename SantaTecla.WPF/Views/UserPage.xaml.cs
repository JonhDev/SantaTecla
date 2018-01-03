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
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Window
    {
        ControlWindow control = new ControlWindow();
        public UserPage()
        {
            InitializeComponent();
            consulta.Click += Consulta_Click;
        }

        private void Consulta_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(paciente.Text))
            {
                this.Hide();
                control.Show(9);
                this.Close();

            }
            else
                MessageBox.Show("ingrese paciente");
        }
    }
}
