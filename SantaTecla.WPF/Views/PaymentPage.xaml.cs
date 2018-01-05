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
    public partial class PaymentPage : Window
    {
        public PaymentPage()
        {
            InitializeComponent();
            ListBoxPayment.ItemsSource = new List<string>()
            {
                "Forma de pago",
                "Tarjeta",
                "Efectivo"
            };

            aceptar.Click +=(sourse,e)=>
            {
                Close();
            };
        }
    }
}
