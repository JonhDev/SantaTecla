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
using SantaTecla.WPF.ViewModels;

namespace SantaTecla.WPF.Views
{
    /// <summary>
    /// Interaction logic for InfoPage.xaml
    /// </summary>
    public partial class InfoPage : Page
    {
        public InfoPage()
        {
            InitializeComponent();
            
            finalizar.Click += Finalizar_Click;
            Consulta.Click += Consulta_Click;
            Lista.Click += (s, a) =>
            {
                if (Pac.IsChecked.Value)
                {
                    PacientesListWindow pacLis = new PacientesListWindow(0);
                    pacLis.OnItemSelected += (sender, args) =>
                    {
                        var pac = args.Objecto as Pacientes;
                        Id.Text = pac.NSS + "";
                    };
                    pacLis.Show();
                }
                else
                {
                    PacientesListWindow pacLis = new PacientesListWindow(1);
                    pacLis.OnItemSelected += (sender, args) =>
                    {
                        var pac = args.Objecto as Personal;
                        Id.Text = pac.Id + "";
                    };
                    pacLis.Show();
                }
                
            };
        }

        private void Consulta_Click(object sender, RoutedEventArgs e)
        {
            StaticHelper.SelectedId = int.Parse(Id.Text);
            if (Pac.IsChecked == true)
                GetDataPac().GetAwaiter();
            else
                GetDataPer().GetAwaiter();

        }

        private async Task GetDataPac()
        {
            SantaTeclaService sev = new SantaTeclaService();
            var paciente = await sev.GetPacienteById(StaticHelper.SelectedId);
            string info =
                $"Informacion del paciente: {paciente.Nombre} de {paciente.Edad} años\nANTECEDENTES\n{paciente.Historial.Antecendentes}\nCONTRADICCIONES\n{paciente.Historial.Contradicciones}\nNo. Cama: {paciente.Internado.IdCama}  No.Edificio: {paciente.Internado.IdEdificio}";
            infoText.Text = info;
        }

        private async Task GetDataPer()
        {
            SantaTeclaService sev = new SantaTeclaService();
            var personal = await sev.GetPersonalById(StaticHelper.SelectedId);
            string info =
                $"Informacion del personal: Nombre: {personal.Nombre} \n{personal.Apellidos} \npuesto: {personal.Puesto}\nUsuario: {personal.Login.User}";
            infoText.Text = info;
        }

        private void Finalizar_Click(object sender, RoutedEventArgs e)
        {
            Id.Text = "";
            infoText.Text = "";
        }
    }
}
