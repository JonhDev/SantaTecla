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
using SantaTecla.Models;

namespace SantaTecla.WPF.Views
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class PaymentPage : Window
    {

        public delegate void OnSelectedPayment(object sender, PaymentEventArgs args);

        public event OnSelectedPayment OnSelectedPaymentEvent;

        public PaymentPage()
        {
            InitializeComponent();

            aceptar.Click +=(sourse,e)=>
            {
                Payment payment = new Payment();
                if (Tarjeta.IsChecked.Value)
                {
                    payment.PaymentType = PaymentOptions.Tarjeta;
                    payment.CVV = TarjetaCVV.Text;
                    payment.Fecha = TarjetaFecha.Text;
                    payment.NumTarjeta = TarjetaNum.Text;
                    payment.Titular = TarjetaTitular.Text;
                }

                if (Efectivo.IsChecked.Value)
                    payment.PaymentType = PaymentOptions.Efectivo;
                if (Seguro.IsChecked.Value)
                    payment.PaymentType = PaymentOptions.Seguro;
                OnSelectedPaymentEvent?.Invoke(this, new PaymentEventArgs(){SelectedPayment = payment});
                Close();
            };
        }


    }

    public class PaymentEventArgs : EventArgs
    {
        public Payment SelectedPayment{ get; set; }
    }
}
