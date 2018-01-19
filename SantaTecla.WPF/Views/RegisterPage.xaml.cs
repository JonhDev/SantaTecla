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
                    Cama.Text = ""+paciente.Internado.IdCama;
                    Edificio.Text = "" + paciente.Internado.IdEdificio;
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
                Loading.Visibility = Visibility.Visible;
                SantaTeclaService serv = new SantaTeclaService();
                var pac = new Pacientes();
                if (refAct == 1)
                {
                    
                    id = int.Parse(IdToSearch.Text);
                    pac = await serv.GetPacienteById(id);
                    pac.Nombre = nombre.Text;
                    pac.Edad = int.Parse(edad.Text);
                    pac.Direccion = direccion.Text;
                    pac.FormaDePago = _pay;
                    pac.Historial.Antecendentes += "\n"+historial.Text;
                    pac.Sexo = sexMasc.IsChecked.Value ? "masculino" : "femenino";
                    if (await serv.BedCheck(int.Parse(Edificio.Text), int.Parse(Cama.Text),id))
                    {
                        pac.Internado.IdCama = int.Parse(Cama.Text);
                        pac.Internado.IdEdificio = int.Parse(Edificio.Text);
                        if (await serv.PutPaciente(id, pac))
                            Xceed.Wpf.Toolkit.MessageBox.Show("Paciente actualizado con éxito", "Nueva version", MessageBoxButton.OK,
                                MessageBoxImage.Information);
                        else
                            Xceed.Wpf.Toolkit.MessageBox.Show("Error verifica los campos", "Puede que haya algo mal", MessageBoxButton.OK,
                                MessageBoxImage.Error);
                    }
                    else
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Esta cama aun no esta disponible", "Aun no", MessageBoxButton.OK,
                            MessageBoxImage.Stop);
                    }                    
                }
                else
                {
                   
                    pac.Nombre = nombre.Text;
                    pac.Edad = int.Parse(edad.Text);
                    pac.Direccion = direccion.Text;
                    pac.FormaDePago = _pay;
                    pac.Historial = new Historial()
                    {
                        Antecendentes = historial.Text
                    };
                    
                    pac.Sexo = sexMasc.IsChecked.Value ? "masculino" : "femenino";
                    pac.Citas = new Citas()
                    {
                        Fecha = DateTime.Now.ToString(),
                        IdPersonal = 0,
                        NoCita = 0
                    };

                    if (await serv.BedCheck(int.Parse(Edificio.Text), int.Parse(Cama.Text),id))
                    {
                        pac.Internado = new Internado()
                        {
                            IdCama = int.Parse(Cama.Text),
                            IdEdificio = int.Parse(Cama.Text),
                            IdInternado = 0
                        };
                        if (await serv.PostPaciente(pac))
                        {
                            Xceed.Wpf.Toolkit.MessageBox.Show("Paciente agregado", "Genial", MessageBoxButton.OK,
                                MessageBoxImage.Information);
                            nombre.Text = "";
                            edad.Text = "";
                            direccion.Text = "";
                            historial.Text = "";
                        }
                        else
                            Xceed.Wpf.Toolkit.MessageBox.Show("Error", "Aqui tenemos un error", MessageBoxButton.OK,
                                MessageBoxImage.Error);
                    }
                    else
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("La cama ingresada no esta disponible", "Algo salio mal", MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                }

                Loading.Visibility = Visibility.Collapsed;
            }
            else
                Xceed.Wpf.Toolkit.MessageBox.Show("Informacion faltante", "Un error aparecio", MessageBoxButton.OK,
                    MessageBoxImage.Error);
        }

    }
}
