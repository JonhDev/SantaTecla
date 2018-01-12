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
    /// Interaction logic for AdminPanelWindow.xaml
    /// </summary>
    public partial class PharmacyPanelWindow : Window
    {
        public PharmacyPanelWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new InfoPage());
            ConsultarPrees.Click += (obj, args) => MainFrame.Navigate(new InfoPage());
            ConsultarMed.Click += (obj, args) => MainFrame.Navigate(new MedicinePage(1));
            Modificar.Click += (obj, args) => MainFrame.Navigate(new MedicinePage(2));
            Salir.Click += (obj, arg) =>
            {
                new LoginPage().Show();
                Close();
            };
        }

        
    }
}
