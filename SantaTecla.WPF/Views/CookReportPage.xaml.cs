using SantaTecla.Models;
using SantaTecla.Services;
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
    public partial class CookReportPage : Page
    {
        ControlWindow Control = new ControlWindow();
        public CookReportPage()
        {
            InitializeComponent();
            generar.Click += Generar_ClickAsync;
        }

        private async void Generar_ClickAsync(object sender, RoutedEventArgs e)
        {
            int id;
            if (!String.IsNullOrEmpty(IdPaciente.Text))
            {
                id = StaticHelper.SelectedId = int.Parse(IdPaciente.Text);
                SantaTeclaService service = new SantaTeclaService();

                Pacientes pac = await service.GetPacienteById(int.Parse(IdPaciente.Text));

                if (Alergia.IsChecked == true)
                    pac.Historial.Contradicciones += "\nAlergico";
                if (comida.IsChecked == true)
                    pac.Historial.Antecendentes += "\ndieta si restricciones";
                if (OperaCompl.IsChecked == true)
                    pac.Historial.Antecendentes += "\nHistorial de Operacion Complicada";
                if (OperaNorm.IsChecked == true)
                    pac.Historial.Antecendentes += "\nHistorial de Operacion Normal";
                if (await service.PutPaciente(id, pac))
                    MessageBox.Show("Añadido al historial");
                else
                    MessageBox.Show("Error al actualizar");
            }
            else
                MessageBox.Show("Ingrese ID");

            
            
        }
    }
}
