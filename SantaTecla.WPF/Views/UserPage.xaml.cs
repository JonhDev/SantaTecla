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
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Window
    {
        ControlWindow control = new ControlWindow();
        public UserPage()
        {
            InitializeComponent();
            if (StaticHelper.Option1 == 7)
            {
                opcEje.Content = "Eliminar Personal";
                opcTex.Content = "ID Personal";

            }
            if (StaticHelper.Option1 == 12)
            {
                opcEje.Content = "Consultar Paciente";
            }
            if (StaticHelper.Option1 == 13)
            {
                opcEje.Content = "Consultar Personal";
                opcTex.Content = "ID Personal";
            }

            consulta.Click += Consulta_Click;
        }

        private async void Consulta_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(paciente.Text))
            {
                
                StaticHelper.SelectedId = int.Parse(paciente.Text);
                
                if (StaticHelper.Option == 2)
                {
                    SantaTeclaService service = new SantaTeclaService();
                    if(StaticHelper.Option1==7)
                        if (await service.DeletePersonal(StaticHelper.SelectedId))
                        {
                            MessageBox.Show("Personal eliminado");
                        }
                        else MessageBox.Show("ERROR AL ELIMINAR");
                    if (StaticHelper.Option1 == 9)
                        if (await service.DeletePaciente(StaticHelper.SelectedId))
                        {
                            MessageBox.Show("Paciente eliminado");
                        }
                        else MessageBox.Show("ERROR AL ELIMINAR");


                }

                if (StaticHelper.Option == 8)
                {
                    this.Hide();
                    control.Show(9);
                    this.Close();
                }

                if (StaticHelper.OptionReturn == 5 && StaticHelper.Option != 8)
                {
                    this.Hide();
                    control.Show(14);
                    this.Close();
                }


            }
            else
                MessageBox.Show("ingrese paciente");
        }
    }
}
