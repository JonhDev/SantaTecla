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
    public partial class PersonalRegisterPage : Window
    {
        public PersonalRegisterPage()
        {
            InitializeComponent();
            aceptar.Click += Aceptar_Click;

            cancelar.Click += (sender, e) =>
            {
                ControlWindow control = new ControlWindow();
                Hide();
                control.Show(14);
            };

        }

        private async void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            SantaTeclaService service = new SantaTeclaService();

            Personal personal = new Personal
            {
                Nombre = nombre.Text,
                Apellidos = apellido.Text,
                Puesto = puesto.Text,
                Login = new Models.Login { User = usuario.Text,Password=contra.Text}
            };

            if (await service.PostPersonal(personal))
            {
                MessageBox.Show("Personal Agregado");
                ControlWindow control = new ControlWindow();
                Hide();
                control.Show(14);
                Close();
            }
            else MessageBox.Show("ERROR");


        }
    }
}
