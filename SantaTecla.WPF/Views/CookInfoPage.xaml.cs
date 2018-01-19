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
    /// Interaction logic for CookInfoPage.xaml
    /// </summary>
    public partial class CookInfoPage : Window
    {
        public CookInfoPage()
        {
            InitializeComponent();
            cerrar.Click += Cerrar_Click;
        }

        private async void Cerrar_Click(object sender, RoutedEventArgs e)
        {
            Loading.Visibility = Visibility.Visible;
            SantaTeclaService ser =  new SantaTeclaService();
            var paciente = await ser.GetPacienteById(StaticHelper.SelectedId);
            paciente.Historial.Contradicciones += "\n"+contradicciones.Text;
            if (await ser.PutPaciente(StaticHelper.SelectedId, paciente))
                Xceed.Wpf.Toolkit.MessageBox.Show("Guardado con éxito", "Whooou", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            else
                Xceed.Wpf.Toolkit.MessageBox.Show("No se ha podido guardar", "Que mal (Error)", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            LoginPage login = new LoginPage();
            login.Show();
            this.Close();
        }
    }
}
