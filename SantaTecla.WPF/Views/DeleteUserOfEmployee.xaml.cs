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
                {
                    Loading.Visibility = Visibility.Visible;
                    DeleteById(int.Parse(IdToDelete.Text)).GetAwaiter();
                }
                else
                    Xceed.Wpf.Toolkit.MessageBox.Show("Falto el ID", "Vaya, que cosas...", MessageBoxButton.OK,
                        MessageBoxImage.Error);
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
                    Xceed.Wpf.Toolkit.MessageBox.Show("Paciente eliminado con éxito", "Listo", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                else
                    Xceed.Wpf.Toolkit.MessageBox.Show("Error al eliminar", "Un error ha surgido", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                Loading.Visibility = Visibility.Collapsed;
            }
            else
            {
                if (await service.DeletePaciente(int.Parse(IdToDelete.Text)))
                    Xceed.Wpf.Toolkit.MessageBox.Show("Empleado eliminado", "Buenas noticias", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                else
                    Xceed.Wpf.Toolkit.MessageBox.Show("Error al eliminar", "Houston tenemos un problema", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                Loading.Visibility = Visibility.Collapsed;
            }

        }

    }
}
