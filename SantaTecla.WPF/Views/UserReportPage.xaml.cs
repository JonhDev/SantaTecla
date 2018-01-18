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
    /// Interaction logic for UserReportPage.xaml
    /// </summary>
    public partial class UserReportPage : Page
    {
        ControlWindow Control = new ControlWindow();
        public UserReportPage()
        {
            InitializeComponent();
            
            listo.Click += Listo_Click;
        }

        private async void Listo_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;// crear campos para id
            if (!String.IsNullOrEmpty(diagnostico.Text))
            {
                Loading.Visibility = Visibility.Visible;
                SantaTeclaService service = new SantaTeclaService();

                Pacientes pac = await service.GetPacienteById(id);

                pac.Historial.Antecendentes = diagnostico.Text;

                if (await service.PutPaciente(id, pac))
                    MessageBox.Show("Paciente Actualizado");
                else
                    MessageBox.Show("Error");
                Loading.Visibility = Visibility.Collapsed;
            }
            else
                MessageBox.Show("Cuadro vacio");
        }
    }
}
