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
                case 3:
                    UserPage user = new UserPage();
                    user.Show();
                    break;
                case 4:
                    CookReportPage cookReport = new CookReportPage();
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
                    UrgencyPage urgency = new UrgencyPage();
                    urgency.Show();
                    break;
                case 8:
                    UserReportPage report = new UserReportPage();
                    report.Show();
                    break;
                case 9:
                    InfoPage info = new InfoPage();
                    break;
                case 10:
                    OptionDr option = new OptionDr();
                    option.Show();
                    break;
                case 11:
                    PaymentPage pay = new PaymentPage();
                    pay.Show();
                    break;
                case 12:
                    PharmacyPage pharmacy = new PharmacyPage();
                    pharmacy.Show();
                    break;
                case 13:
                    MedicinePage medicine = new MedicinePage(aux);
                    medicine.Show();
                    break;
                case 14:
                    AdminPanelWindow adminPage = new AdminPanelWindow();
                    adminPage.Show();
                    break;
                case 15:
                    OptionAdmin admin = new OptionAdmin();
                    //admin.Show();
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
