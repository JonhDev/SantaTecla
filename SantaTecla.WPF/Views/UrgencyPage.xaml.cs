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
    /// Interaction logic for UrgencyPage.xaml
    /// </summary>
    public partial class UrgencyPage : Window
    {
        
        public UrgencyPage()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(info.Text))
            {
                MessageBox.Show("Listo");
                LoginPage login = new LoginPage();
                login.Show();
                this.Close();
            }
            else
                MessageBox.Show("Cuadro vacio");
        }
    }
}
