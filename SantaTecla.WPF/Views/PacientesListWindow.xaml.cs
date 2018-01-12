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

        private int _quien;
        public PacientesListWindow(int quien)
        {
            InitializeComponent();
            _quien = quien;
            GetData().GetAwaiter();
        }

        private async Task GetData()
        {
            SantaTeclaService sevice = new SantaTeclaService();
            if(_quien == 0)
                ListPacientes.ItemsSource = await sevice.GetPacientes();
            else
            {
                ListPacientes.ItemsSource = await sevice.GetPersonal();
            }
            Ok.Click += (sender, args) =>
            {
                if (ListPacientes.SelectedItem != null)
                {
                    OnItemSelected?.Invoke(this, new ItemSelectedEventArgs
                    {
                        Objecto = ListPacientes.SelectedItem
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
        public object Objecto { get; set; }
    }
}
