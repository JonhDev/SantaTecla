using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SantaTecla.WPF.ViewModels
{
    public class Login
    {
        public int Access(string user, string password)
        {
            switch (user)
            {
                case "dr":
                    if (password == "238")
                        return 10;
                    break;
                case "Diet":
                    if (password == "531")
                        return 4;
                    break;
                case "enfermero":
                    if (password == "242")
                        return 7;
                    break;
                case "recep":
                    if (password == "092")
                        return 1;
                    break;
                case "Pcook":
                    if (password == "123")
                        return 5;
                    break;
                case "farmacia":
                    if (password == "098")
                        return 12;
                    break;
            }

            return 0;
        }

    }
}
