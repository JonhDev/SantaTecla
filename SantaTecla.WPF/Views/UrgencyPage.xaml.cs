using SantaTecla.Models;
using SantaTecla.Services;
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
    public partial class UrgencyPage : Page
    {
        int id;
        public UrgencyPage()
        {
            InitializeComponent();
            AddReport.Click += Button_Click;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(info.Text))
            {
                Loading.Visibility = Visibility.Visible;
                id = int.Parse(Id.Text);
                SantaTeclaService service = new SantaTeclaService();

                Pacientes pac = await service.GetPacienteById(id);

                pac.Historial.Antecendentes = info.Text;

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
