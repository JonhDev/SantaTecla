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
    /// Lógica de interacción para OptionAdmin.xaml
    /// </summary>
    public partial class OptionAdmin : Window
    {
        public OptionAdmin()
        {
            ControlWindow control = new ControlWindow();
            InitializeComponent();
            paciente.Click += (sender, e) =>
             {
                 if (StaticHelper.Option == 10)
                 {
                     Hide();
                     control.Show(2);
                     Close();
                 }
                 if (StaticHelper.Option == 2)
                 {
                     StaticHelper.Option1 = 9;
                     Hide();
                     control.Show(3);
                     Close();
                 }
                 if (StaticHelper.Option == 8)
                 {
                     StaticHelper.Option1 = 12;
                     Hide();
                     control.Show(3);
                     Close();
                 }
             };

            personal.Click +=(snder,e)=>
            {
                if (StaticHelper.Option == 10)
                {
                    Hide();
                    control.Show(16);
                    Close();
                }

                if (StaticHelper.Option == 2)
                {
                    StaticHelper.Option1 = 7;
                    Hide();
                    control.Show(3);
                    Close();
                    //mandar a una de id personal para eliminar
                }
                if (StaticHelper.Option == 8)
                {
                    StaticHelper.Option1 = 13;
                    Hide();
                    control.Show(3);
                    Close();
                }
            };
        }
    }
}
