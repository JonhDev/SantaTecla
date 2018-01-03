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
    /// Lógica de interacción para OptionDr.xaml
    /// </summary>
    public partial class OptionDr : Window
    {
        ControlWindow control = new ControlWindow();
        public OptionDr()
        {
            InitializeComponent();

            reporte.Click += Reporte_Click;
            consulta.Click += Consulta_Click;
            cerrar.Click += Cerrar_Click;

        }

        private void Consulta_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            control.Show(3);
            this.Close();
        }

        private void Cerrar_Click(object sender, RoutedEventArgs e)
        {
            LoginPage login = new LoginPage();
            login.Show();
            this.Close();
        }

        private void Reporte_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            control.Show(8);
            this.Close();
        }
    }
}
