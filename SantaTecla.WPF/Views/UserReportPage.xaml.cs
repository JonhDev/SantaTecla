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
    /// Interaction logic for UserReportPage.xaml
    /// </summary>
    public partial class UserReportPage : Window
    {
        ControlWindow Control = new ControlWindow();
        public UserReportPage()
        {
            InitializeComponent();
            
            listo.Click += Listo_Click;
        }

        private void Listo_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(diagnostico.Text))
            {
                if (StaticHelper.OptionReturn == 5)//NO esta lista
                {
                    this.Hide();
                    Control.Show(14);
                    this.Close();
                }
            }
            else
                MessageBox.Show("Cuadro vacio");
        }
    }
}
