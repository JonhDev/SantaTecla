using SantaTecla.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SantaTecla.WPF.ViewModels
{
    public class ControlWindow
    {
        int aux;
        public ControlWindow(int aux)
        {
            this.aux = aux;
        }
        public ControlWindow()
        {

        }
        
        public void Show(int key)
        {
            switch (key)
            {
                case 1:
                    ReceptionPanelWindow recepcion = new ReceptionPanelWindow();
                    recepcion.Show();
                    break;
                case 2:
                    RegisterPage register = new RegisterPage();
                    //register.Show();
                    break;

                case 4:
                    CookPanelWindow cookReport = new CookPanelWindow();
                    cookReport.Show();
                    break;
                case 5:
                    CookInfoPage cookInfo = new CookInfoPage();
                    cookInfo.Show();
                    break;
                case 6:
                    UserMenuPage menu = new UserMenuPage();
                    menu.Show();
                    break;
                case 7:
                    NursePanelWindow urgency = new NursePanelWindow();
                    urgency.Show();
                    break;
                case 8:
                    UserReportPage report = new UserReportPage();
                    break;
                case 9:
                    InfoPage info = new InfoPage();
                    break;
                case 10:
                    DoctorPanelWindow option = new DoctorPanelWindow();
                    option.Show();
                    break;
                case 11:
                    PaymentPage pay = new PaymentPage();
                    pay.Show();
                    break;
                case 12:
                    PharmacyPanelWindow pharmacy = new PharmacyPanelWindow();
                    pharmacy.Show();
                    break;
                case 13:
                    MedicinePage medicine = new MedicinePage(aux);
                    break;
                case 14:
                    AdminPanelWindow adminPage = new AdminPanelWindow();
                    adminPage.Show();
                    break;

                case 16:
                    PersonalRegisterPage personal = new PersonalRegisterPage();
                    //personal.Show();
                    break;
                default:
                    MessageBox.Show("Error");
                    break;
            }

        }

    }
}
