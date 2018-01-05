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
    /// Lógica de interacción para PharmacyPage.xaml
    /// </summary>
    public partial class PharmacyPage : Window
    {
        ControlWindow control;
        public PharmacyPage()
        {
            InitializeComponent();

            CPrescripcion.Click += (sender, e)=>
            {
                control= new ControlWindow();
                Hide();
                control.Show(3);
                Close();
            };

            CMedicamento.Click += (sender, e) =>
            {
                control = new ControlWindow(1);
                Hide();
                control.Show(13);
                Close();
            };

            AMedicamento.Click += (sender, e) =>
            {
                control = new ControlWindow(2);
                Hide();
                control.Show(13);
                Close();
            };

            salir.Click += (sender, e) =>
             {
                 LoginPage login = new LoginPage();
                 login.Show();
                 Close();
             };

        }

    }
}
