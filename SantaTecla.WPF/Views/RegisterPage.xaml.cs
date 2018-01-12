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
using SantaTecla.Models;
using SantaTecla.Services;

namespace SantaTecla.WPF.Views
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : UserControl
    {
        private Payment _pay;
        int refAct,id;
        public RegisterPage()
        {
            InitializeComponent();
            agregar.Click += Agregar_Click;
            pago.Click += Pago_Click;
        }
        public RegisterPage(int refAct)
        {
            InitializeComponent();
            this.refAct = refAct;
            agregar.Click += Agregar_Click;
            pago.Click += Pago_Click;
            Consulta.Click += (obj, arg) =>
            {
                PacientesListWindow list = new PacientesListWindow(0);
                list.Show();
                list.OnItemSelected += (sender, args) =>
                {

                    var paciente = args.Objecto as Pacientes;
                    IdToSearch.Text = ""+paciente.NSS;
                    nombre.Text = paciente.Nombre;
                    edad.Text = "" + paciente.Edad;
                    direccion.Text = paciente.Direccion;
                    if (paciente.Sexo.ToLower() == "masculino")
                        sexMasc.IsChecked = true;
                    else
                        sexFem.IsChecked = true;

                };
            };


        }


        private void Pago_Click(object sender, RoutedEventArgs e)
        {
            PaymentPage payPage =  new PaymentPage();
            payPage.Show();
            payPage.OnSelectedPaymentEvent += (o, args) => _pay = args.SelectedPayment;

        }

        private async void Agregar_Click(object sender, RoutedEventArgs e)
        {

            if (!String.IsNullOrEmpty(nombre.Text) || !String.IsNullOrEmpty(direccion.Text))
            {
                Pacientes pac = new Pacientes();
                SantaTeclaService serv = new SantaTeclaService();
                


                pac.Nombre = nombre.Text;
                pac.Edad = int.Parse(edad.Text);
                pac.Direccion = direccion.Text;
                pac.FormaDePago = _pay;
                pac.Historial = new Historial()
                {
                    Antecendentes = historial.Text
                };
                pac.Internado = new Internado()
                {
                    IdCama = 0,
                    IdEdificio = 0,
                    IdInternado = 0
                };
                pac.Sexo = sexMasc.IsChecked.Value ? "masculino" : "femenino";
                pac.Citas = new Citas()
                {
                    Fecha = DateTime.Now.ToString(),
                    IdPersonal = 0,
                    NoCita = 0
                };
                
                if (await serv.PostPaciente(pac))
                {
                    MessageBox.Show("Paciente agregado");
                    nombre.Text = "";
                    edad.Text = "";
                    direccion.Text = "";
                    historial.Text = "";
                }
                else
                    MessageBox.Show("Error");
            }
            else
                MessageBox.Show("informacion faltante");
        }

    }
}
