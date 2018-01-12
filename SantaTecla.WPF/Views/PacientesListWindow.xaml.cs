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
    /// Interaction logic for PacientesListWindow.xaml
    /// </summary>
    public partial class PacientesListWindow : Window
    {
        public delegate void ItemSelected(object sender, ItemSelectedEventArgs args);
        public event ItemSelected OnItemSelected;

        public PacientesListWindow()
        {
            InitializeComponent();
            GetData().GetAwaiter();
        }

        private async Task GetData()
        {
            SantaTeclaService sevice = new SantaTeclaService();
            ListPacientes.ItemsSource = await sevice.GetPacientes();
            Ok.Click += (sender, args) =>
            {
                if (ListPacientes.SelectedItem != null)
                {
                    OnItemSelected?.Invoke(this, new ItemSelectedEventArgs
                    {
                        Paciente = ListPacientes.SelectedItem as Pacientes
                    });
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Selecciona una opcion");
                }
            };
        }

    }

    public class ItemSelectedEventArgs : EventArgs
    {
        public Pacientes Paciente { get; set; }
    }
}
