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
    /// Interaction logic for RecepcionWindow.xaml
    /// </summary>
    public partial class RecepcionWindow : Window
    {
        ControlWindow control = new ControlWindow();
        public RecepcionWindow()
        {
            InitializeComponent();
            agregar.Click += Agregar_Click;
            actualizar.Click += Agregar_Click;
            consulta.Click += Consulta_Click;
        }

        private void Consulta_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            control.Show(3);
            this.Close();
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            control.Show(2);
            this.Close();
        }
    }
}
