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
using SantaTecla.Models;
using SantaTecla.WPF.ViewModels;

namespace SantaTecla.WPF.Views
{
    /// <summary>
    /// Lógica de interacción para PersonalRegisterPage.xaml
    /// </summary>
    public partial class PersonalRegisterPage : UserControl
    {
        public PersonalRegisterPage()
        {
            InitializeComponent();
            aceptar.Click += Aceptar_Click;

            puesto.ItemsSource = new string[]
            {
                "administracion",
                "recepcion",
                "doctor",
                "enfermero",
                "dietetica",
                "cocina",
                "farmacia"
            };

            cancelar.Click += (sender, e) =>
            {
                ControlWindow control = new ControlWindow();
                control.Show(14);
            };

        }

        private async void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            SantaTeclaService service = new SantaTeclaService();
            Loading.Visibility = Visibility.Visible;
            Personal personal = new Personal
            {
                Nombre = nombre.Text,
                Apellidos = apellido.Text,
                Puesto = puesto.SelectionBoxItem as string,
                Login = new Models.Login { User = usuario.Text,Password=contra.Text}
            };

            var lista = await service.GetPersonal();
            var objTemp = lista.FirstOrDefault(persona => persona.Login.User == usuario.Text);
            if (objTemp == null)
            {
                if (await service.PostPersonal(personal))
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Personal agregado con éxito", "Todo salio bien", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
                else
                    Xceed.Wpf.Toolkit.MessageBox.Show("El usuario no ha sido agregado", "Error", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                //MessageBox.Show("El usuario no ha sido registrado", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                Xceed.Wpf.Toolkit.MessageBox.Show("El usuario ya existe", "Advertencia", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            Loading.Visibility = Visibility.Collapsed;

        }
    }
}
