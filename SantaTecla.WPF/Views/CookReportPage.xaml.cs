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
    /// Interaction logic for CookReportPage.xaml
    /// </summary>
    public partial class CookReportPage : Window
    {
        ControlWindow Control = new ControlWindow();
        public CookReportPage()
        {
            InitializeComponent();
            generar.Click += Generar_Click;
        }

        private void Generar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Control.Show(5);
            this.Close();
        }
    }
}
