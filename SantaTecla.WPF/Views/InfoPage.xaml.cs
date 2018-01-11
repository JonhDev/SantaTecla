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
using SantaTecla.Services;
using SantaTecla.WPF.ViewModels;

namespace SantaTecla.WPF.Views
{
    /// <summary>
    /// Interaction logic for InfoPage.xaml
    /// </summary>
    public partial class InfoPage : Window
    {
        public InfoPage()
        {
            InitializeComponent();
            finalizar.Click += Finalizar_Click;
            if (StaticHelper.Option1 == 12)
            {
                GetDataPac().GetAwaiter();
            }
            if (StaticHelper.Option1 == 13)
            {
                GetDataPer().GetAwaiter();
            }
            
        }

        private async Task GetDataPac()
        {
            SantaTeclaService sev = new SantaTeclaService();
            var paciente = await sev.GetPacienteById(StaticHelper.SelectedId);
            string info =
                $"Informacion del paciente: {paciente.Nombre} de {paciente.Edad} años\nANTECEDENTES\n{paciente.Historial.Antecendentes}\nCONTRADICCIONES\n{paciente.Historial.Contradicciones}";
            infoText.Text = info;
        }

        private async Task GetDataPer()
        {
            SantaTeclaService sev = new SantaTeclaService();
            var personal = await sev.GetPersonalById(StaticHelper.SelectedId);
            string info =
                $"Informacion del personal: Nombre: {personal.Nombre} \n{personal.Apellidos} \npuesto: {personal.Puesto}\nUsuario{personal.Login.User}";
            infoText.Text = info;
        }

        private void Finalizar_Click(object sender, RoutedEventArgs e)
        {
            ControlWindow control = new ControlWindow();
            if (StaticHelper.OptionReturn == 5)
            {
                Hide();
                control.Show(14);
                Close();
            }
            
        }
    }
}
