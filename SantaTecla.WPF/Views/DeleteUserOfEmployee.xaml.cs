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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SantaTecla.Models;

namespace SantaTecla.WPF.Views
{
    /// <summary>
    /// Interaction logic for DeleteUserOfEmployee.xaml
    /// </summary>
    public partial class DeleteUserOfEmployee : Page
    {
        public DeleteUserOfEmployee()
        {
            InitializeComponent();
            Delete.Click += (sender, e) =>
            {
                if (!String.IsNullOrEmpty(IdToDelete.Text))
                    DeleteById(int.Parse(IdToDelete.Text)).GetAwaiter();
                else
                    MessageBox.Show("Inserte Id ");
            };

            
            Lista.Click += (s, a) =>
            {
                PacientesListWindow listas;
                listas = Paciente.IsChecked.Value ? new PacientesListWindow(0) : new PacientesListWindow(1);
                listas.OnItemSelected += (sender, args) =>
                {
                    string nss;
                    if (Paciente.IsChecked.Value)
                    {
                        var pac = args.Objecto as Pacientes;
                        nss = pac.NSS + "";
                    }
                    else
                    {
                        var pac = args.Objecto as Personal;
                        nss = pac.Id + "";
                    }
                    IdToDelete.Text = nss;
                };
                listas.Show();
            };

        }

        private async Task DeleteById(int id)
        {
            SantaTeclaService service = new SantaTeclaService();
            if (Personal.IsChecked == true)
            {
                if (await service.DeletePersonal(int.Parse(IdToDelete.Text)))
                    MessageBox.Show("Paciente eliminado");
                else
                    MessageBox.Show("Error al eliminar");
            }
            else
            {
                if (await service.DeletePaciente(int.Parse(IdToDelete.Text)))
                    MessageBox.Show("Empleado eliminado");
                else
                    MessageBox.Show("Error al eliminar");
            }

        }

    }
}
