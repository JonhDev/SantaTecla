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
    /// Lógica de interacción para AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Window
    {
        public AdminPage()
        {
            InitializeComponent();

            ControlWindow control = new ControlWindow();
            StaticHelper.OptionReturn = 5;
            agrega.Click += (sender, e) =>
            {
                Hide();
                StaticHelper.Option = 10;
                control.Show(15);
                Close();
            };

            elimina.Click += (sender, e) =>
            {
                StaticHelper.Option = 2;
                Hide();
                control.Show(15);
                Close();
            };

            consulta.Click += (sender, e) =>
            {
                StaticHelper.Option = 8;
                Hide();
                control.Show(15);
                Close();
            };

            cierra.Click += (sender, e) =>
            {
                LoginPage log = new LoginPage();
                Hide();
                log.Show();
                Close();
            };


        }

        
    }
}
